using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Дипломчик
{
    class TBMath_2
    {        
        public TBMath_2()
        {

        }
        public double VTk(double T,double N)
        {
            Random rand = new Random();
            double V = rand.Next(0, Convert.ToInt32(T) / 2);
            return V * N;
        }
        public double[] /*void*/ M(double CIR, double Tk, double T, double Nt, double RoTk_1, double V1)
        {
            double RoTk/*, RoTk_1*/;
            double I, GTk, UTk, V;
            double[] ch = new double[4];

            
            UTk = CIR * Tk*Nt;
            RoTk = RoTk_1 + Math.Min(UTk, (T - RoTk_1));
            //V = VTk(T,Nt);
            V = V1 /** Nt*/;
            if ((V /*/ Nt*/) <= (RoTk_1 + Math.Min(UTk, (T - RoTk_1))))
                I = 1;
            else I = 0;
            GTk = V * I;
            //richTextBox1.Text += "V =" + V + "; G =" + GTk + "; G/Nt =" + GTk / Nt + "; RoTk =" + RoTk + "; I =" + I + "; UTk =" + UTk + '\n';
            ch[0] = GTk;
            ch[1] = V;
            ch[2] = RoTk * Nt;

            RoTk = RoTk - GTk / Nt;
            RoTk_1 = RoTk;

            ch[3] = RoTk_1;

            /*
            chart1.Series["GTk"].Points.AddXY(j, GTk);
            chart1.Series["VTk"].Points.AddXY(j, V);
            chart1.Series["RoTk"].Points.AddXY(j, RoTk * Nt);
            */
            
            
            return ch;
        }
    }
}