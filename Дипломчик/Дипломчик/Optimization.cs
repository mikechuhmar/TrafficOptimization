
using Дипломчик;
using System.Linq;
public delegate double Function(Vector x);



public class Functions
{

    

    public static double J(Vector vector)
    {
        double alfa = 2, beta = 2, gamma = 2;
        double res = 0;
        double[] G = new double[Static.dataList.Last().tBs.Count];
        double[] R = new double[Static.dataList.Last().tBs.Count];
        for (int i = 0, k=0; i < vector.Count - 1; i+=2, k++)
        {
            double CIR = vector[i];
            double Nt = vector[i + 1];
            TBStruct tBStruct = Static.dataList.Last().tBs[k];
            double T = tBStruct.T;
            double V = tBStruct.V;
            TBMath_2 tB = new TBMath_2(CIR, Nt, T);
            int indexLastData = Static.dataList.Count - 1;
            double Ro_prev;
            if (indexLastData > 0)
                Ro_prev = Static.dataList[indexLastData - 1].tBs[k].Ro;
            else
                Ro_prev = 0;
            double[] M = tB.M(0, Ro_prev, V);
            Static.dataList.Last().tBs[k].addDecision(M[0], M[3], M[4]);
            G[k] = M[0];
            

        }
        MplexMath_2 mplex = new MplexMath_2(Static.dataList.Last().mult.C, Static.dataList.Last().mult.Q);
        double[] MX = mplex.MX(G);
        Static.dataList.Last().mult.addDecision(MX[1], MX[0]);
        res += alfa * Static.dataList.Sum(x => x.mult.L) + beta * Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + gamma * Static.dataList.Sum(x => x.mult.q);
        Static.dataList.Last().J = res;
        return res;
    }
    
}
