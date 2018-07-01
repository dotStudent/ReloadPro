using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReloadClient
{
    public partial class frmReload : Form
    {
        private BusinessLogic Logic;
        private Log log = new Log();
        private bool doLog = false;

        public frmReload()
        {
            InitializeComponent();
        }

        #region BackGroundWorker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgWorker.CancellationPending)
            {
                while (Logic.ReadMessageQueue.Count > 0)
                {
                    ReloadReceiveData RMessage = Logic.ReadMessageQueue.Dequeue();
                    if (Logic.InputValue != Convert.ToInt32(tbSetValue.Text))
                    {
                        Logic.InputValue = Convert.ToInt32(tbSetValue.Text);
                    }
                    FillForm(RMessage);
                    if (doLog == true)
                    {
                        log.toFile(RMessage.CurrentMA, RMessage.VoltageMV, RMessage.Resistance, RMessage.PowerMW, Logic.CumulatedMWh, Logic.CumulatedMAh);
                    }
                }

                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Helper.IsNumeric(tbSetValue.Text) == true)
            {
                Logic.InputValue = Convert.ToInt32(tbSetValue.Text);
                Logic.SetInterval = Convert.ToInt32(tbSetInterval.Text);
                ConfigureLogging();
                if (Helper.IsNumeric(tbShtdwnV.Text) == true)
                {
                    Logic.ShutdownVoltageMV = Convert.ToInt32(tbShtdwnV.Text);
                }
                gbOPMode.Enabled = false;
                Logic.Start();
                bgWorker.RunWorkerAsync();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Logic.StopIt();
                gbOPMode.Enabled = true;
                bgWorker.CancelAsync();
            }
            catch (Exception ex)
            {

            }
        }
        private void frmReload_Load(object sender, EventArgs e)
        {
            Logic = new BusinessLogic();
            cbPorts.DataSource = Serial.GetPorts();
        }
        private void frmReload_FormClosing(object sender, FormClosingEventArgs e)
        {
            //bgWorker.CancelAsync();
            Logic.StopIt();
        }
        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.SetPort = cbPorts.SelectedItem.ToString();
        }
        #endregion

        #region Helper
        private void InitializeAndCheck()
        {
            #region SetOperationsMode
            if (rBtnCC.Checked == true)
            {
                Logic.OpMode = OperationsMode.ConstantCurrent;
            }
            else if (rBtnCV.Checked == true)
            {
                Logic.OpMode = OperationsMode.ConstantVoltage;
            }
            else if (rBtnCR.Checked == true)
            {
                Logic.OpMode = OperationsMode.ConstantResistance;
            }
            else if (rBtnCP.Checked == true)
            {
                Logic.OpMode = OperationsMode.ConstantPower;
            }
            #endregion

        }
        private void FillForm(ReloadReceiveData rd)
        {
            if (rd.MessageType == MsgType.Read)
            {
                tbCRead.SafeInvoke(d => d.Text = rd.CurrentMA.ToString());
                tbVRead.SafeInvoke(d => d.Text = rd.VoltageMV.ToString());
                tbResCalc.SafeInvoke(d => d.Text = rd.Resistance.ToString());
                if (rd.PowerMW >= 1000)
                {
                    if (lblUnitPCalc.Text != "W")
                    {
                        lblUnitPCalc.SafeInvoke(d => d.Text = "W");
                    }
                    tbPowerCalc.SafeInvoke(d => d.Text = rd.PowerW.ToString());
                }
                else
                {
                    if (lblUnitPCalc.Text != "mW")
                    {
                        lblUnitPCalc.SafeInvoke(d => d.Text = "mW");
                    }
                    tbPowerCalc.SafeInvoke(d => d.Text = rd.PowerMW.ToString());
                }
                if (Logic.CumulatedMWh >= 1000)
                {
                    if (lblUnitWhCalc.Text != "Wh")
                    {
                        lblUnitWhCalc.SafeInvoke(d => d.Text = "Wh");
                    }
                    tbWhCalc.SafeInvoke(d => d.Text = Logic.CumulatedWh.ToString());
                }
                else
                {
                    if (lblUnitWhCalc.Text != "mWh")
                    {
                        lblUnitWhCalc.SafeInvoke(d => d.Text = "mWh");
                    }
                    tbWhCalc.SafeInvoke(d => d.Text = Logic.CumulatedMAh.ToString());
                }
                if (Logic.CumulatedMAh >= 1000)
                {
                    if (lblUnitAhCalc.Text != "Ah")
                    {
                        lblUnitAhCalc.SafeInvoke(d => d.Text = "Ah");
                    }
                    tbAhCalc.SafeInvoke(d => d.Text = Logic.CumulatedAh.ToString());
                }
                else
                {
                    if (lblUnitWhCalc.Text != "mAh")
                    {
                        lblUnitAhCalc.SafeInvoke(d => d.Text = "mAh");
                    }
                    tbAhCalc.SafeInvoke(d => d.Text = Logic.CumulatedMAh.ToString());
                }
                tbAhCalc.SafeInvoke(d => d.Text = Logic.CumulatedMAh.ToString());
            }
            //Log Windows
            if (rd.MessageType == MsgType.Read)
            {
                //tbMessage.SafeInvoke(d => d.Text = tbMessage.Text + Environment.NewLine + rd.CurrentMA + ", " + rd.VoltageMV);
                tbMessage.SafeInvoke(d => d.Text = "Read: " + rd.CurrentMA + ", " + rd.VoltageMV);
            }
            else if (rd.MessageType == MsgType.Set)
            {
                tbMessage.SafeInvoke(d => d.Text = "Set: " + rd.CurrentMA);
            }
            else if (rd.MessageType == MsgType.Error)
            {
                tbError.SafeInvoke(d => d.Text = "Error: " + rd.Error);
            }
            else
            {
                tbError.SafeInvoke(d => d.Text = "Unknown: " + rd.Error);
            }
        }
        private void ConfigureLogging()
        {
            if (cbLog.Checked == true)
            { 
                    log.LogPath = tbLogPath.Text;
                    log.Append = cbLogAppend.Checked;
            }
        }
        #endregion

        private void cbLog_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLog.Checked == true)
            {
                doLog = true;
                cbLogAppend.Enabled = true;
                tbLogPath.Enabled = true;
            }
            else
            {
                doLog = false;
                cbLogAppend.Enabled = false;
                tbLogPath.Enabled = false;
            }
        }
    }
}
