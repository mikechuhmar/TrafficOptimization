using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    
    class Leaky_Bucket_Algoritm
    {
        public Leaky_Bucket_Algoritm()
        {

        }
        public double[] LM(double V_Out, double Tk, double T, double RoTk_LB, double V1, ref LinkedList<double> vs, ref LinkedList<double> Gi_f)
        //public double[] M(double volume, double S, double Ro, double V1)
        {

            double GTk = 0;
            double[] ch = new double[4];
            double F;

            if ((vs.ToArray().Sum() + V1) < T)
            {
                vs.AddFirst(V1);
            }
            else ch[3] = V1;
            int y = 20;
            double V_Out_Here = V_Out;

            if (vs.Count != 0)
            {
                while ((vs.Count != 0) && (V_Out_Here > 0))
                {
                    //ch[0] = V_Out;
                    if (vs.Last.Value <= V_Out)
                    {
                        //ch[0] = 100;
                        GTk += vs.Last.Value;
                        Gi_f.AddLast(vs.Last.Value);
                        V_Out = V_Out - vs.Last.Value;
                        vs.RemoveLast();
                    }
                    else
                    {
                        if ((V_Out > y) && (vs.Last.Value > y))
                        {
                            //ch[0] = 100;
                            F = vs.Last.Value - V_Out;
                            vs.RemoveLast();
                            vs.AddLast(F);
                            GTk += V_Out;
                            Gi_f.AddLast(V_Out);
                            V_Out_Here = 0;
                        }
                        else break;
                    }
                }
            }

            ch[0] = GTk;
            ch[1] = V1;
            ch[2] = vs.ToArray().Sum();

            return ch;
        }
    }
}
