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
        private string vers;
        public string version
        {
            get
            {
                return vers;
            }
            set
            {
                vers = value;
                lblVersion.Text = vers;
            }
        }

        public frmReload()
        {
            InitializeComponent();
            lblVersion.Text = "";
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
                    bgWorker.ReportProgress(0, RMessage);
                    //FillForm(RMessage);
                }

                System.Threading.Thread.Sleep(100);
            }
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ReloadReceiveData)
                FillForm(e.UserState as ReloadReceiveData);
        }
        #endregion

        #region Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Helper.IsNumeric(tbSetValue.Text) == true)
            {
                Logic.InputValue = Convert.ToInt32(tbSetValue.Text);
                Logic.SetInterval = Convert.ToInt32(tbSetInterval.Text);
                Logic.OpMode = GetOpMode();
                ConfigureLogging();
                if (Helper.IsNumeric(tbShtdwnV.Text) == true)
                {
                    Logic.ShutdownVoltageMV = Convert.ToInt32(tbShtdwnV.Text);
                }
                doLog = cbLog.Checked;
                Logic.logPath = tbLogPath.Text;
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
            cbPorts.DataSource = ReloadSerial.SerialPorts;
        }
        private void frmReload_FormClosing(object sender, FormClosingEventArgs e)
        {
            //bgWorker.CancelAsync();
            Logic.StopIt();
        }
        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.SetPort = cbPorts.SelectedItem.ToString();
            if (ReloadSerial.GetVersion == null)
            {
                ReloadSerial.ReadVersion();
            }
            lblVersion.Text = "";
            versionTimer.Start();

        }
        private void rBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnCC.Checked)
            {
                lblUnit.Text = "mA";
                tbSetValue.Text = "50";
            }
            else if (rBtnCP.Checked)
            {
                lblUnit.Text = "W";
                tbSetValue.Text = "1";
            }
            else if (rBtnCV.Checked)
            {
                lblUnit.Text = "mV";
                tbSetValue.Text = "100";
            }
            else if (rBtnCR.Checked)
            {
                lblUnit.Text = "Ω";
                tbSetValue.Text = "100";
            }
        }
        #endregion

        #region Private Methods
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
                tbCRead.Text = rd.CurrentMA.ToString();
                tbVRead.Text = rd.VoltageMV.ToString();
                tbResCalc.Text = rd.Resistance.ToString();
                if (rd.PowerMW >= 1000)
                {
                    if (lblUnitPCalc.Text != "W")
                    {
                       lblUnitPCalc.Text = "W";
                    }
                    tbPowerCalc.Text = rd.PowerW.ToString();
                }
                else
                {
                    if (lblUnitPCalc.Text != "mW")
                    {
                        lblUnitPCalc.Text = "mW";
                    }
                    tbPowerCalc.Text = rd.PowerMW.ToString();
                }
                if (Logic.CumulatedMWh >= 1000)
                {
                    if (lblUnitWhCalc.Text != "Wh")
                    {
                        lblUnitWhCalc.Text = "Wh";
                    }
                    tbWhCalc.Text = Logic.CumulatedWh.ToString();
                }
                else
                {
                    if (lblUnitWhCalc.Text != "mWh")
                    {
                        lblUnitWhCalc.Text = "mWh";
                    }
                    tbWhCalc.Text = Logic.CumulatedMAh.ToString();
                }
                if (Logic.CumulatedMAh >= 1000)
                {
                    if (lblUnitAhCalc.Text != "Ah")
                    {
                        lblUnitAhCalc.Text = "Ah";
                    }
                    tbAhCalc.Text = Logic.CumulatedAh.ToString();
                }
                else
                {
                    if (lblUnitWhCalc.Text != "mAh")
                    {
                        lblUnitAhCalc.Text = "mAh";
                    }
                    tbAhCalc.Text = Logic.CumulatedMAh.ToString();
                }
                tbAhCalc.Text = Logic.CumulatedMAh.ToString();
            }
            //Log Windows
            if (rd.MessageType == MsgType.Read)
            {
                tbMessage.AppendText("Read: " + rd.CurrentMA + ", " + rd.VoltageMV + Environment.NewLine);
            }
            else if (rd.MessageType == MsgType.Set)
            {
                tbMessage.AppendText("Set: " + rd.CurrentMA + Environment.NewLine);
            }
            else if (rd.MessageType == MsgType.Error)
            {
                tbError.AppendText("Error: " + rd.Error + Environment.NewLine);
            }
            else
            {
                tbError.AppendText("Unknown: " + rd.Error);
            }
        }
        private void ConfigureLogging()
        {
            if (cbLog.Checked == true)
            {
                Logic.doLog = cbLog.Checked;
                Logic.logPath = tbLogPath.Text;
                Logic.appendLogFile = cbLogAppend.Checked;
            }
        }
        private OperationsMode GetOpMode()
        {
            if (rBtnCP.Checked)
            {
                return OperationsMode.ConstantPower;
            }
            else if (rBtnCV.Checked)
            {
                return OperationsMode.ConstantVoltage;
            }
            else if (rBtnCR.Checked)
            {
                return OperationsMode.ConstantResistance;
            }
            else
            {
                return OperationsMode.ConstantCurrent;
            }
        }
        private void versionTimer_Tick(object sender, EventArgs e)
        {
            string port = ReloadSerial.SetPort;
            if (port != "")
            {
                versionTimer.Stop();
                lblVersion.Text = vers;
                for (int i = 0; i < cbPorts.Items.Count; i++)
                {
                    if ((string)cbPorts.Items[i] == ReloadSerial.SetPort)
                    {
                        cbPorts.SelectedItem = cbPorts.Items[i];
                        lblVersion.Text = ReloadSerial.GetVersion;
                    }
                }
            }
        }
        #endregion
    }
}
