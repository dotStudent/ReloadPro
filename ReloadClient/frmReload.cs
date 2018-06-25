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

        public frmReload()
        {
            InitializeComponent();
        }

        private void frmReload_Load(object sender, EventArgs e)
        {
            Logic = new BusinessLogic();
            cbPorts.DataSource = Serial.GetPorts();
        }

        private void frmReload_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgWorker.CancelAsync();
            Logic.Stop();
        }
        #region BackGroundWorker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgWorker.CancellationPending)
            {
                while (Logic.ReadMessageQueue.Count > 0)
                {
                    ReloadReceiveData message = Logic.ReadMessageQueue.Dequeue();

                    //Logic.LogMessage(message);

                    //Logic.AddRow(message);
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
                Logic.InputValue = Convert.ToInt32(tbSetValue);

                if (Helper.IsNumeric(tbShtdwnV.Text) == true)
                {
                    Logic.ShutdownVoltage = Convert.ToInt32(tbShtdwnV.Text);
                }
                gbOPMode.Enabled = false;
                Logic.Start();
                bgWorker.RunWorkerAsync();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.SetPort = cbPorts.SelectedItem.ToString();
        }
        #endregion
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
    }
}
