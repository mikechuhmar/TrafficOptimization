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
        
        public void addInit(double CIR, double Nt, double T)
        {
            this.CIR = CIR;
            this.Nt = Nt;
            this.T = T;
            Console.WriteLine(this.CIR);
        }
        public void addInput(double V)
        {
            this.V = V;
        }
        public void addDecision(double G, double Ro, double R)
        {
            this.G = G;
            this.Ro = Ro;
            this.R = R;
        }
    }
    public struct MultStruct
    {
        public double Q, C;
        public double[] G;
        public double q, L;
        
        public void addInit(double Q, double C)
        {
            this.Q = Q;
            this.C = C;
        }
        public void addInput(double[] G)
        {
            this.G = G;
        }
        public void addDecision(double q, double L)
        {
            this.q = q;
            this.L = L;
        }

    }
    public class Data
    {
        public List<TBStruct> tBs;
        public MultStruct mult;
        public double J;
        public Data()
        {
            tBs = new List<TBStruct>();
        }
        public string output()
        {
            string str = "";
            int tb_i = 1;
            foreach (TBStruct tB in tBs)
            {
                str += "TB №" + tb_i + ": \n" + "CIR = " + tB.CIR + " Nt = " + tB.Nt + " T =  " + tB.T + " V =  " + tB.V + " Ro = " + tB.Ro + " G = " + tB.G + " R = " + tB.R + "\n";
                tb_i++;
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
