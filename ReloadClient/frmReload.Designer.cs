namespace ReloadClient
{
    partial class frmReload
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSetInterval = new System.Windows.Forms.TextBox();
            this.gbOPMode = new System.Windows.Forms.GroupBox();
            this.rBtnCR = new System.Windows.Forms.RadioButton();
            this.rBtnCP = new System.Windows.Forms.RadioButton();
            this.rBtnCV = new System.Windows.Forms.RadioButton();
            this.rBtnCC = new System.Windows.Forms.RadioButton();
            this.tbSetValue = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblUnitPCalc = new System.Windows.Forms.Label();
            this.tbPowerCalc = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbResCalc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblUnitAhCalc = new System.Windows.Forms.Label();
            this.tbAhCalc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblUnitWhCalc = new System.Windows.Forms.Label();
            this.tbWhCalc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVRead = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCRead = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblShtdwnV = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbShtdwnV = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbError = new System.Windows.Forms.TextBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbLog = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbOPMode.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(71, 31);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(97, 21);
            this.cbPorts.TabIndex = 0;
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(365, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(446, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(68, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbSetInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.cbPorts);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Interval:";
            // 
            // tbSetInterval
            // 
            this.tbSetInterval.Location = new System.Drawing.Point(246, 32);
            this.tbSetInterval.Name = "tbSetInterval";
            this.tbSetInterval.Size = new System.Drawing.Size(74, 20);
            this.tbSetInterval.TabIndex = 4;
            this.tbSetInterval.Text = "1000";
            this.tbSetInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbOPMode
            // 
            this.gbOPMode.Controls.Add(this.rBtnCR);
            this.gbOPMode.Controls.Add(this.rBtnCP);
            this.gbOPMode.Controls.Add(this.rBtnCV);
            this.gbOPMode.Controls.Add(this.rBtnCC);
            this.gbOPMode.Location = new System.Drawing.Point(12, 92);
            this.gbOPMode.Name = "gbOPMode";
            this.gbOPMode.Size = new System.Drawing.Size(564, 66);
            this.gbOPMode.TabIndex = 5;
            this.gbOPMode.TabStop = false;
            this.gbOPMode.Text = " Operation Mode";
            // 
            // rBtnCR
            // 
            this.rBtnCR.AutoSize = true;
            this.rBtnCR.Location = new System.Drawing.Point(306, 31);
            this.rBtnCR.Name = "rBtnCR";
            this.rBtnCR.Size = new System.Drawing.Size(123, 17);
            this.rBtnCR.TabIndex = 3;
            this.rBtnCR.Text = "Constant Resistance";
            this.rBtnCR.UseVisualStyleBackColor = true;
            // 
            // rBtnCP
            // 
            this.rBtnCP.AutoSize = true;
            this.rBtnCP.Location = new System.Drawing.Point(458, 31);
            this.rBtnCP.Name = "rBtnCP";
            this.rBtnCP.Size = new System.Drawing.Size(100, 17);
            this.rBtnCP.TabIndex = 2;
            this.rBtnCP.Text = "Constant Power";
            this.rBtnCP.UseVisualStyleBackColor = true;
            // 
            // rBtnCV
            // 
            this.rBtnCV.AutoSize = true;
            this.rBtnCV.Location = new System.Drawing.Point(155, 31);
            this.rBtnCV.Name = "rBtnCV";
            this.rBtnCV.Size = new System.Drawing.Size(106, 17);
            this.rBtnCV.TabIndex = 1;
            this.rBtnCV.Text = "Constant Voltage";
            this.rBtnCV.UseVisualStyleBackColor = true;
            // 
            // rBtnCC
            // 
            this.rBtnCC.AutoSize = true;
            this.rBtnCC.Checked = true;
            this.rBtnCC.Location = new System.Drawing.Point(19, 31);
            this.rBtnCC.Name = "rBtnCC";
            this.rBtnCC.Size = new System.Drawing.Size(104, 17);
            this.rBtnCC.TabIndex = 0;
            this.rBtnCC.TabStop = true;
            this.rBtnCC.Text = "Constant Current";
            this.rBtnCC.UseVisualStyleBackColor = true;
            // 
            // tbSetValue
            // 
            this.tbSetValue.Location = new System.Drawing.Point(68, 32);
            this.tbSetValue.Name = "tbSetValue";
            this.tbSetValue.Size = new System.Drawing.Size(100, 20);
            this.tbSetValue.TabIndex = 6;
            this.tbSetValue.Text = "50";
            this.tbSetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblUnit);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbSetValue);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 67);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Value";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(175, 36);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(22, 13);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "mA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.lblUnitPCalc);
            this.groupBox4.Controls.Add(this.tbPowerCalc);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tbResCalc);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.lblUnitAhCalc);
            this.groupBox4.Controls.Add(this.tbAhCalc);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.lblUnitWhCalc);
            this.groupBox4.Controls.Add(this.tbWhCalc);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbVRead);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbCRead);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(567, 147);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Read Values";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(175, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Ω";
            // 
            // lblUnitPCalc
            // 
            this.lblUnitPCalc.AutoSize = true;
            this.lblUnitPCalc.Location = new System.Drawing.Point(175, 118);
            this.lblUnitPCalc.Name = "lblUnitPCalc";
            this.lblUnitPCalc.Size = new System.Drawing.Size(64, 13);
            this.lblUnitPCalc.TabIndex = 25;
            this.lblUnitPCalc.Text = "lblUnitPCalc";
            // 
            // tbPowerCalc
            // 
            this.tbPowerCalc.Location = new System.Drawing.Point(68, 115);
            this.tbPowerCalc.Name = "tbPowerCalc";
            this.tbPowerCalc.ReadOnly = true;
            this.tbPowerCalc.Size = new System.Drawing.Size(100, 20);
            this.tbPowerCalc.TabIndex = 24;
            this.tbPowerCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Power:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(175, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 22;
            // 
            // tbResCalc
            // 
            this.tbResCalc.Location = new System.Drawing.Point(68, 88);
            this.tbResCalc.Name = "tbResCalc";
            this.tbResCalc.ReadOnly = true;
            this.tbResCalc.Size = new System.Drawing.Size(100, 20);
            this.tbResCalc.TabIndex = 21;
            this.tbResCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Resist:";
            // 
            // lblUnitAhCalc
            // 
            this.lblUnitAhCalc.AutoSize = true;
            this.lblUnitAhCalc.Location = new System.Drawing.Point(495, 64);
            this.lblUnitAhCalc.Name = "lblUnitAhCalc";
            this.lblUnitAhCalc.Size = new System.Drawing.Size(70, 13);
            this.lblUnitAhCalc.TabIndex = 19;
            this.lblUnitAhCalc.Text = "lblUnitAhCalc";
            // 
            // tbAhCalc
            // 
            this.tbAhCalc.Location = new System.Drawing.Point(388, 61);
            this.tbAhCalc.Name = "tbAhCalc";
            this.tbAhCalc.ReadOnly = true;
            this.tbAhCalc.Size = new System.Drawing.Size(100, 20);
            this.tbAhCalc.TabIndex = 18;
            this.tbAhCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(274, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Current Consumption:";
            // 
            // lblUnitWhCalc
            // 
            this.lblUnitWhCalc.AutoSize = true;
            this.lblUnitWhCalc.Location = new System.Drawing.Point(495, 35);
            this.lblUnitWhCalc.Name = "lblUnitWhCalc";
            this.lblUnitWhCalc.Size = new System.Drawing.Size(64, 13);
            this.lblUnitWhCalc.TabIndex = 16;
            this.lblUnitWhCalc.Text = "lblUnitECalc";
            // 
            // tbWhCalc
            // 
            this.tbWhCalc.Location = new System.Drawing.Point(388, 32);
            this.tbWhCalc.Name = "tbWhCalc";
            this.tbWhCalc.ReadOnly = true;
            this.tbWhCalc.Size = new System.Drawing.Size(100, 20);
            this.tbWhCalc.TabIndex = 15;
            this.tbWhCalc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Energy Consumption:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "mV";
            // 
            // tbVRead
            // 
            this.tbVRead.Location = new System.Drawing.Point(68, 61);
            this.tbVRead.Name = "tbVRead";
            this.tbVRead.ReadOnly = true;
            this.tbVRead.Size = new System.Drawing.Size(100, 20);
            this.tbVRead.TabIndex = 12;
            this.tbVRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Voltage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "mA";
            // 
            // tbCRead
            // 
            this.tbCRead.Location = new System.Drawing.Point(68, 35);
            this.tbCRead.Name = "tbCRead";
            this.tbCRead.ReadOnly = true;
            this.tbCRead.Size = new System.Drawing.Size(100, 20);
            this.tbCRead.TabIndex = 9;
            this.tbCRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Current:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblShtdwnV);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tbShtdwnV);
            this.groupBox5.Location = new System.Drawing.Point(301, 164);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(275, 67);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Shutdown Voltage Value";
            // 
            // lblShtdwnV
            // 
            this.lblShtdwnV.AutoSize = true;
            this.lblShtdwnV.Location = new System.Drawing.Point(175, 36);
            this.lblShtdwnV.Name = "lblShtdwnV";
            this.lblShtdwnV.Size = new System.Drawing.Size(22, 13);
            this.lblShtdwnV.TabIndex = 8;
            this.lblShtdwnV.Text = "mV";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Value:";
            // 
            // tbShtdwnV
            // 
            this.tbShtdwnV.Location = new System.Drawing.Point(68, 32);
            this.tbShtdwnV.Name = "tbShtdwnV";
            this.tbShtdwnV.Size = new System.Drawing.Size(100, 20);
            this.tbShtdwnV.TabIndex = 6;
            this.tbShtdwnV.Text = "0";
            this.tbShtdwnV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbMessage);
            this.groupBox6.Location = new System.Drawing.Point(12, 390);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(275, 147);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Read Messages";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(19, 20);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(242, 111);
            this.tbMessage.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbError);
            this.groupBox7.Location = new System.Drawing.Point(304, 390);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(275, 147);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Error Messages";
            // 
            // tbError
            // 
            this.tbError.Location = new System.Drawing.Point(19, 20);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.Size = new System.Drawing.Size(242, 111);
            this.tbError.TabIndex = 0;
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(208, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(345, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "C:\\Temp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "LogPath:";
            // 
            // cbLog
            // 
            this.cbLog.AutoSize = true;
            this.cbLog.Location = new System.Drawing.Point(19, 25);
            this.cbLog.Name = "cbLog";
            this.cbLog.Size = new System.Drawing.Size(65, 17);
            this.cbLog.TabIndex = 25;
            this.cbLog.Text = "Activate";
            this.cbLog.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbLog);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 543);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 58);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logging";
            // 
            // frmReload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 611);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbOPMode);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReload";
            this.Text = "Re:Load Pro Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReload_FormClosing);
            this.Load += new System.EventHandler(this.frmReload_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbOPMode.ResumeLayout(false);
            this.gbOPMode.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSetInterval;
        private System.Windows.Forms.GroupBox gbOPMode;
        private System.Windows.Forms.RadioButton rBtnCR;
        private System.Windows.Forms.RadioButton rBtnCP;
        private System.Windows.Forms.RadioButton rBtnCV;
        private System.Windows.Forms.RadioButton rBtnCC;
        private System.Windows.Forms.TextBox tbSetValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVRead;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCRead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUnitAhCalc;
        private System.Windows.Forms.TextBox tbAhCalc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblUnitWhCalc;
        private System.Windows.Forms.TextBox tbWhCalc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblShtdwnV;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbShtdwnV;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblUnitPCalc;
        private System.Windows.Forms.TextBox tbPowerCalc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbResCalc;
        private System.Windows.Forms.Label label15;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbLog;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

