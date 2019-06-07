using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OptimizationSystem
{
    class TBMath
    {
        public double U, T;
        public TBMath()
        {

        }
        
        //Рассчёт выходных данных TB
        public double[] res(double Tk, double T, double U, double RoTk_1, double V1)
        {
            double RoTk;
            double I, GTk, V;
            double[] ch = new double[5];
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
        

        public TBMath(double U, double T)
        {
            this.U = U;
            this.T = T;
        }

        public double[] res(double Tk, double RoTk_1, double V)
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