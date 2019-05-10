using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public struct TBStruct
    {
        public double CIR, Nt, T;
        public double V;
        public double Ro, G, R;
        public TBStruct(double CIR, double Nt, double T, double V, double Ro, double G, double R)
        {
            this.CIR = CIR;
            this.Nt = Nt;
            this.T = T;
            this.V = V;
            this.Ro = Ro;
            this.G = G;
            this.R = R;
        }
    }
    public struct MultStruct
    {
        public double Q, C;
        public double[] G;
        public double q, L;
        public MultStruct(double Q, double C, double [] G, double q, double L)
        {
            this.Q = Q;
            this.C = C;
            this.G = G;
            this.q = q;
            this.L = L;
        }

    }
    public class Data
    {
        public List<TBStruct> tBs;
        public MultStruct mult;
        public Data()
        {
            tBs = new List<TBStruct>();
        }
        public string output()
        {
            string str = "";
            foreach (TBStruct tB in tBs)
            {
                str += "TB №" + tBs.IndexOf(tB).ToString() + ": \n" + "CIR = " + tB.CIR + " Nt = " + tB.Nt + " T =  " + tB.T + " V =  " + tB.V + " Ro = " + tB.Ro + " G = " + tB.G + " R = " + tB.R + "\n";
            }
            str += "Multiplexor: \n" + "Q = " + mult.Q + " C = " + mult.C + " G = ";
            for (int i = 0; i < mult.G.Length; i++)
            {
                str += mult.G[i] + " ";
            }
            str += " q = " + mult.q + " L = " + mult.L;
            str += "\n";
            return str;

        }
    }
    
}
