using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptimizationSystem
{
    class TBMath_2
    {
        //public double CIR, Nt, T;
        public double U, T;
        public TBMath_2()
        {

        }
        
        public double VTk(double T,double N)
        {
            Random rand = new Random();
            double V = rand.Next(0, Convert.ToInt32(T) / 2);
            return V * N;
        }
        //public double[] /*void*/ M(double CIR, double Tk, double T, double Nt, double RoTk_1, double V1)
        //{
        //    double RoTk/*, RoTk_1*/;
        //    //double I, GTk, UTk, V;
        //    double I, GTk, V;
        //    double[] ch = new double[5];


        //    UTk = CIR *Nt;
        //    RoTk = RoTk_1 + Math.Min(UTk, (T - RoTk_1));
        //    V = V1 /** Nt*/;
        //    if ((V /*/ Nt*/) <= (RoTk_1 + Math.Min(UTk, (T - RoTk_1))))
        //        I = 1;
        //    else I = 0;
        //    GTk = V * I;
        //    ch[0] = GTk;
        //    ch[1] = V;
        //    ch[2] = RoTk;
        //    ch[4] = V - GTk;
        //    RoTk = RoTk - GTk;
        //    RoTk_1 = RoTk;

        //    ch[3] = RoTk_1;           
        //    return ch;
        //}

        public double[] M(double Tk, double T, double U, double RoTk_1, double V1)
        {
            double RoTk/*, RoTk_1*/;
            //double I, GTk, UTk, V;
            double I, GTk, V;
            double[] ch = new double[5];


            //UTk = CIR *Nt;
            RoTk = RoTk_1 + Math.Min(U, (T - RoTk_1));
            V = V1 ;
            if (V <= (RoTk_1 + Math.Min(U, (T - RoTk_1))))
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

        //public TBMath_2(double CIR, double Nt, double T)
        //{
        //    this.CIR = CIR;
        //    this.Nt = Nt;
        //    this.T = T;
        //}

        public TBMath_2(double U, double T)
        {
            this.U = U;
            this.T = T;
        }

        public double[] M(double Tk, double RoTk_1, double V)
        {
            double RoTk;
            double I, GTk;
            double[] ch = new double[5];

            RoTk = RoTk_1 + Math.Min(U, (T - RoTk_1));
            if ((V) <= (RoTk_1 + Math.Min(U, (T - RoTk_1))))
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
    }
}