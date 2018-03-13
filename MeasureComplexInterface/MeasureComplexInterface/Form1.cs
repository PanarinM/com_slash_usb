using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MeasureComplexInterface.Data;
using MeasureComplexInterface.Data.Entities;
using MeasureComplexInterface.Properties;

namespace MeasureComplexInterface
{
    public partial class Form1 : Form
    {
        bool InProcess { get; set; }
        int c = 0;
        public TurbineData Turbine { get; set; }
        public ScriptData TachoData { get; set; }
        public ScriptData WE2107Data { get; set; }
        public ScriptData AmpData { get; set; }
        public ScriptData VoltData { get; set; }
        public Dictionary<string, Dictionary<int, double>> rawr = new Dictionary<string, Dictionary<int, double>>();
        public Dictionary<string, Dictionary<int, double>> oink = new Dictionary<string, Dictionary<int, double>>();

        public List<int> PerfHistory { get; set; } = new List<int>();
        public object WindSpeed { get; private set; }
        public object OutTorque { get; private set; }
        public object OutRotorPower { get; private set; }
        public string RotorType { get; private set; } = "Дарье";
        public string RotorDiameter { get; private set; } = "2";
        public string RotorProfile { get; private set; } = "Дарье";
        public string VaneHeight { get; private set; } = "2";
        public string VaneWidth { get; private set; } = "3";

        DateTime LogStart;
        System.Timers.Timer tmr;

        public Form1()
        {
            InitializeComponent();
            DefaultValues();

            Settings.Default.PropertyChanged += (sender, e) => Settings.Default.Save();
            chart.Series.Clear();
            SetComLists();
            Turbine = new TurbineData();
            tmr = new System.Timers.Timer();
            tmr.AutoReset = false;
            tmr.Elapsed += Tmr_Elapsed;
        }

        private void DefaultValues()
        {
            comboBoxRotorType.SelectedItem = "Дарье";
            comboBoxRotorProfile.SelectedItem = "Дарье";
            textBoxTurbineDiameter.Text = "8";
            textBoxVaneHeight.Text = "2";
            textBoxVaneWidth.Text = "2";
            textBoxWindSpeed.Text = "3";
            comboBoxPSCOM.SelectedText = "COM4";
            comboBoxAmpCOM.SelectedValue = "COM5";
            comboBoxVoltCOM.SelectedValue = "COM6";
        }

        void CreateChart(ChartType chartType)
        {
            DatabaseConnect dconn = new DatabaseConnect();
            var query = string.Format("SELECT * FROM data WHERE \"date_time\" > '{0}';", LogStart.ToString("yyyy-MM-dd HH:mm:ss"));
            List<string> lst = dconn.SelectQuery(query);
            var series = new Series
            {
                ChartType = SeriesChartType.Spline,
                Name = string.Format("V = {0} m/s", textBoxWindSpeed.Text)
            };
            
            for (var i = 0; i < PerfHistory.Count; i++)
                switch (chartType)
                {
                    case ChartType.PowerFreq:
                        series.BorderWidth = 3;
                        var valX = i;
                        var valY = oink[textBoxWindSpeed.Text][i];
                        series.Points.AddXY(valX, valY);                       
                        break;
                    case ChartType.TorqueFreq:
                        valX = i;
                        valY = rawr[textBoxWindSpeed.Text][i];
                        series.Points.AddXY(valX,valY);
                        break;
                }
            series.LegendText = string.Format("Wind speed = {0} m/s", textBoxWindSpeed.Text);
            if (chart.Series.FindByName(series.Name) != null)
                chart.Series["Series-"+series.Name] = series;
            else
                chart.Series.Add(series);
        }

        void SetComLists()
        {
            var ports = SerialPort.GetPortNames();
            comboBoxAmpCOM.DataSource = SerialPort.GetPortNames();
            comboBoxVoltCOM.DataSource = SerialPort.GetPortNames();
            comboBoxPSCOM.DataSource = SerialPort.GetPortNames();
        }

        private void buttonShowChart_Click(object sender, EventArgs e)
        {
            var arg = rButtonPowerWind.Checked ? ChartType.PowerFreq : ChartType.TorqueFreq;
            CreateChart(arg);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!InProcess)
            {
                rawr.Clear();
                oink.Clear();
                buttonShowChart.Enabled = false;
                buttonStart.Text = "Стоп";
                LogStart = DateTime.Now;
                PerfHistory.Clear();
                tmr.Enabled = true;           
            }
            else
            {
                buttonShowChart.Enabled = true;
                tmr.Enabled = false;
                buttonStart.Text = "Пуск";
            }
            InitDevices();
            InProcess = !InProcess;
            DatabaseConnect dconn = new DatabaseConnect();
            dconn.UpdateRotorInfo(new string[]
            {
                comboBoxRotorType.Text,
                textBoxVaneWidth.Text,
                textBoxVaneHeight.Text,
                textBoxTurbineDiameter.Text,
                "3",
            });
            Refresh();
        }

        private bool InitDevices()
        {
            try
            {
                TachoData = new ScriptData("../../../../tacho_read.py", string.Empty);
                WE2107Data = new ScriptData("../../../../serial_read.py", comboBoxPSCOM.SelectedItem.ToString());
                AmpData = new ScriptData("../../../../ut61b.py", comboBoxAmpCOM.SelectedItem.ToString());
                VoltData = new ScriptData("../../../../ut61b.py", comboBoxVoltCOM.SelectedItem.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        
        }

        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            rawr.Add(textBoxWindSpeed.Text, new Dictionary<int, double>());
            oink.Add(textBoxWindSpeed.Text, new Dictionary<int, double>());
           GetData(e.SignalTime, c++);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart.Series.Clear();
        }
        void GetData(DateTime currentTime, int tick)
        {
            if (InProcess)
            {
                var sw = new Stopwatch();
                long perf = 0;
                sw.Start();
                Invoke((MethodInvoker)delegate
                {
                var tachoData = TachoData.GetData((int)DeviceDataType.UT372).Split(' ');
                outTacho.Text = string.Concat(tachoData[1], " ", tachoData[0]);
                outAmperage.Text = AmpData.GetData((int)DeviceDataType.UT61b);
                outVoltage.Text = VoltData.GetData((int)DeviceDataType.UT61b);
                outPS.Text = WE2107Data.GetData((int)DeviceDataType.WE2107);
                outAmperage.Text = AmpData.GetData((int)DeviceDataType.UT61b);
                outVoltage.Text = VoltData.GetData((int)DeviceDataType.UT61b);
                perf = sw.ElapsedMilliseconds;
                sw.Stop();
                outDT.Text = currentTime.ToString("hh:mm:ss:fff");
                    
                var amp = Convert.ToDouble(!string.IsNullOrWhiteSpace(outAmperage.Text) ? 
                    outAmperage.Text.Split(' ').First().Substring(1).Replace('.', ',') : 
                    "0");
                var volt = Convert.ToDouble(!string.IsNullOrWhiteSpace(outVoltage.Text) ? 
                    outVoltage.Text.Split(' ').First().Substring(1).Replace('.', ',') : 
                    "0");

                outPerfRate.Text = perf.ToString() + "ms";
                PerfHistory.Add((int)perf);
                outPower.Text = (amp * volt).ToString();
                outTorque.Text = Calculate("torque");
                rawr[textBoxWindSpeed.Text].Add(tick, Convert.ToDouble(!string.IsNullOrWhiteSpace(outTorque.Text) ? outTorque.Text.Replace(".",",") : "0"));
                oink[textBoxWindSpeed.Text].Add(tick, amp * volt);
                Refresh();

                });
                GetData(DateTime.Now, ++tick);

            }
        }

       
        string Calculate(string param)
        {      
            var Response = string.Empty;
            var ScriptPath = "../../../../power_calc.py";
            var force = Convert.ToDouble(outPS.Text);
            var rpm = Convert.ToDouble(outTacho.Text.Split(' ')[0].Replace(".",","));
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = ScriptData.PythonPath,
                Arguments = string.Format("\"{0}\" \"{1}\"", ScriptPath, string.Concat(rpm + ",", force + ",", Convert.ToDouble(RotorDiameter) / 2)),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    Response = reader.ReadToEnd();
                }
            }
            var respArr = Response.Split(',');
            return param == "torque" ? respArr[0] : respArr[1];
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var bHandled = false;
            if (keyData == Keys.F5)
            {
                Refresh();
                bHandled = true;
            }
            return bHandled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(InitDevices() == true ? "Устройства подключены и готовы к работе." : "Проверьте подключение устройств.");
        }
    }
}        

