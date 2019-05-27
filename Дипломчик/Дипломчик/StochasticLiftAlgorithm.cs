using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    class StochasticLiftAlgorithm: Method
    {
        int amIterations;
        int amInternalIterations;
        public StochasticLiftAlgorithm(int amParams, int amIterations, int amInternalIterations, Function func, GenVectorFunction genVectorFunction): base(amParams, func, genVectorFunction)
        {
            this.amIterations = amIterations;
            this.amInternalIterations = amInternalIterations;
        }
        public StochasticLiftAlgorithm(int amParams, int amIterations, int amInternalIterations, Function func) : base(amParams, func)
        {
            this.amIterations = amIterations;
            this.amInternalIterations = amInternalIterations;
        }
        public Vector result()
        {
            Random rnd = new Random();
            Vector vector = new Vector(amParams);
            Vector res = genVectorFunction(rnd); 
            for (int i = 1; i < amIterations; i++)
            {
                vector = genVectorFunction(rnd);
                for (int j = 1; j < amInternalIterations; j++)
                {
                    Vector next = new Vector(amParams);
                    for (int k = 0; k < amParams; k++)
                    {
                        next[k] = rnd.Next(-(int)vector[k] / 10, (int)vector[k] / 10) * vector[k];
                    }
                    if (func(vector) > func(next))
                        vector = new Vector(next);


                }
                if (func(res) > func(vector))
                    res = new Vector(vector);


            }
            return res;
        }
    }
}
