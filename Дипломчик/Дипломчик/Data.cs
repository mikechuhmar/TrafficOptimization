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
        public double ro, G;
    }
    public struct MultStruct
    {
        public double Q, C;
        public double[] G;
        public double q, L;
    }
    public class Data
    {
        public List<TBStruct> tBs;
        public MultStruct mult;
    }
    
}
