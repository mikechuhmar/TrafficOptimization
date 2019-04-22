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
    public partial class MP : Form
    {
        MplexMath MXP;
        Buff BUF;
        public MP()
        {
            InitializeComponent();
            
        }

        private void MP_Load(object sender, EventArgs e)
        {
            
            MXP = new MplexMath(ref textBox1,ref richTextBox1, ref textBox2, ref progressBar1);
            BUF = new Buff();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /* public  void M(double CIR, double Tk, double T, double Nt)
         {
             double RoTk, RoTk_1;
             double I, GTk, UTk, V;

             //RoTk_1 = 0;
             RoTk_1 = 5000;
             int K = 100;
             //progressBar1.Maximum = 100;
             //progressBar1.Value = 0;
             while (K > 0)
             {
                 int j = 0;
                 System.Threading.Thread.Sleep(1000);//задержка N миллисекунд 
                 UTk = CIR * Tk;
                 RoTk = RoTk_1 + Math.Min(UTk, (T - RoTk_1));
                 V = VTk(T);
                 if ((V / Nt) <= (RoTk_1 + Math.Min(UTk, (T - RoTk_1))))
                     I = 1;
                 else I = 0;
                 GTk = V * I;
                 richTextBox1.Text += "V =" + V + "; G =" + GTk + "; G/Nt =" + GTk / Nt + "; RoTk =" + RoTk + "; I =" + I + "; UTk =" + UTk + '\n';
                 chart1.Series["GTk"].Points.AddXY(j, GTk);
                 chart1.Series["VTk"].Points.AddXY(j, V);
                 chart1.Series["RoTk"].Points.AddXY(j, RoTk * Nt);
                 RoTk = RoTk - GTk / Nt;
                 RoTk_1 = RoTk;




                 j++;
                 //return GTk;
                 K--;
                 //progressBar1.Value++;
             }
             //return GTk;
         }
         private void button1_Click(object sender, EventArgs e)
         {
             double T = Convert.ToDouble(textBox7.Text);
             double CIR = Convert.ToDouble(textBox1.Text);
             double Tk = Convert.ToDouble(textBox2.Text);
             double Nt = Convert.ToDouble(textBox8.Text);

             M(CIR, Tk, T, Nt);

         }
         */
        //public class Queue
        //{
        /*
        LinkedList<double> _items = new LinkedList<double>();
        
        

        public void Enqueue(double value)//Добавляет элемент в очередь.
            {
                _items.AddFirst(value);
                //throw new NotImplementedException();
            }

            public double Dequeue()//Удаляет первый помещенный элемент из очереди и возвращает его. 
            {
                if (_items.Count == 0)
                {
                    throw new InvalidOperationException("The queue is empty");
                }

                //double last = _items.Tail.Value;
                double last = _items.Last.Value;

                _items.RemoveLast();

                return last;

                //throw new NotImplementedException();

            }

            public double Peek()
            {
                if (_items.Count == 0)
                {
                    throw new InvalidOperationException("The queue is empty");
                }

                return _items.Last.Value;
                //throw new NotImplementedException();
            }

            public int Count
            {
                get
                {
                    
                    return _items.Count;
                }
                //get;
            }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            MXP.MX();
            /*
            BUF._items.Clear();
            int i = 0;
            while (i < 100)
            {
                BUF.Enqueue(i);
                i++;
            }
            i = 0;
            double sum = BUF.summ();
            richTextBox1.Text += sum;
            richTextBox1.Text += '\n';
            while (i < 100)
            {
                richTextBox1.Text += Convert.ToString(BUF.Dequeue());
                richTextBox1.Text += '\n';
                i++;
            }
            */
        }
        //}


    }
}
