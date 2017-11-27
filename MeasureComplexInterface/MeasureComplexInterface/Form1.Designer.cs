namespace MeasureComplexInterface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMultiCOM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPSCOM = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.LabelSamplingTime = new System.Windows.Forms.Label();
            this.outMulti = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.outTacho = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonShowChart = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outPerfRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.outDT = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.outTorque = new System.Windows.Forms.Label();
            this.outPower = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.outPS = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRotorType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxVaneWidth = new System.Windows.Forms.TextBox();
            this.textBoxVaneHeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxTurbineDiameter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rButtonTorqueWind = new System.Windows.Forms.RadioButton();
            this.rButtonPowerWind = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.comboBoxMultiCOM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxPSCOM);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.LabelSamplingTime);
            this.groupBox1.Location = new System.Drawing.Point(638, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(120, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1488,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBoxMultiCOM
            // 
            this.comboBoxMultiCOM.FormattingEnabled = true;
            this.comboBoxMultiCOM.Location = new System.Drawing.Point(120, 72);
            this.comboBoxMultiCOM.Name = "comboBoxMultiCOM";
            this.comboBoxMultiCOM.Size = new System.Drawing.Size(74, 21);
            this.comboBoxMultiCOM.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "UT61b COM port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "WE2107 COM port:";
            // 
            // comboBoxPSCOM
            // 
            this.comboBoxPSCOM.FormattingEnabled = true;
            this.comboBoxPSCOM.Location = new System.Drawing.Point(120, 45);
            this.comboBoxPSCOM.Name = "comboBoxPSCOM";
            this.comboBoxPSCOM.Size = new System.Drawing.Size(74, 21);
            this.comboBoxPSCOM.TabIndex = 10;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 99);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(188, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // LabelSamplingTime
            // 
            this.LabelSamplingTime.AutoSize = true;
            this.LabelSamplingTime.Location = new System.Drawing.Point(6, 22);
            this.LabelSamplingTime.Name = "LabelSamplingTime";
            this.LabelSamplingTime.Size = new System.Drawing.Size(89, 13);
            this.LabelSamplingTime.TabIndex = 0;
            this.LabelSamplingTime.Text = "Sampling time (s):";
            // 
            // outMulti
            // 
            this.outMulti.AutoSize = true;
            this.outMulti.Location = new System.Drawing.Point(108, 35);
            this.outMulti.Name = "outMulti";
            this.outMulti.Size = new System.Drawing.Size(31, 13);
            this.outMulti.TabIndex = 9;
            this.outMulti.Text = "0 mV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "WE2107:";
            // 
            // outTacho
            // 
            this.outTacho.AutoSize = true;
            this.outTacho.Location = new System.Drawing.Point(108, 16);
            this.outTacho.Name = "outTacho";
            this.outTacho.Size = new System.Drawing.Size(40, 13);
            this.outTacho.TabIndex = 7;
            this.outTacho.Text = "0 RPM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "UT372:";
            // 
            // buttonShowChart
            // 
            this.buttonShowChart.Location = new System.Drawing.Point(6, 42);
            this.buttonShowChart.Name = "buttonShowChart";
            this.buttonShowChart.Size = new System.Drawing.Size(104, 25);
            this.buttonShowChart.TabIndex = 1;
            this.buttonShowChart.Text = "Show Chart";
            this.buttonShowChart.UseVisualStyleBackColor = true;
            this.buttonShowChart.Click += new System.EventHandler(this.buttonShowChart_Click);
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(620, 266);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outPerfRate);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.outDT);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.outTorque);
            this.groupBox3.Controls.Add(this.outPower);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.outPS);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.outTacho);
            this.groupBox3.Controls.Add(this.outMulti);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 80);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // outPerfRate
            // 
            this.outPerfRate.AutoSize = true;
            this.outPerfRate.Location = new System.Drawing.Point(481, 35);
            this.outPerfRate.Name = "outPerfRate";
            this.outPerfRate.Size = new System.Drawing.Size(34, 13);
            this.outPerfRate.TabIndex = 19;
            this.outPerfRate.Text = "00.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Performance rate:";
            // 
            // outDT
            // 
            this.outDT.AutoSize = true;
            this.outDT.Location = new System.Drawing.Point(481, 16);
            this.outDT.Name = "outDT";
            this.outDT.Size = new System.Drawing.Size(34, 13);
            this.outDT.TabIndex = 17;
            this.outDT.Text = "00.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Current time:";
            // 
            // outTorque
            // 
            this.outTorque.AutoSize = true;
            this.outTorque.Location = new System.Drawing.Point(314, 35);
            this.outTorque.Name = "outTorque";
            this.outTorque.Size = new System.Drawing.Size(36, 13);
            this.outTorque.TabIndex = 15;
            this.outTorque.Text = "0 N*m";
            // 
            // outPower
            // 
            this.outPower.AutoSize = true;
            this.outPower.Location = new System.Drawing.Point(314, 16);
            this.outPower.Name = "outPower";
            this.outPower.Size = new System.Drawing.Size(27, 13);
            this.outPower.TabIndex = 14;
            this.outPower.Text = "0 W";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(222, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Breakout torque:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Turbine power:";
            // 
            // outPS
            // 
            this.outPS.AutoSize = true;
            this.outPS.Location = new System.Drawing.Point(108, 53);
            this.outPS.Name = "outPS";
            this.outPS.Size = new System.Drawing.Size(22, 13);
            this.outPS.TabIndex = 11;
            this.outPS.Text = "0 g";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "UT61b:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Rotor type:";
            // 
            // comboBoxRotorType
            // 
            this.comboBoxRotorType.FormattingEnabled = true;
            this.comboBoxRotorType.Items.AddRange(new object[] {
            "Darrieus",
            "Savonius",
            "Combined"});
            this.comboBoxRotorType.Location = new System.Drawing.Point(74, 19);
            this.comboBoxRotorType.Name = "comboBoxRotorType";
            this.comboBoxRotorType.Size = new System.Drawing.Size(103, 21);
            this.comboBoxRotorType.TabIndex = 2;
            this.comboBoxRotorType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRotorType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Vane width:";
            // 
            // textBoxVaneWidth
            // 
            this.textBoxVaneWidth.Location = new System.Drawing.Point(106, 49);
            this.textBoxVaneWidth.Name = "textBoxVaneWidth";
            this.textBoxVaneWidth.Size = new System.Drawing.Size(71, 20);
            this.textBoxVaneWidth.TabIndex = 4;
            this.textBoxVaneWidth.TextChanged += new System.EventHandler(this.textBoxVaneWidth_TextChanged);
            // 
            // textBoxVaneHeight
            // 
            this.textBoxVaneHeight.Location = new System.Drawing.Point(106, 75);
            this.textBoxVaneHeight.Name = "textBoxVaneHeight";
            this.textBoxVaneHeight.Size = new System.Drawing.Size(71, 20);
            this.textBoxVaneHeight.TabIndex = 6;
            this.textBoxVaneHeight.TextChanged += new System.EventHandler(this.textBoxVaneHeight_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Vane height:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxTurbineDiameter);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBoxVaneHeight);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.comboBoxRotorType);
            this.groupBox4.Controls.Add(this.textBoxVaneWidth);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(638, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 130);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wind turbine info:";
            // 
            // textBoxTurbineDiameter
            // 
            this.textBoxTurbineDiameter.Location = new System.Drawing.Point(106, 101);
            this.textBoxTurbineDiameter.Name = "textBoxTurbineDiameter";
            this.textBoxTurbineDiameter.Size = new System.Drawing.Size(71, 20);
            this.textBoxTurbineDiameter.TabIndex = 8;
            this.textBoxTurbineDiameter.TextChanged += new System.EventHandler(this.textBoxTurbineDiameter_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Turbine diameter:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.rButtonTorqueWind);
            this.groupBox2.Controls.Add(this.rButtonPowerWind);
            this.groupBox2.Controls.Add(this.buttonShowChart);
            this.groupBox2.Location = new System.Drawing.Point(576, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 80);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chart options:";
            // 
            // rButtonTorqueWind
            // 
            this.rButtonTorqueWind.AutoSize = true;
            this.rButtonTorqueWind.Location = new System.Drawing.Point(6, 19);
            this.rButtonTorqueWind.Name = "rButtonTorqueWind";
            this.rButtonTorqueWind.Size = new System.Drawing.Size(121, 17);
            this.rButtonTorqueWind.TabIndex = 3;
            this.rButtonTorqueWind.TabStop = true;
            this.rButtonTorqueWind.Text = "Torque/Wind speed";
            this.rButtonTorqueWind.UseVisualStyleBackColor = true;
            this.rButtonTorqueWind.CheckedChanged += new System.EventHandler(this.rButtonTorqueWind_CheckedChanged);
            // 
            // rButtonPowerWind
            // 
            this.rButtonPowerWind.AutoSize = true;
            this.rButtonPowerWind.Location = new System.Drawing.Point(133, 19);
            this.rButtonPowerWind.Name = "rButtonPowerWind";
            this.rButtonPowerWind.Size = new System.Drawing.Size(117, 17);
            this.rButtonPowerWind.TabIndex = 2;
            this.rButtonPowerWind.TabStop = true;
            this.rButtonPowerWind.Text = "Power/Wind speed";
            this.rButtonPowerWind.UseVisualStyleBackColor = true;
            this.rButtonPowerWind.CheckedChanged += new System.EventHandler(this.rButtonPowerWind_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Clear Chart Area";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 369);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Measurement Complex Interface";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label outMulti;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label outTacho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label LabelSamplingTime;
        private System.Windows.Forms.Button buttonShowChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPSCOM;
        private System.Windows.Forms.ComboBox comboBoxMultiCOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label outPower;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label outPS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRotorType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxVaneWidth;
        private System.Windows.Forms.TextBox textBoxVaneHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxTurbineDiameter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label outTorque;
        private System.Windows.Forms.RadioButton rButtonTorqueWind;
        private System.Windows.Forms.RadioButton rButtonPowerWind;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label outDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label outPerfRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}

