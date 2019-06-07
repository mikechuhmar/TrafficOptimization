using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationSystem
{
    //Класс буфера 
    public class Buff
    {       

        public LinkedList<double> _items = new LinkedList<double>();
        public void Enqueue(double value)//Добавляет элемент в очередь.
        {
            _items.AddFirst(value);
        }
        public double Dequeue()//Удаляет первый помещенный элемент из очереди и возвращает его. 
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            double last = _items.Last.Value;
            _items.RemoveLast();
            return last;
        }

        public double Pop()// первый помещенный элемент из очереди и возвращает его. 
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            double last = _items.Last.Value;
            return last;

        }

        public int Count
        {
            get
            {
                return _items.Count;
            }

        }

        public double summ()
        {
            return _items.ToArray().Sum();
        }
    }

    public class MplexMath : Buff
    {
        public System.Windows.Forms.TextBox C_text;
        public System.Windows.Forms.TextBox Q_text;
        public System.Windows.Forms.RichTextBox richTextBox1;
        //        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public double q_tk;
        public double q_tkm1;
        double _C = double.MaxValue;
        double _Q = double.MaxValue;
        public double C_T
        {
            get
            {
                if (_C == double.MaxValue)
                    return Convert.ToDouble(C_text.Text);
                else
                    return _C;
            }
        }

        public double SUMM_Gi;
        public double Q
        {
            get
            {
                if (_Q == double.MaxValue)
                    return Convert.ToDouble(Q_text.Text);
                else
                    return _Q;
            }
        }
        public double t;
        public double[] Gi;
        public bool hasRt;
        public double[] OPT = new double[2];
        public double L_tk;

        public MplexMath(ref System.Windows.Forms.TextBox tB8, ref System.Windows.Forms.RichTextBox rT1, ref System.Windows.Forms.TextBox tB9
            , ref System.Windows.Forms.DataVisualization.Charting.Chart c1)
        {
            C_text = tB8;
            richTextBox1 = rT1;
            Q_text = tB9;
            chart1 = c1;
            //C_T = Convert.ToDouble(C_text.Text);
            //Q = Convert.ToDouble(Q_text.Text);
            hasRt = true;
        }

        public MplexMath(double C_T, double Q)
        {

            //richTextBox1 = rT1;
            this._C = C_T;
            this._Q = Q;
            hasRt = false;
        }

        public double[] res(double[] GI)
        {
            int j_c=0;                                    ///ТЕКУЩИЙ ШАГ МОДЕЛИРОВАНИЯ, НЕОБХОДИМО КАК ТО ОПРЕДЕЛИТЬ!!!
            q_tkm1 = summ();
            Gi = GI;
            SUMM_Gi = Gi.Sum();          

            if (Math.Min(SUMM_Gi, Q - Math.Max(q_tkm1 - C_T * t, 0)) != 0)
                ad_GI(Gi.Count(), Gi);
            if(hasRt)
                Out_of_MX(j_c);
            q_tk = Math.Max(q_tkm1 - C_T * t, 0) + Math.Min(SUMM_Gi, Q - Math.Max(q_tkm1 - C_T * t, 0));//текущая заполненность буффера

            //вычисление Ltk
            L_tk = SUMM_Gi - Math.Min(SUMM_Gi, Q - Math.Max(q_tkm1 - C_T * t, 0)); //потери на мультиплексоре
            //конец - вычисление Ltk
            if (hasRt)
            {
                chart1.Series["Сумма входных пакетов, бит"].Points.AddXY(j_c, SUMM_Gi);
                chart1.Series["Объем пакетов в буффере, бит"].Points.AddXY(j_c, summ());
                chart1.Series["Потери на входе мультиплексора, бит"].Points.AddXY(j_c, L_tk);
            }

            OPT[0] = L_tk;
            OPT[1] = q_tk;
            return OPT;
        }
        public static double[] res(double[] GI, double Q, double C, double q_prev, double t = 1)
        {                                  
            
            double SUMM_Gi = GI.Sum();           

            
            double q = Math.Max(q_prev - C * t, 0) + Math.Min(SUMM_Gi, Q - Math.Max(q_prev - C * t, 0));//текущая заполненность буффера

            //вычисление Ltk
            double L = SUMM_Gi - Math.Min(SUMM_Gi, Q - Math.Max(q_prev - C * t, 0)); //потери на мультиплексоре
                                                                                          //конец - вычисление Ltk

            double[] res = new double[4];
            res[0] = L;
            res[1] = q;
            res[2] = Q;
            res[3] = Math.Min(q_prev, C * t);
            return res;
        }
        public void ad_GI(int k, double[] gi)//добавление массива TB
        {
            //необходимо добавить условие по ограничению буффера
            for (int i = 0; i < k; i++)
            {
                if (gi[i] + summ() <= Q)
                {
                    Enqueue(gi[i]);
                }                
            }
        }

        public void generator_GI(int k)
        {
            Random rand = new Random();
            Gi = new double[k];
            for (int i = 0; i < k; i++)
            {
                Gi[i] = rand.Next(0, 1000);
            }
        }

        public void Out_of_MX(int j)
        {
            double Count_of_traf = C_T;
            double C_O = 0;
            while ((Count != 0) && (Pop() <= Count_of_traf))
            {
                Count_of_traf = Count_of_traf - Pop();
                if (hasRt)
                {
                    //richTextBox1.Text += "вышедший пакет " + Pop();
                    //richTextBox1.Text += '\n';
                    C_O += Pop();
                }
                Dequeue();
            }
            chart1.Series["Объем вышедших пакетов, бит"].Points.AddXY(j, C_O);
        }

        public void Graph()
        {
            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 1;
            chart1.ChartAreas["area"].AxisX.Maximum = 101;
            chart1.ChartAreas["area"].AxisX.Interval = 2;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 20000;
            chart1.ChartAreas["area"].AxisY.Interval = 500;

            chart1.Series.Add("Сумма входных пакетов, бит");
            chart1.Series.Add("Объем пакетов в буффере, бит");
            chart1.Series.Add("Объем вышедших пакетов, бит");
            chart1.Series.Add("Потери на входе мультиплексора, бит");

            chart1.Series["Сумма входных пакетов, бит"].Color = System.Drawing.Color.Red;
            chart1.Series["Объем пакетов в буффере, бит"].Color = System.Drawing.Color.Green;
            chart1.Series["Объем вышедших пакетов, бит"].Color = System.Drawing.Color.Blue;
            chart1.Series["Потери на входе мультиплексора, бит"].Color = System.Drawing.Color.Purple;

            chart1.Series["Сумма входных пакетов, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Объем пакетов в буффере, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Объем вышедших пакетов, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Потери на входе мультиплексора, бит"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Legends.Add("legend");

        }
    }
}
