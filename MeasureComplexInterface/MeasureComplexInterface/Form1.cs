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
        public int SamplingRate { get; set; }
        public string WE2107COM { get; set; }
        public string UT61bCOM { get; set; }

        public string OutUT372 { get; set; }
        public string OutUT61b { get; set; }
        public string OutWE2107 { get; set; }
        public string OutTurbinePower { get; set; }
        public string OutBreakoutTorque { get; set; }

        public Form1()
        {
            InitializeComponent();

            backgroundWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            TachoData = new ScriptData("../../../../tacho_read.py", string.Empty);
            WE2107Data = new ScriptData("../../../../serial_read.py", WE2107COM);
            MultiData = new ScriptData("../../../../multi_read.py", UT61bCOM);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

        }

        void GetData()
        {
            outTacho.Text = TachoData.GetData((int)DeviceDataType.UT372);           
            outPS.Text = WE2107Data.GetData((int)DeviceDataType.WE2107);
            outMulti.Text = MultiData.GetData((int)DeviceDataType.UT61b);
        }

        void SetComLists()
        {
            var ports = SerialPort.GetPortNames();
            comboBoxMultiCOM.DataSource = comboBoxPSCOM.DataSource = ports;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            switch (keyData)
            {
                case Keys.F5:
                    Refresh();
                    bHandled = true;
                    break;
            }
            return bHandled;
        }
        private void rButtonPowerWind_CheckedChanged(object sender, EventArgs e)
        {
            rButtonTorqueWind.Checked = false;
            rButtonPowerWind.Checked = true;
        }

        private void rButtonTorqueWind_CheckedChanged(object sender, EventArgs e)
        {
            rButtonPowerWind.Checked = false;
            rButtonTorqueWind.Checked = true;
        }

        private void buttonShowChart_Click(object sender, EventArgs e)
        {
            
        }
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            LogStart = DateTime.Now;
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
