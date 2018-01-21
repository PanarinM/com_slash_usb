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

namespace MeasureComplexInterface
{
    public partial class Form1 : Form
    {
        bool InProcess { get; set; }

        public TurbineData Turbine { get; set; }
        public ScriptData TachoData { get; set; }
        public ScriptData WE2107Data { get; set; }
        public ScriptData MultiData { get; set; }

        public int SamplingRate { get; set; } = 1;
        public double WindSpeed { get; set; }
        public string WE2107COM { get; set; }
        public string UT61bCOM { get; set; }
        public string OutUT372 { get; set; }
        public string OutUT61b { get; set; }
        public string OuputTurbinePower { get; set; }
        public string OutBreakoutTorque { get; set; }

        public List<int> PerfHistory { get; set; } = new List<int>();
        DateTime LogStart;
        System.Timers.Timer tmr;

        public Form1()
        {
            InitializeComponent();
            chart.Series.Clear();
            get_text(0);
            Turbine = new TurbineData();
            tmr = new System.Timers.Timer
            {
                AutoReset = false
            };
            tmr.Elapsed += Tmr_Elapsed;
            TachoData = new ScriptData("../../../../tacho_read.py", string.Empty);
            WE2107Data = new ScriptData("../../../../serial_read.py", WE2107COM);
            MultiData = new ScriptData("../../../../ut61b.py", UT61bCOM);
        }
        bool test = false;
        void GetData(DateTime currentTime, int tick)
        {
            if (InProcess)
            {
                
                Stopwatch sw = new Stopwatch();
                sw.Start();

                if (!test)
                {
                    outTacho.Invoke(new MethodInvoker(() => outTacho.Text = TachoData.GetData((int)DeviceDataType.UT372)));
                    outPS.Invoke(new MethodInvoker(() => outPS.Text = WE2107Data.GetData((int)DeviceDataType.WE2107)));
                    outMulti.Invoke(new MethodInvoker(() => outMulti.Text = MultiData.GetData((int)DeviceDataType.UT61b)));
                }
                else
                {
                    var shtoto = get_text(tick);
                    if (tick >= Convert.ToInt32(shtoto.Last()))
                    {
                        tmr.Enabled = false;
                        InProcess = !InProcess;
                        return;
                    }
                    outTacho.Invoke(new MethodInvoker(() => outTacho.Text = shtoto[0]));
                    outPS.Invoke(new MethodInvoker(() => outPS.Text = shtoto[1]));
                    outMulti.Invoke(new MethodInvoker(() => outMulti.Text = shtoto[2]));
                }
                    var perf = sw.ElapsedMilliseconds;
                sw.Stop();
                outDT.Invoke(new MethodInvoker(() => outDT.Text = currentTime.ToString("hh:mm:ss:fff")));
                outPerfRate.Invoke(new MethodInvoker(() => outPerfRate.Text = perf.ToString() + "ms"));
                PerfHistory.Add((int)perf);
                if(checkBoxLog.Checked)
                    chart.Invoke(new MethodInvoker(() => chart.Series.Last().Points.AddXY(PerfHistory.Count,(int)perf)));

                Thread.Sleep(SamplingRate * 1000);
                GetData(DateTime.Now, ++tick);
            }

        }

        void CreateChart(ChartType chartType)
        {
            var series = new Series()
            {
                ChartType = SeriesChartType.Spline,
                Name = string.Format("V = {0}", WindSpeed.ToString())
            };

            for (var i = 0; i < PerfHistory.Count; i++)
                switch (chartType)
                {
                    case ChartType.PowerFreq:
                        series.BorderWidth = 3;
                        var valX = Convert.ToDouble(outMulti.Text);
                        var valY = Convert.ToDouble(OuputTurbinePower);
                        series.Points.AddXY(valX, valY);                       
                        break;
                    case ChartType.TorqueFreq:
                        valX = Convert.ToDouble(outMulti.Text);
                        valY = Convert.ToDouble(OutBreakoutTorque);
                        series.Points.AddXY(valX,valY);
                        break;
                }
            series.LegendText = string.Format("Wind speed = {0}", WindSpeed);
            if (chart.Series.Contains(series))
                chart.Series[series.Name] = series;
            chart.Series.Add(series);
        }

        void SetComLists()
        {
            var ports = SerialPort.GetPortNames();
            comboBoxMultiCOM.DataSource = comboBoxPSCOM.DataSource = ports;
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

        private void buttonShowChart_Click(object sender, EventArgs e)
        {
            var arg = rButtonPowerWind.Checked ? ChartType.PowerFreq : ChartType.TorqueFreq;
            if (test)
                CreateChart(arg);
            else
                MessageBox.Show("App is in test mode now.");
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
            List<string> lst = dconn.SelectQuery("");
            var a = dconn.UpdateRotorInfo(new string[]
            {
                "Darrieus",
                "2",
                "2",
                "8",
                "0.13"
            });
        }
        int c = 0;
        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetData(e.SignalTime, c++);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart.Series.Clear();
        }

        private string[] get_text(int count)
        {
            string[][] filelist;
            string[] file = File.ReadAllLines("../../test.txt");
            string[] result = new string[file.Count()+1];
            filelist = new string[file.Length][];
            for (var f = 0; f < file.Length; f++)
            {
                filelist[f] = file[f].Split(',');
                result[f] = filelist[f][count];
                result[file.Count()] = filelist[f].Count().ToString();
            }            
            return result;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test = true;
            c = 0;
            buttonStart.PerformClick();
        }
    }
}
