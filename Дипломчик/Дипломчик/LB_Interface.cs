using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Дипломчик
{
    using F = System.Windows.Forms;
    using D = System.Drawing;

    class LB_Inretface
    {
        public F.TextBox Size_of_TB = new F.TextBox()
        {
            Location = new D.Point(250, 30),
            Name = "Size_of_TB",
            Text = "1000",
            Size = new D.Size(50, 22)
        };

        public F.Label Size_of_TB_L = new F.Label()
        {
            Location = new D.Point(20, 30),
            Name = "Size_of_TB_L",
            Text = "Максимальный объем Leaky Bucket",
            Size = new D.Size(200, 22)
        };

        public F.TextBox Weight_of_one_token = new F.TextBox()
        {
            Location = new D.Point(250, 60),
            Name = "Weight_of_one_token",
            Text = "20",
            Visible = false,
            Size = new D.Size(50, 22)
        };

        public F.Label Weight_of_one_token_L = new F.Label()
        {
            Location = new D.Point(20, 60),
            Name = "Weight_of_one_token_L",
            Text = "Вес одного токена",
            Visible = false,
            Size = new D.Size(200, 22)
        };

        public F.TextBox CIR = new F.TextBox()
        {
            Location = new D.Point(250, 90),
            Name = "CIR",
            Text = "100",
            Size = new D.Size(50, 22)
        };

        public F.Label CIR_L = new F.Label()
        {
            Location = new D.Point(20, 90),
            Name = "CIR_L",
            Text = "Скорость выходного потока",
            Size = new D.Size(200, 22)
        };

        public F.TextBox Interval = new F.TextBox()
        {
            Location = new D.Point(250, 120),
            Name = "Interval",
            Text = "1",
            Visible = false,
            Size = new D.Size(50, 22)
        };

        public F.Label Interval_L = new F.Label()
        {
            Location = new D.Point(20, 120),
            Name = "Interval_L",
            Text = "Интервал рассмотрения",
            Visible = false,
            Size = new D.Size(200, 22)
        };

        public F.TextBox Help_Ro = new F.TextBox()
        {
            Location = new D.Point(0, 0),
            Name = "Help_Ro",
            //Text = "1000",
            Size = new D.Size(50, 22),
            Visible = false
        };


        public F.Label Size_of_TB_ED = new F.Label()
        {
            Location = new D.Point(320, 30),
            Name = "Size_of_TB_ED",
            Text = "бит",
            Size = new D.Size(30, 22)
        };

        public F.Label CIR_ED = new F.Label()
        {
            Location = new D.Point(320, 90),
            Name = "CIR_ED",
            Text = "бит/сек",
            Size = new D.Size(30, 30)
        };

        public F.Label Weight_of_one_token_ED = new F.Label()
        {
            Location = new D.Point(320, 60),
            Name = "Weight_of_one_token_ED",
            Text = "бит",
            Visible = false,
            Size = new D.Size(30, 22)
        };
        public F.Label Generated_S = new F.Label()////
        {
            Location = new D.Point(20, 120),
            Name = "Generated_S",
            Text = "Объем генерируемого пакета от",
            Size = new D.Size(180, 60)
        };
        public F.Label Generated_To = new F.Label()////
        {
            Location = new D.Point(255, 120),
            Name = "Generated_To",
            Text = "до",
            Size = new D.Size(20, 22)
        };
        public F.TextBox Generated_S_T = new F.TextBox()///
        {
            Location = new D.Point(200, 120),
            Name = "Generated_S_T",
            Text = "0",
            Size = new D.Size(50, 22)
        };
        public F.TextBox Generated_To_T = new F.TextBox()///
        {
            Location = new D.Point(280, 120),
            Name = "Generated_To_T",
            Text = "500",
            Size = new D.Size(50, 22)
        };

        public F.Label Generated_ED = new F.Label()///
        {
            Location = new D.Point(340, 120),
            Name = "Generated_ED",
            Text = "бит",
            Size = new D.Size(30, 22)
        };

        public System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart()
        {
            Location = new D.Point(10, 150),
            Name = "chart1",
            Anchor = (F.AnchorStyles.Right /*| AnchorStyles.Bottom */| F.AnchorStyles.Left | F.AnchorStyles.Top),
            Margin = new F.Padding(5, 5, 5, 5),
            Width = 170,
            Height = 550,
            //chart1.Size = new Size(150, 50);
        };

        public F.RichTextBox RTB = new F.RichTextBox()
        {
            Location = new D.Point(380, 10),
            Name = "RTB",
            Size = new D.Size(260, 130),
            Anchor = (F.AnchorStyles.Right /*| AnchorStyles.Bottom */| F.AnchorStyles.Left | F.AnchorStyles.Top)

        };

        public void Graf_LB()
        {
            
            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 100;
            chart1.ChartAreas["area"].AxisX.Interval = 2;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 1000;
            chart1.ChartAreas["area"].AxisY.Interval = 500;

            Axis ax = new Axis();
            ax.Title = "Время моделирования, с";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "";
            chart1.ChartAreas[0].AxisY = ay;

            chart1.Series.Add("Объем вышедших пакетов, бит");
            chart1.Series.Add("Объём пакетов на входе, бит");
            chart1.Series.Add("Заполнение буфера, бит");
            chart1.Series.Add("Потери, бит");

            chart1.Series["Объем вышедших пакетов, бит"].Color = D.Color.Red;
            chart1.Series["Объём пакетов на входе, бит"].Color = D.Color.Green;
            chart1.Series["Заполнение буфера, бит"].Color = D.Color.Blue;
            chart1.Series["Потери, бит"].Color = D.Color.Purple;

            chart1.Series["Объем вышедших пакетов, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Объём пакетов на входе, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Заполнение буфера, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Потери, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Legends.Add("legend");

        }
    }
}
