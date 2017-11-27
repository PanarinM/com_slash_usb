using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace MeasureComplexInterface
{
    
    public partial class Form1 : Form
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        DateTime LogStart;
        public TurbineData Turbine { get; set; }
        public ScriptData TachoData { get; set; }
        public ScriptData WE2107Data { get; set; }
        public ScriptData MultiData { get; set; }
        public int SamplingRate { get; set; } = 1;
        public string WE2107COM { get; set; }
        public string UT61bCOM { get; set; }
        System.Timers.Timer tmr;
        public string OutUT372 { get; set; }
        public string OutUT61b { get; set; }
        public string OutWE2107 { get; set; }
        public string OutTurbinePower { get; set; }
        public string OutBreakoutTorque { get; set; }
        public List<int> PerfHistory { get; set; } = new List<int>();

        public Form1()
        {
            InitializeComponent();
            Turbine = new TurbineData();
            tmr = new System.Timers.Timer
            {
                AutoReset = false                
            };
            tmr.Elapsed += Tmr_Elapsed;            
            TachoData = new ScriptData("../../../../tacho_read.py", string.Empty);
            WE2107Data = new ScriptData("../../../../serial_read.py", WE2107COM);
            MultiData = new ScriptData("../../../../multi_read.py", UT61bCOM);
        }

        void GetData(DateTime currentTime)
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
                Thread.Sleep(SamplingRate * 1000);
                GetData(DateTime.Now);
            }

        }

        void SetComLists()
        {
            var ports = SerialPort.GetPortNames();
            comboBoxMultiCOM.DataSource = comboBoxPSCOM.DataSource = ports;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if (keyData == Keys.F5)
            {
                Refresh();
                bHandled = true;
            }
            return bHandled;
        }
        private void rButtonPowerWind_CheckedChanged(object sender, EventArgs e)
        {   
            if(rButtonPowerWind.Checked)
                rButtonTorqueWind.Checked = false;
            rButtonPowerWind.Checked = true;
        }

        private void rButtonTorqueWind_CheckedChanged(object sender, EventArgs e)
        {
            if(rButtonTorqueWind.Checked)
                rButtonPowerWind.Checked = false;
            rButtonTorqueWind.Checked = true;
        }

        private void buttonShowChart_Click(object sender, EventArgs e)
        {
            
        }
        bool InProcess { get; set; }
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
                buttonStart.Text = "Stop";
            }
            InProcess = !InProcess;
        }

        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetData(e.SignalTime);
        }

        private void textBoxTurbineDiameter_TextChanged(object sender, EventArgs e)
        {
            Turbine.Diameter = ((TextBox)sender).Text;
        }

        private void comboBoxRotorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turbine.RotorType = ((ComboBox)sender).SelectedItem.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SamplingRate = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void textBoxVaneWidth_TextChanged(object sender, EventArgs e)
        {
            Turbine.VaneWidth = ((TextBox)sender).Text;
        }

        private void textBoxVaneHeight_TextChanged(object sender, EventArgs e)
        {
            Turbine.VaneHeight = ((TextBox)sender).Text;
        }       
    }
}
