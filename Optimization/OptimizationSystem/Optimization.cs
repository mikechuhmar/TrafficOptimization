using OptimizationSystem;
using System.Linq;
using System;
using System.Collections.Generic;
public delegate double Function(Vector x);
public delegate Vector GenVectorFunction(Random rand);
public class Functions
{
    //Генерация векиора, подходящего по условиям
    public static Vector genVector(Random rand)
    {        
        Data data = Static.dataList.Last();
        Vector vector = new Vector();
        for(int i = 0; i < Static.TB_Count; i++)
        {
            int U = rand.Next(0, (int)data.tBs[i].T);            
            vector.Add(U);            
        }
        for (int i = 0; i < Static.LB_Count; i++)
        {
            int U = rand.Next(0, (int)data.lBs[i].B);
            vector.Add(U);
        }
        Console.WriteLine(vector);
        return vector;
    }
    //Целевая функция
    public static double J(Vector vector)
    {
        Data data = Static.dataList.Last();
        double q_prev = 0;
        if(Static.dataList.Count > 1)
            q_prev = Static.dataList[Static.dataList.Count - 2].mult.q;
        double[] G = new double[Static.LB_Count + Static.TB_Count];
        for (int i = 0; i < Static.TB_Count; i++)
        {
            double U = vector[i];
            TBStruct tBStruct = data.tBs[i];
            double T = tBStruct.T;
            double V = tBStruct.V;
            int indexLastData = Static.dataList.Count - 1;
            double Ro_prev = data.tBs[i].Ro_prev;
            double[] TBRes = TBStruct.compute(T, U, Ro_prev, V);
            tBStruct.addDecision(TBRes[0], TBRes[3], TBRes[4]);
            data.tBs[i] = tBStruct;
            G[i] = TBRes[0];         

        }
        for (int i = 0; i < Static.LB_Count; i++)
        {
            double S = vector[i + Static.TB_Count];
            LBStruct lBStruct = data.lBs[i];
            double B = lBStruct.B;
            double V = lBStruct.V;
            LinkedList<double> buff_list = new LinkedList<double>(lBStruct.buff_list);
            int indexLastData = Static.dataList.Count - 1;            
            double[] LBRes = LBStruct.compute(S, B, V, buff_list);
            lBStruct.addDecision(LBRes[0], LBRes[3], LBRes[2]);
            data.lBs[i] = lBStruct;
            G[i + Static.TB_Count] = LBRes[0];
        }        
        double[] MultRes = MultStruct.compute(G, data.mult.Q, data.mult.C, q_prev);
        data.mult.addDecision(MultRes[1], MultRes[0], MultRes[3]);
        double res = Static.alpha * Static.dataList.Sum(x => x.mult.L) + Static.beta * Static.dataList.Sum(x => x.tBs.Sum(y => y.R)) + Static.gamma * Static.dataList.Sum(x => x.lBs.Sum(y => y.R)) + Static.delta * Static.dataList.Sum(x => x.lBs.Sum(y => y.b)) + Static.epsilon * Static.dataList.Sum(x => x.mult.q);
        //res = Static.alpha * Static.dataList.Last().mult.L + Static.beta * Static.dataList.Last().tBs.Sum(x => x.R) + Static.gamma * Static.dataList.Last().lBs.Sum(y => y.R) + Static.dataList.Last().lBs.Sum(y => y.b) + Static.epsilon * Static.dataList.Last().mult.q;
        return res;
    }
    
}
