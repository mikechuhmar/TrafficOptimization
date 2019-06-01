
using Дипломчик;
using System.Linq;
using System;
using System.Collections.Generic;

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
        for (int i = 0; i < data.lBs.Count; i++)
        {
            int U = rand.Next(1, (int)data.lBs[i].B);

            vector.Add(U);

        }
        return vector;
    }

    public static double J(Vector vector)
    {
        Data data = Static.dataList.Last();
        double q_prev = 0;
        Data prev;
        if(Static.dataList.Count > 1)
            q_prev = Static.dataList[Static.dataList.Count - 2].mult.q;



        double res = 0;
        double[] G = new double[Static.LB_Count + Static.TB_Count];
        double[] R = new double[Static.LB_Count + Static.TB_Count];
        for (int i = 0; i < Static.TB_Count; i++)
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
        for (int i = 0; i < Static.LB_Count; i++)
        {
            double U = vector[i + Static.LB_Count];
            LBStruct lBStruct = data.lBs[i];
            double T = lBStruct.B;
            double V = lBStruct.V;
            LinkedList<double> B = new LinkedList<double>(lBStruct.B_list);
            LinkedList<double> G_f = new LinkedList<double>(lBStruct.G_list);
            Leaky_Bucket_Algoritm lB = new Leaky_Bucket_Algoritm();
            int indexLastData = Static.dataList.Count - 1;
            
            double[] M = lB.LM(U, 1, T, 1, V, ref B, ref G_f);
            lBStruct.addDecision(M[0], M[3], M[2]);
            data.lBs[i] = lBStruct;
            G[i + Static.TB_Count] = M[0];


        }
        //MplexMath_2 mplex = new MplexMath_2(data.mult.C, data.mult.Q);
        //double[] MX = mplex.MX(G);
        
        double[] MX = MplexMath_2.res(G, data.mult.Q, data.mult.C, q_prev);
        data.mult.addDecision(MX[1], MX[0], MX[3]);
        //Console.WriteLine("q = " + MX[1]);
        //Console.WriteLine("_L = " + data.mult.L);
        //res += Static.alpha * Static.dataList.Sum(x => x.mult.L) + Static.beta * Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + Static.gamma * Static.dataList.Sum(x => x.lBs.Sum(y => y.R)) + Static.delta * Static.dataList.Sum(x => x.lBs.Sum(y => y.b)) + Static.epsilon * Static.dataList.Sum(x => x.mult.q);
        res = Static.alpha * Static.dataList.Last().mult.L + Static.beta * Static.dataList.Last().tBs.Sum(x => x.R) + Static.gamma * Static.dataList.Last().lBs.Sum(y => y.R) + Static.dataList.Last().lBs.Sum(y => y.b) + Static.epsilon * Static.dataList.Last().mult.q;
        //data.J = res;
        //Console.WriteLine(res);
        return res;
    }
    
}
