using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Дипломчик
{
    class TBMath
    {
        System.Windows.Forms.TextBox textBox8;
        System.Windows.Forms.RichTextBox richTextBox1;
        System.Windows.Forms.ProgressBar progressBar1;


        public TBMath(ref System.Windows.Forms.TextBox tB8, ref System.Windows.Forms.RichTextBox rT1,
            ref System.Windows.Forms.ProgressBar pB1)
        {
            textBox8= tB8;
            richTextBox1= rT1;
            progressBar1= pB1;

        }
        public double VTk(double T)
        {
            Random rand = new Random();
            double V = rand.Next(0, Convert.ToInt32(T) / 2);
            return V * Convert.ToDouble(textBox8.Text);
        }
        public void M(double CIR, double Tk, double T, double Nt)
        {
            double RoTk, RoTk_1;
            double I, GTk, UTk, V;

            RoTk_1 = 5000;
            int K = 100;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            while (K > 0)
            {
                int j = 0;
                System.Threading.Thread.Sleep(100);
                UTk = CIR * Tk;
                RoTk = RoTk_1 + Math.Min(UTk, (T - RoTk_1));
                V = VTk(T);
                if ((V / Nt) <= (RoTk_1 + Math.Min(UTk, (T - RoTk_1))))
                    I = 1;
                else I = 0;
                GTk = V * I;
                richTextBox1.Text += "V =" + V + "; G =" + GTk + "; G/Nt =" + GTk / Nt + "; RoTk =" + RoTk + "; I =" + I + "; UTk =" + UTk + '\n';
                RoTk = RoTk - GTk / Nt;
                RoTk_1 = RoTk;
                j++;
                K--;
                progressBar1.Value++;
            }
        }
    }
}
