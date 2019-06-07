using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationSystem
{
    
    class LBMath
    {
        public LBMath()
        {

        }
        //Вычисление выходных данных LB
        public double[] res(double V_Out, double Tk, double T, double RoTk_LB, double V1, ref LinkedList<double> vs, ref LinkedList<double> Gi_f)
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
        public double[] res(double S, double Tk, double B, double b, double V, ref LinkedList<double> buff_list)
        {
            double GTk = 0;
            double[] ch = new double[4];
            double F;

            if ((buff_list.ToArray().Sum() + V) < B)
            {
                buff_list.AddFirst(V);
            }
            else ch[3] = V;
            int y = 20;
            double V_Out_Here = S;

            if (buff_list.Count != 0)
            {
                while ((buff_list.Count != 0) && (V_Out_Here > 0))
                {
                    //ch[0] = V_Out;
                    if (buff_list.Last.Value <= S)
                    {
                        //ch[0] = 100;
                        GTk += buff_list.Last.Value;
                        S = S - buff_list.Last.Value;
                        buff_list.RemoveLast();
                    }
                    else
                    {
                        if ((S > y) && (buff_list.Last.Value > y))
                        {
                            //ch[0] = 100;
                            F = buff_list.Last.Value - S;
                            buff_list.RemoveLast();
                            buff_list.AddLast(F);
                            GTk += S;
                            V_Out_Here = 0;
                        }
                        else break;
                    }
                }
            }
            ch[0] = GTk;
            ch[1] = V;
            ch[2] = buff_list.ToArray().Sum();
            return ch;
        }
    }
}
