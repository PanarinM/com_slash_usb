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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxPSCOM = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxAmpCOM = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxWindSpeed = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxVoltCOM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.LabelSamplingTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonShowChart = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outVoltage = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            this.outTacho = new System.Windows.Forms.Label();
            this.outAmperage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxRotorProfile = new System.Windows.Forms.ComboBox();
            this.textBoxTurbineDiameter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxVaneHeight = new System.Windows.Forms.TextBox();
            this.comboBoxRotorType = new System.Windows.Forms.ComboBox();
            this.textBoxVaneWidth = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rButtonTorqueWind = new System.Windows.Forms.RadioButton();
            this.rButtonPowerWind = new System.Windows.Forms.RadioButton();
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
            this.groupBox1.Controls.Add(this.comboBoxPSCOM);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBoxAmpCOM);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBoxWindSpeed);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.comboBoxVoltCOM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.LabelSamplingTime);
            this.groupBox1.Location = new System.Drawing.Point(595, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // comboBoxPSCOM
            // 
            this.comboBoxPSCOM.FormattingEnabled = true;
            this.comboBoxPSCOM.Location = new System.Drawing.Point(163, 45);
            this.comboBoxPSCOM.Name = "comboBoxPSCOM";
            this.comboBoxPSCOM.Size = new System.Drawing.Size(74, 21);
            this.comboBoxPSCOM.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Проверка";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxAmpCOM
            // 
            this.comboBoxAmpCOM.FormattingEnabled = true;
            this.comboBoxAmpCOM.Location = new System.Drawing.Point(163, 100);
            this.comboBoxAmpCOM.Name = "comboBoxAmpCOM";
            this.comboBoxAmpCOM.Size = new System.Drawing.Size(74, 21);
            this.comboBoxAmpCOM.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "COM порт амперметра:";
            // 
            // textBoxWindSpeed
            // 
            this.textBoxWindSpeed.Location = new System.Drawing.Point(163, 127);
            this.textBoxWindSpeed.Name = "textBoxWindSpeed";
            this.textBoxWindSpeed.Size = new System.Drawing.Size(74, 20);
            this.textBoxWindSpeed.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Скорость ветра";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(163, 20);
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
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxVoltCOM
            // 
            this.comboBoxVoltCOM.FormattingEnabled = true;
            this.comboBoxVoltCOM.Location = new System.Drawing.Point(163, 73);
            this.comboBoxVoltCOM.Name = "comboBoxVoltCOM";
            this.comboBoxVoltCOM.Size = new System.Drawing.Size(74, 21);
            this.comboBoxVoltCOM.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "COM порт вольтметра:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "WE2107 COM порт:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(124, 153);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(113, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Пуск";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // LabelSamplingTime
            // 
            this.LabelSamplingTime.AutoSize = true;
            this.LabelSamplingTime.Location = new System.Drawing.Point(6, 22);
            this.LabelSamplingTime.Name = "LabelSamplingTime";
            this.LabelSamplingTime.Size = new System.Drawing.Size(131, 13);
            this.LabelSamplingTime.TabIndex = 0;
            this.LabelSamplingTime.Text = "Период семплирования:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Сила:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Скорость вращения:";
            // 
            // buttonShowChart
            // 
            this.buttonShowChart.Location = new System.Drawing.Point(6, 62);
            this.buttonShowChart.Name = "buttonShowChart";
            this.buttonShowChart.Size = new System.Drawing.Size(112, 25);
            this.buttonShowChart.TabIndex = 1;
            this.buttonShowChart.Text = "Показать график";
            this.buttonShowChart.UseVisualStyleBackColor = true;
            this.buttonShowChart.Click += new System.EventHandler(this.buttonShowChart_Click);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(577, 350);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outVoltage);
            this.groupBox3.Controls.Add(this.label18);
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
            this.groupBox3.Controls.Add(this.outAmperage);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 105);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вывод:";
            // 
            // outVoltage
            // 
            this.outVoltage.AutoSize = true;
            this.outVoltage.Location = new System.Drawing.Point(156, 52);
            this.outVoltage.Name = "outVoltage";
            this.outVoltage.Size = new System.Drawing.Size(0, 13);
            this.outVoltage.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Напряжение:";
            // 
            // outPerfRate
            // 
            this.outPerfRate.AutoSize = true;
            this.outPerfRate.Location = new System.Drawing.Point(505, 35);
            this.outPerfRate.Name = "outPerfRate";
            this.outPerfRate.Size = new System.Drawing.Size(0, 13);
            this.outPerfRate.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Скорость считывания";
            // 
            // outDT
            // 
            this.outDT.AutoSize = true;
            this.outDT.Location = new System.Drawing.Point(505, 16);
            this.outDT.Name = "outDT";
            this.outDT.Size = new System.Drawing.Size(0, 13);
            this.outDT.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Текущее время";
            // 
            // outTorque
            // 
            this.outTorque.AutoSize = true;
            this.outTorque.Location = new System.Drawing.Point(325, 35);
            this.outTorque.Name = "outTorque";
            this.outTorque.Size = new System.Drawing.Size(0, 13);
            this.outTorque.TabIndex = 15;
            // 
            // outPower
            // 
            this.outPower.AutoSize = true;
            this.outPower.Location = new System.Drawing.Point(325, 16);
            this.outPower.Name = "outPower";
            this.outPower.Size = new System.Drawing.Size(0, 13);
            this.outPower.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(215, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Пусковой момент";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(215, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Мощность ротора";
            // 
            // outPS
            // 
            this.outPS.AutoSize = true;
            this.outPS.Location = new System.Drawing.Point(156, 71);
            this.outPS.Name = "outPS";
            this.outPS.Size = new System.Drawing.Size(0, 13);
            this.outPS.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Сила тока:";
            // 
            // outTacho
            // 
            this.outTacho.AutoSize = true;
            this.outTacho.Location = new System.Drawing.Point(156, 16);
            this.outTacho.Name = "outTacho";
            this.outTacho.Size = new System.Drawing.Size(0, 13);
            this.outTacho.TabIndex = 7;
            // 
            // outAmperage
            // 
            this.outAmperage.AutoSize = true;
            this.outAmperage.Location = new System.Drawing.Point(156, 35);
            this.outAmperage.Name = "outAmperage";
            this.outAmperage.Size = new System.Drawing.Size(0, 13);
            this.outAmperage.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Тип ротора";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Длинна лопасти";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ширина лопасти";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.comboBoxRotorProfile);
            this.groupBox4.Controls.Add(this.textBoxTurbineDiameter);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBoxVaneHeight);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.comboBoxRotorType);
            this.groupBox4.Controls.Add(this.textBoxVaneWidth);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(595, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(243, 166);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Данные ротора";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Профиль ротора:";
            // 
            // comboBoxRotorProfile
            // 
            this.comboBoxRotorProfile.FormattingEnabled = true;
            this.comboBoxRotorProfile.Items.AddRange(new object[] {
            "Дарье",
            "Савониуса",
            "Комбинированный"});
            this.comboBoxRotorProfile.Location = new System.Drawing.Point(124, 46);
            this.comboBoxRotorProfile.Name = "comboBoxRotorProfile";
            this.comboBoxRotorProfile.Size = new System.Drawing.Size(103, 21);
            this.comboBoxRotorProfile.TabIndex = 9;
            // 
            // textBoxTurbineDiameter
            // 
            this.textBoxTurbineDiameter.Location = new System.Drawing.Point(124, 125);
            this.textBoxTurbineDiameter.Name = "textBoxTurbineDiameter";
            this.textBoxTurbineDiameter.Size = new System.Drawing.Size(103, 20);
            this.textBoxTurbineDiameter.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Диаметр ротора";
            // 
            // textBoxVaneHeight
            // 
            this.textBoxVaneHeight.Location = new System.Drawing.Point(124, 99);
            this.textBoxVaneHeight.Name = "textBoxVaneHeight";
            this.textBoxVaneHeight.Size = new System.Drawing.Size(103, 20);
            this.textBoxVaneHeight.TabIndex = 6;
            // 
            // comboBoxRotorType
            // 
            this.comboBoxRotorType.FormattingEnabled = true;
            this.comboBoxRotorType.Items.AddRange(new object[] {
            "Дарье",
            "Савониуса",
            "Комбинированный"});
            this.comboBoxRotorType.Location = new System.Drawing.Point(124, 19);
            this.comboBoxRotorType.Name = "comboBoxRotorType";
            this.comboBoxRotorType.Size = new System.Drawing.Size(103, 21);
            this.comboBoxRotorType.TabIndex = 2;
            // 
            // textBoxVaneWidth
            // 
            this.textBoxVaneWidth.Location = new System.Drawing.Point(124, 73);
            this.textBoxVaneWidth.Name = "textBoxVaneWidth";
            this.textBoxVaneWidth.Size = new System.Drawing.Size(103, 20);
            this.textBoxVaneWidth.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.rButtonTorqueWind);
            this.groupBox2.Controls.Add(this.rButtonPowerWind);
            this.groupBox2.Controls.Add(this.buttonShowChart);
            this.groupBox2.Location = new System.Drawing.Point(595, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 96);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры графика:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Очистить график";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rButtonTorqueWind
            // 
            this.rButtonTorqueWind.AutoSize = true;
            this.rButtonTorqueWind.Location = new System.Drawing.Point(6, 16);
            this.rButtonTorqueWind.Name = "rButtonTorqueWind";
            this.rButtonTorqueWind.Size = new System.Drawing.Size(218, 17);
            this.rButtonTorqueWind.TabIndex = 3;
            this.rButtonTorqueWind.TabStop = true;
            this.rButtonTorqueWind.Text = "График момента от угловой скорости";
            this.rButtonTorqueWind.UseVisualStyleBackColor = true;
            // 
            // rButtonPowerWind
            // 
            this.rButtonPowerWind.AutoSize = true;
            this.rButtonPowerWind.Location = new System.Drawing.Point(6, 39);
            this.rButtonPowerWind.Name = "rButtonPowerWind";
            this.rButtonPowerWind.Size = new System.Drawing.Size(225, 17);
            this.rButtonPowerWind.TabIndex = 2;
            this.rButtonPowerWind.TabStop = true;
            this.rButtonPowerWind.Text = "График мощности от угловой скорости";
            this.rButtonPowerWind.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 494);
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
        private System.Windows.Forms.Label outAmperage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label outTacho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label LabelSamplingTime;
        private System.Windows.Forms.Button buttonShowChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVoltCOM;
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
        private System.Windows.Forms.ComboBox comboBoxRotorProfile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxWindSpeed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBoxAmpCOM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label outVoltage;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxPSCOM;
    }
}

