﻿using System;
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
    public partial class Form2 : Form
    {
        TBMath_2 tbn;
        MplexMath_2 MXP;
        Buff_2 BUF;

        public LinkedList<TabPage> TPe = new LinkedList<TabPage>();
        public void Enqueue(TabPage value)//Добавляет элемент в очередь.
        {
            TPe.AddFirst(value);
        }
        public TabPage Dequeue()//Удаляет первый помещенный элемент из очереди и возвращает его. 
        {
            if (TPe.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            TabPage last = TPe.Last.Value;
            TPe.RemoveLast();
            return last;
        }
        public TabPage Pop()// первый помещенный элемент из очереди и возвращает его. 
        {
            if (TPe.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            TabPage last = TPe.Last.Value;
            return last;
        }
        public int Count
        {
            get
            {return TPe.Count;}
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            MXP = new MplexMath_2(ref textBox2, ref richTextBox1, ref textBox4);
            BUF = new Buff_2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabPage newTabPage = new TabPage();
            newTabPage.Text = "TB" + (TPe.Count()+1);
            

            TextBox Size_of_TB = new TextBox();
            Size_of_TB.Location = new Point(250, 30);
            Size_of_TB.Name = "Size_of_TB";
            Size_of_TB.Text = "1000";
            Size_of_TB.Width = 100;
            Size_of_TB.Height = 30;
            Size_of_TB.Size = new Size(115, 22);

            Label Size_of_TB_L = new Label();
            Size_of_TB_L.Location = new Point(20, 30);
            Size_of_TB_L.Name = "Size_of_TB_L";
            Size_of_TB_L.Text = "Максимальный объем Token Bucket";
            Size_of_TB_L.Width = 100;
            Size_of_TB_L.Height = 30;
            Size_of_TB_L.Size = new Size(200, 22);

            TextBox Weight_of_one_token = new TextBox();
            Weight_of_one_token.Location = new Point(250, 60);
            Weight_of_one_token.Name = "Weight_of_one_token";
            Weight_of_one_token.Text = "20";
            Weight_of_one_token.Width = 100;
            Weight_of_one_token.Height = 30;
            Weight_of_one_token.Size = new Size(115, 22);

            Label Weight_of_one_token_L = new Label();
            Weight_of_one_token_L.Location = new Point(20, 60);
            Weight_of_one_token_L.Name = "Weight_of_one_token_L";
            Weight_of_one_token_L.Text = "Вес одного токена";
            Weight_of_one_token_L.Width = 100;
            Weight_of_one_token_L.Height = 30;
            Weight_of_one_token_L.Size = new Size(200, 22);

            TextBox CIR = new TextBox();
            CIR.Location = new Point(250, 90);
            CIR.Name = "CIR";
            CIR.Text = "100";
            CIR.Width = 100;
            CIR.Height = 30;
            CIR.Size = new Size(115, 22);

            Label CIR_L = new Label()
            {
                Location = new Point(20, 90),
                Name = "CIR_L",
                Text = "Скорость поступления токенов",
                Width = 100,
                Height = 30,
                Size = new Size(200, 22)
            };

            TextBox Interval = new TextBox();
            Interval.Location = new Point(250, 120);
            Interval.Name = "Interval";
            Interval.Text = "1";
            Interval.Width = 100;
            Interval.Height = 30;
            Interval.Size = new Size(115, 22);

            Label Interval_L = new Label();
            Interval_L.Location = new Point(20, 120);
            Interval_L.Name = "Interval_L";
            Interval_L.Text = "Интервал рассмотрения";
            Interval_L.Width = 100;
            Interval_L.Height = 30;
            Interval_L.Size = new Size(200, 22);


            TextBox Help_Ro = new TextBox();
            Help_Ro.Location = new Point(0, 0);
            Help_Ro.Name = "Help_Ro";
            //Help_Ro.Text = "1000";
            Help_Ro.Width = 100;
            Help_Ro.Height = 30;
            Help_Ro.Size = new Size(115, 22);
            Help_Ro.Visible = false;



            System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            //chart1.Anchor = (AnchorStyles.Right & AnchorStyles.Bottom & AnchorStyles.Left & AnchorStyles.Top);
            chart1.Location = new Point(10, 150);
            chart1.Name = "chart1";
            chart1.Anchor = (AnchorStyles.Right /*| AnchorStyles.Bottom */| AnchorStyles.Left | AnchorStyles.Top);
            chart1.Margin = new Padding(5,5,5,5);
            chart1.Width = 170;
            chart1.Height = 550;
            //chart1.Size = new Size(150, 50);
            

            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 100;
            chart1.ChartAreas["area"].AxisX.Interval = 2;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 20000;
            chart1.ChartAreas["area"].AxisY.Interval = 500;


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

            newTabPage.Controls.Add(Size_of_TB);
            newTabPage.Controls.Add(Weight_of_one_token);
            newTabPage.Controls.Add(CIR);
            newTabPage.Controls.Add(Interval);
            newTabPage.Controls.Add(Size_of_TB_L);
            newTabPage.Controls.Add(Weight_of_one_token_L);
            newTabPage.Controls.Add(CIR_L);
            newTabPage.Controls.Add(Interval_L);
            newTabPage.Controls.Add(chart1);
            newTabPage.Controls.Add(Help_Ro);


            
            Enqueue(newTabPage);
            tabControl1.TabPages.Add(TPe.ElementAt(0));
            textBox1.Text = Convert.ToString(TPe.Count());
        }


        private void button4_Click(object sender, EventArgs e)
        {
            tbn = new TBMath_2();
            Random rand = new Random();
            
            double T = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[0]).Text);
            double Nt = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[1]).Text);
            double CIR = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[2]).Text);
            double Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(0).Controls[3]).Text);
            double V;
            double RoTk_1=0;
            double[] ch = new double[5];
            double R;

            double[] OPT = new double[2];

            double[] Gi = new double[TPe.Count];

            progressBar1.Maximum = Convert.ToInt16(textBox3.Text)+1;
            progressBar1.Value = 0;
            
            int Time_To_Model = Convert.ToInt16(textBox3.Text);

            for (int k = 0; k <= Time_To_Model; k++)
            {
                progressBar1.Value++;
                for (int z = 0; z <= TPe.Count-1; z++)
                {
                    T = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[0]).Text);
                    Nt = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[1]).Text);
                    CIR = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[2]).Text);
                    Tk = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[3]).Text);

                    if (k==0) RoTk_1 = T / 2;
                    else RoTk_1 = Convert.ToDouble(((TextBox)TPe.ElementAt(z).Controls[9]).Text);

                    V = rand.Next(0, Convert.ToInt32(T) / 2);
                    ch = tbn.M(CIR, Tk, T, Nt, RoTk_1, V);
                    ((TextBox)TPe.ElementAt(z).Controls[9]).Text= Convert.ToString(ch[3]);
                    //RoTk_1 = ch[3];

                    R = ch[4];//потери на z токенбакете

                    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["GTk"].Points.AddXY(k, ch[0]);
                    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["VTk"].Points.AddXY(k, ch[1]);
                    ((System.Windows.Forms.DataVisualization.Charting.Chart)TPe.ElementAt(z).Controls[8]).Series["RoTk"].Points.AddXY(k, ch[2]);

                    Gi[z] = ch[0];
                    richTextBox2.Text += "Момент: " + k + "; TB№" + (TPe.Count - z) + " GTk = " + ch[0];
                    richTextBox2.Text += '\n';

                }
                OPT=MXP.MX(Gi);
                
            }

            MessageBox.Show("Моделирование закончено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int j = 0;
            while (j < 100)
            {
                richTextBox1.Text += rand.Next(0, 5000);
                richTextBox1.Text += '\n';
                j++;
            }
        }
    }
}
