
using Дипломчик;
using System.Linq;
using System;

public delegate double Function(Vector x);

public delegate Vector GenVectorFunction(Random rand);

public class Functions
{

    public static Vector genVector(Random rand)
    {
        
        Data data = Static.dataList.Last();
        Vector vector = new Vector();

        for(int i = 0; i < data.tBs.Count; i++)
        {
            int U = rand.Next(1, (int)data.tBs[i].T);
            
            vector.Add(U);
            
        }
        return vector;
    }

    public static double J(Vector vector)
    {
        Data data = Static.dataList.Last();
        
        double alfa = 5, beta = 2, gamma = 1;
        double res = 0;
        double[] G = new double[data.tBs.Count];
        double[] R = new double[data.tBs.Count];
        for (int i = 0; i < vector.Count - 1; i++)
        {
            double U = vector[i];
            TBStruct tBStruct = data.tBs[i];
            double T = tBStruct.T;
            double V = tBStruct.V;
            TBMath_2 tB = new TBMath_2(U, T);
            int indexLastData = Static.dataList.Count - 1;
            double Ro_prev = data.tBs[i].Ro_prev;
            //if (indexLastData > 0)
            //    Ro_prev = data.tBs[k].Ro;
            //else
            //    Ro_prev = data.tBs[k].T;
            double[] M = tB.M(0, Ro_prev, V);
            tBStruct.addDecision(M[0], M[3], M[4]);
            data.tBs[i] = tBStruct;
            G[i] = M[0];
            

        }
        MplexMath_2 mplex = new MplexMath_2(data.mult.C, data.mult.Q);
        double[] MX = mplex.MX(G);
        data.mult.addDecision(MX[1], MX[0]);
        //Console.WriteLine("q = " + MX[1]);
        //Console.WriteLine("_L = " + data.mult.L);
        res += alfa * Static.dataList.Sum(x => x.mult.L) + beta * Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + gamma * Static.dataList.Sum(x => x.mult.q);
        data.J = res;
        //Console.WriteLine(res);
        return res;
    }
    
}
