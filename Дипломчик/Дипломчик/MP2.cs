using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public class Buff_2
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

    public class MplexMath_2 : Buff_2
    {
        public System.Windows.Forms.TextBox C_text;
        public System.Windows.Forms.TextBox Q_text;
        public System.Windows.Forms.RichTextBox richTextBox1;
        //        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public double q_tk;
        public double q_tkm1;
        public double C_T;
        public double SUMM_Gi;
        public double Q;
        public double t;
        public double[] Gi;
        public bool hasRt;

        public double[] OPT = new double[2];

        public double L_tk;


        public MplexMath_2(ref System.Windows.Forms.TextBox tB8, ref System.Windows.Forms.RichTextBox rT1, ref System.Windows.Forms.TextBox tB9
            /*, ref System.Windows.Forms.DataVisualization.Charting.Chart c1*/)
        {
            C_text = tB8;
            richTextBox1 = rT1;
            Q_text = tB9;
            C_T = Convert.ToDouble(C_text.Text);
            Q = Convert.ToDouble(Q_text.Text);
            hasRt = true;
        }

        public MplexMath_2(double C_T, double Q)
        {
            //richTextBox1 = rT1;
            this.C_T = C_T;
            this.Q = Q;
            hasRt = false;
        }

        public double[] MX(double[] GI)
        {
            q_tkm1 = summ();
            Gi = GI;
            SUMM_Gi = Gi.Sum();

            if (hasRt)
            {
                richTextBox1.Text += "полученный трафик: ";
                for (int j = 0; j < Gi.Count(); j++)
                {
                    richTextBox1.Text += Gi[j] + "; ";
                }
                richTextBox1.Text += '\n';
            }

            if ((Math.Min((SUMM_Gi), (Math.Max((Q - (q_tkm1 - C_T * t)), 0)))) != 0)
                ad_GI(Gi.Count(), Gi);
            Out_of_MX();
            q_tk = (Math.Max((q_tkm1 - C_T * t), 0)) + (Math.Min((SUMM_Gi), (Math.Max((Q - (q_tkm1 - C_T * t)), 0))));//текущая заполненность буффера

            //вычисление Ltk
            L_tk = SUMM_Gi - (Math.Min((SUMM_Gi), (Math.Max((Q - (q_tkm1 - C_T * t)), 0)))); //потери на мультиплексоре
            //конец - вычисление Ltk
            OPT[0] = L_tk;
            OPT[1] = q_tk;
            return OPT;
        }

        public void ad_GI(int k, double[] gi)//добавление массива TB
        {
            //необходимо добавить условие по ограничению буффера
            for (int i = 0; i < k; i++)
            {
                if (gi[i] + summ() <= Q)
                {
                    Enqueue(gi[i]);
                    if (hasRt)
                    {
                        richTextBox1.Text += "пакет добавлен, размер: " + gi[i];
                        richTextBox1.Text += '\n';
                    }
                }
                else
                {
                    if (hasRt)
                    {
                        richTextBox1.Text += "пакет отброшен";
                        richTextBox1.Text += '\n';
                    }
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

        public void Out_of_MX()
        {
            double Count_of_traf = C_T;
            while ((Count != 0) && (Pop() <= Count_of_traf))
            {
                Count_of_traf = Count_of_traf - Pop();
                if (hasRt)
                {
                    richTextBox1.Text += "вышедший пакет " + Pop();
                    richTextBox1.Text += '\n';
                }
                Dequeue();
            }
        }
    }
}
