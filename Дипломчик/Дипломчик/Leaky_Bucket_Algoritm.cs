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

            if ((vs.ToArray().Sum() + V1) < T)
            {
                vs.AddFirst(V1);
            }
            else ch[3] = V1;
            if (vs.Count != 0)
            {
                while ((vs.Count != 0) && (vs.Last.Value < V_Out))
                {
                    GTk += vs.Last.Value;
                    Gi_f.AddLast(vs.Last.Value);
                    V_Out = V_Out - vs.Last.Value;
                    vs.RemoveLast();
                }
            }

            ch[0] = GTk;
            ch[1] = V1;
            ch[2] = vs.ToArray().Sum();

            return ch;
        }
    }
}
