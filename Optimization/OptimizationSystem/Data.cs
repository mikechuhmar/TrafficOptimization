using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationSystem
{
    //Структура маркеоной корзины
    public struct TBStruct
    {
        public double T, U, Ro_prev;
        public double V;
        public double Ro, G, R;
        //Начальная инициализация
        public void addInit(double T, double Ro_prev)
        {            
            this.T = T;
            this.Ro_prev = Ro_prev;
        }
        //Добавление поступающего трафика
        public void addInput(double V)
        {
            this.V = V;
        }
        //Добавление оптимальных параметров
        public void addOptimized(double U)
        {
            this.U = U;
        }
        //Добавление полученных выходных данных
        public void addDecision(double G, double Ro, double R)
        {
            this.G = G;
            this.Ro = Ro;
            this.R = R;
        }
        public static double [] compute(double T, double U, double Ro_prev, double V)
        {
            double RoTk;
            double I, GTk;
            double[] ch = new double[5];
            RoTk = Ro_prev + Math.Min(U, (T - Ro_prev));
            if (V <= (Ro_prev + Math.Min(U, (T - Ro_prev))))
                I = 1;
            else I = 0;
            GTk = V * I;
            ch[0] = GTk;
            ch[1] = V;
            ch[2] = RoTk;
            ch[4] = V - GTk;
            RoTk = RoTk - GTk;
            Ro_prev = RoTk;

            ch[3] = Ro_prev;
            return ch;
        }
    }
    public struct LBStruct
    {
        public double B, b_prev, S;
        public double V;
        public double b, G, R;
        public LinkedList<double> buff_list;
        //Начальная инициализация
        public void addInit(double B, LinkedList<double> buff_list)
        {
            this.B = B;
            this.buff_list = new LinkedList<double>(buff_list);
            b_prev = buff_list.Sum();
        }
        //Добавление поступающего трафика
        public void addInput(double V)
        {
            this.V = V;
        }
        //Добавление оптимальных параметров
        public void addOptimized(double S)
        {
            this.S = S;
        }
        //Добавление полученных выходных данных
        public void addDecision(double G,  double R, double b)
        {
            this.G = G;
            this.R = R;
            this.b = b;            
        }

        public static double [] compute(double S, double B, double V, LinkedList<double> buff_list)
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
                    if (buff_list.Last.Value <= S)
                    {
                        GTk += buff_list.Last.Value;
                        S = S - buff_list.Last.Value;
                        buff_list.RemoveLast();
                    }
                    else
                    {
                        if ((S > y) && (buff_list.Last.Value > y))
                        {
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
    public struct MultStruct
    {
        public double Q, C;
        public double[] G;
        public double q, L, outG;
        //Начальная инициализация
        public void addInit(double Q, double C)
        {
            this.Q = Q;
            this.C = C;
        }
        //Добавление поступающего трафика
        public void addInput(double[] G)
        {
            this.G = new double[G.Length];
            for (int i = 0; i<G.Length; i++)
                this.G[i] = G[i];           
            
        }
        //Добавление полученных выходных данных
        public void addDecision(double q, double L, double outG)
        {
            this.q = q;
            this.L = L;
            this.outG = outG;
        }
        public static double[] compute(double[] G, double Q, double C, double q_prev)
        {
            double SUMM_Gi = G.Sum();


            double q = Math.Max(q_prev - C, 0) + Math.Min(SUMM_Gi, Q - Math.Max(q_prev - C, 0));//текущая заполненность буффера

            //вычисление Ltk
            double L = SUMM_Gi - Math.Min(SUMM_Gi, Q - Math.Max(q_prev - C, 0)); //потери на мультиплексоре
                                                                                     //конец - вычисление Ltk

            double[] res = new double[4];
            res[0] = L;
            res[1] = q;
            res[2] = Q;
            res[3] = Math.Min(q_prev, C);
            return res;
        }
    }
    public class Data
    {
        public List<TBStruct> tBs;
        public List<LBStruct> lBs;
        public MultStruct mult;
        public double J = double.MinValue;
        public Data()
        {
            tBs = new List<TBStruct>();
            lBs = new List<LBStruct>();
        }
        //public string output()
        //{
        //    string str = "";
        //    int tb_i = 1;
        //    int lb_i = 1;
        //    foreach (TBStruct tB in tBs)
        //    {
        //        str += "TB №" + tb_i + ": \n" + "Ro_prev = " + tB.Ro_prev + " U = " + tB.U + " T =  " + tB.T + " V =  " + tB.V + " Ro = " + tB.Ro + " G = " + tB.G + " R = " + tB.R + "\n";
        //        tb_i++;
        //    }
        //    foreach (LBStruct lB in lBs)
        //    {
        //        str += "LB №" + lb_i + ": \n" + "b_prev = " + lB.b_prev + " S = " + lB.S + " T =  " + lB.B + " V =  " + lB.V + " b = " + lB.b + " G = " + lB.G + " R = " + lB.R + "\n";
        //        lb_i++;
        //    }
        //    str += "Multiplexor: \n" + "Q = " + mult.Q + " C = " + mult.C + " G = ";
        //    for (int i = 0; i < mult.G.Length; i++)
        //    {
        //        str += mult.G[i] + " ";
        //    }
        //    str += " q = " + mult.q + " L = " + mult.L + " out = " + mult.outG;
        //    str += "\n";
        //    return str;

        //}
    }
    
    
}
