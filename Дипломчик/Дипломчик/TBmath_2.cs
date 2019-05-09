using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Дипломчик
{
    class TBMath_2
    {
        public double CIR, Nt, T;
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
            double[] ch = new double[5];


            UTk = CIR *Nt;
            RoTk = RoTk_1 + Math.Min(UTk, (T - RoTk_1));
            V = V1 /** Nt*/;
            if ((V /*/ Nt*/) <= (RoTk_1 + Math.Min(UTk, (T - RoTk_1))))
                I = 1;
            else I = 0;
            GTk = V * I;
            ch[0] = GTk;
            ch[1] = V;
            ch[2] = RoTk;
            ch[4] = V - GTk;
            RoTk = RoTk - GTk;
            RoTk_1 = RoTk;

            ch[3] = RoTk_1;           
            return ch;
        }



        public TBMath_2(double CIR, double Nt, double T)
        {
            this.CIR = CIR;
            this.Nt = Nt;
            this.T = T;
        }

        public double[] M(double Tk, double RoTk_prev, double V)
        {
            double RoTk;
            double I, GTk, UTk;
            double[] ch = new double[4];

            UTk = CIR * Tk * Nt;
            RoTk = RoTk_prev + Math.Min(UTk, (T - RoTk_prev));
            if ((V) <= (RoTk_prev + Math.Min(UTk, (T - RoTk_prev))))
                I = 1;
            else I = 0;
            GTk = V * I;
            ch[0] = GTk;
            ch[1] = V;
            ch[2] = RoTk * Nt;
            RoTk = RoTk - GTk / Nt;
            ch[3] = RoTk;       


            return ch;
        }
        
    }
}