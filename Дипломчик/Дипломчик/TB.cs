using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дипломчик
{
    public partial class TB : Form
    {
        TBMath tbn;

        public TB()
        {
            InitializeComponent();
        }

        private void TB_Load(object sender, EventArgs e)
        {
            Graph();
            tbn = new TBMath(ref textBox8, ref richTextBox1, ref progressBar1, ref chart1);
        }
            

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        /*public double VTk(double T)
        {
            Random rand = new Random();
            double V = rand.Next(0, Convert.ToInt32(T)/2);
            return V* Convert.ToDouble(textBox8.Text);
        }
        public  void M(double CIR, double Tk, double T, double Nt)
        {
            double RoTk, RoTk_1;
            double I, GTk, UTk, V;
            
            //RoTk_1 = 0;
            RoTk_1 = 5000;
            int K = 100;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            while (K>0)
            {
                int j=0;
                System.Threading.Thread.Sleep(1000);//задержка N миллисекунд 
                UTk = CIR * Tk;
                RoTk = RoTk_1 + Math.Min(UTk, (T - RoTk_1));
                V = VTk(T);
                if ((V/Nt) <= (RoTk_1 + Math.Min(UTk, (T - RoTk_1))))
                    I = 1;
                else I = 0;
                GTk = V * I;
                richTextBox1.Text += "V =" + V+ "; G =" + GTk + "; G/Nt =" + GTk/Nt + "; RoTk =" + RoTk + "; I =" + I + "; UTk =" + UTk+'\n';
                chart1.Series["GTk"].Points.AddXY(j, GTk);
                chart1.Series["VTk"].Points.AddXY(j, V);
                chart1.Series["RoTk"].Points.AddXY(j, RoTk * Nt);
                RoTk = RoTk - GTk / Nt;
                RoTk_1 = RoTk;

                


                j++;
                //return GTk;
                K--;
                progressBar1.Value++;
            }
            //return GTk;
        }*/
        private void button1_Click(object sender, EventArgs e)
        {           

            double T = Convert.ToDouble(textBox7.Text);
            double CIR = Convert.ToDouble(textBox1.Text);
            double Tk = Convert.ToDouble(textBox2.Text);
            double Nt = Convert.ToDouble(textBox8.Text);
            
            tbn.M(CIR, Tk, T, Nt);

        }
        public void Graph ()
        {
            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 100;
            chart1.ChartAreas["area"].AxisX.Interval = 2;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 200000;
            chart1.ChartAreas["area"].AxisY.Interval = 5000;
            

            chart1.Series.Add("GTk");
            chart1.Series.Add("VTk");
            chart1.Series.Add("RoTk");

            chart1.Series["GTk"].Color = Color.Red;
            chart1.Series["VTk"].Color = Color.Green;
            chart1.Series["RoTk"].Color = Color.Blue;

            chart1.Series["GTk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["VTk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["RoTk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Legends.Add("legend");
            /*
            chart1.Series["T"].Points.AddXY(0,0);
            chart1.Series["T"].Points.AddXY(50, 10);
            chart1.Series["T"].Points.AddXY(100, 10);
            chart1.Series["T"].Points.AddXY(200, 1);
            //chart1.Series["T"].Points.Clear();
            */


        }

    }
}
