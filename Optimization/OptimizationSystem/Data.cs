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
    }
    public struct LBStruct
    {
        public double B, b_prev, S;
        public double V;
        public double b, G, R;
        public LinkedList<double> B_list, G_list;
        //Начальная инициализация
        public void addInit(double B, LinkedList<double> B_list, LinkedList<double> G_list)
        {
            this.B = B;
            this.B_list = new LinkedList<double>(B_list);
            this.G_list = new LinkedList<double>(G_list);
            b_prev = B_list.Sum();
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
