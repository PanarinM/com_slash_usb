﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Npgsql;
using System.Data;

namespace MeasureComplexInterface
{

    public partial class Form1 : Form
    {
        bool InProcess { get; set; }
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

        void CreateChart()
        {
            var series = new Series
            {
                ChartType = SeriesChartType.Spline,
                Name = "Series"+DateTime.Now.ToString("hh-mm-ss"),
            };
            for (var i = 0; i < PerfHistory.Count; i++)
                series.Points.AddXY(i, PerfHistory[i]);            
            chart.Series.Add(series);
        }

        double CalcPower(double x)
        {
            double result = 0;
            //code here
            return result;
        }

        double CalcTorque(double x)
        {
            double result = 0;
            //code here
            return result;
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
            CreateChart();
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

        private void checkBoxLog_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {

            }
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
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test = true;
            c = 0;
            buttonStart.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Environment.Exit(-1);
        }
    }

    public class DatabaseConnect
    {
        DataSet ds = new DataSet();
        NpgsqlConnection npgsqlConnection;
        public DatabaseConnect()
        {
            string connectionString = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "127.0.0.1", "5432", "postgres",
                    "postgres", "com_slash_usb");
            npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();        
        }
        List<string> result = new List<string>();

        public List<string> SelectQuery(string sqlquery)
        {
            result.Clear();
            sqlquery = "SELECT * FROM data WHERE \"date_time\" < '2017-03-30 11:50:00';";
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlquery, npgsqlConnection))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlquery, npgsqlConnection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            result.Add(reader["date_time"].ToString());
                    }
                }
            }
            return result;
        }
        //public int 
        public List<string> UpdateRotorInfo(string[] param)
        {
            result.Clear();
            var query2 = "select id from rotor order by id desc limit 1";
            var query = string.Format(
                "insert into rotor(\"type\",\"vane_width\",\"vane_height\",\"turbine_diameter\", \"arm\") values('{0}','{1}','{2}','{3}','{4}')",
                param[0],param[1],param[2],param[3],param[4]);           
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, npgsqlConnection))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(reader[0].ToString());
                }
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand(query2, npgsqlConnection))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(reader[0].ToString());
                }
            }

            return result;
        }
    }

}
