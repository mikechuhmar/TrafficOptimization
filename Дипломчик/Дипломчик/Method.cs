using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    class Method
    {
        protected Function func;
        protected GenVectorFunction genVectorFunction;
        protected Random rand = new Random();
        protected Vector min, max;
        protected int amParams;
        protected Vector setEdge(Vector vector)
        {
            Vector newVector = new Vector(vector);
            for (int i = 0; i < amParams; i++)
            {

                newVector[i] = (int)vector[i] / (int)max[i] + 1;
            }
            return newVector;
        }
        public Vector default_genVectorFunction(Random rand)
        {
            Random rnd = new Random();
            Vector vector = new Vector();
            for (int j = 0; j < amParams; j++)
            {
                double gen = rnd.Next(0, 100);
                vector.Add(gen);
            }
            return vector;
        }
        public Method(int amParams, Function func, GenVectorFunction genVectorFunction, Vector max)
        {
            this.amParams = amParams;
            this.func = func;
            this.genVectorFunction = genVectorFunction;
            this.max = max;
        }
        public Method(int amParams, Function func)
        {
            this.amParams = amParams;
            this.func = func;
            this.genVectorFunction = default_genVectorFunction;
        }
    }
}
