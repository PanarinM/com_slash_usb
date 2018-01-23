using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
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
        public ScriptData MultiData { get; set; }
            
        public List<int> PerfHistory { get; set; } = new List<int>();
        DateTime LogStart;
        System.Timers.Timer tmr;

        public Form1()
        {
            InitializeComponent();
            Settings.Default.PropertyChanged += (sender, e) => Settings.Default.Save();
            chart.Series.Clear();
            
            //get_text(0);
            Turbine = new TurbineData();
            tmr = new System.Timers.Timer();
            tmr.AutoReset = false;
            tmr.Elapsed += Tmr_Elapsed;
            TachoData = new ScriptData("../../../../tacho_read.py", string.Empty);
            WE2107Data = new ScriptData("../../../../serial_read.py", Settings.Default.WE2107COM);
            MultiData = new ScriptData("../../../../ut61b.py", Settings.Default.UT61bCOM);
        }

        void CreateChart(ChartType chartType)
        {
            DatabaseConnect dconn = new DatabaseConnect();
            var query = string.Format("SELECT * FROM data WHERE \"date_time\" > '{0}';", LogStart.ToString("yyyy-MM-dd HH:mm:ss"));
            List<string> lst = dconn.SelectQuery(query);
            SetComLists();
            var series = new Series()
            {
                ChartType = SeriesChartType.Spline,
                Name = string.Format("V = {0} m/s", Settings.Default.WindSpeed.ToString())
            };

            for (var i = 0; i < PerfHistory.Count; i++)
                switch (chartType)
                {
                    case ChartType.PowerFreq:
                        series.BorderWidth = 3;
                        var valX = Convert.ToDouble(outMulti.Text);
                        var valY = Convert.ToDouble(Settings.Default.OutRotorPower);
                        series.Points.AddXY(valX, valY);                       
                        break;
                    case ChartType.TorqueFreq:
                        valX = Convert.ToDouble(outMulti.Text);
                        valY = Convert.ToDouble(Settings.Default.OutTorque);
                        series.Points.AddXY(valX,valY);
                        break;
                }
            series.LegendText = string.Format("Wind speed = {0} m/s", Settings.Default.WindSpeed);
            if (chart.Series.Contains(series))
                chart.Series[series.Name] = series;
            chart.Series.Add(series);
        }

        void SetComLists()
        {
            var ports = SerialPort.GetPortNames();
            comboBoxMultiCOM.DataSource = comboBoxPSCOM.DataSource = ports;
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
                buttonStart.Text = "Stop";
                LogStart = DateTime.Now;
                PerfHistory.Clear();
                tmr.Enabled = true;           
            }
            else
            {
                tmr.Enabled = false;
                buttonStart.Text = "Start";
            }
            InProcess = !InProcess;
            DatabaseConnect dconn = new DatabaseConnect();
            dconn.UpdateRotorInfo(new string[]
            {
                Settings.Default.RotorType,
                Settings.Default.VaneWidth,
                Settings.Default.VaneHeight,
                Settings.Default.RotorDiameter,
                Settings.Default.RotorProfile
            });
        }
        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

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
                Stopwatch sw = new Stopwatch();
                sw.Start();
                outTacho.Invoke(new MethodInvoker(() => outTacho.Text = TachoData.GetData((int)DeviceDataType.UT372)));
                outPS.Invoke(new MethodInvoker(() => outPS.Text = WE2107Data.GetData((int)DeviceDataType.WE2107)));
                outMulti.Invoke(new MethodInvoker(() => outMulti.Text = MultiData.GetData((int)DeviceDataType.UT61b)));
                var perf = sw.ElapsedMilliseconds;
                sw.Stop();

                outDT.Invoke(new MethodInvoker(() => outDT.Text = currentTime.ToString("hh:mm:ss:fff")));
                outPerfRate.Invoke(new MethodInvoker(() => outPerfRate.Text = perf.ToString() + "ms"));
                PerfHistory.Add((int)perf);
                outPower.Invoke(new MethodInvoker(() => outPower.Text = Calculate("power")));
                outTorque.Invoke(new MethodInvoker(() => outTorque.Text = Calculate("torque")));

                Thread.Sleep(Convert.ToInt32(Settings.Default.SamplingRate * 1000));
                GetData(DateTime.Now, ++tick);
            }
        }
        string Calculate(string param)
        {          
            var Response = string.Empty;
            var ScriptPath = "../../../../power_calc.py";
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = ScriptData.PythonPath,
                Arguments = string.Format("\"{0}\" \"{1}\"", ScriptPath, string.Concat(outMulti.Text,outPS.Text,Settings.Default.RotorDiameter)),
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
            return Response;
            
        }
       /* private string[] get_text(int count)
        {
            string[][] filelist;
            string[] file = File.ReadAllLines("../../test.txt");
            string[] result = new string[file.Count() + 1];
            filelist = new string[file.Length][];
            for (var f = 0; f < file.Length; f++)
            {
                filelist[f] = file[f].Split(',');
                result[f] = filelist[f][count];
                result[file.Count()] = filelist[f].Count().ToString();
            }
            return result;
        //}*/
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

    }
}        

