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

        //Конструктор
        public StochasticLiftAlgorithm(int amParams, int amIterations, int amInternalIterations, Function func, GenVectorFunction genVectorFunction, Vector max): base(amParams, func, genVectorFunction, max)
        {
            this.amIterations = amIterations;
            this.amInternalIterations = amInternalIterations;
        }
        public StochasticLiftAlgorithm(int amParams, int amIterations, int amInternalIterations, Function func) : base(amParams, func)
        {
            this.amIterations = amIterations;
            this.amInternalIterations = amInternalIterations;
        }

        //Результат
        public Vector result()
        {
            Random rnd = new Random();
            Vector vector = new Vector(amParams);
            //Создание начального решения
            Vector res = genVectorFunction(rnd); 
            for (int i = 1; i < amIterations; i++)
            {
                vector = new Vector(genVectorFunction(rnd));
                //Алгоритм подъёма
                for (int j = 1; j < amInternalIterations; j++)
                {
                    Vector next = new Vector();
                    int amMod = rand.Next(1, amParams);
                    //for (int k = 0; k < amParams; k++)
                    //{
                    //    next.Add(rnd.Next(-(int)vector[k] , (int)vector[k]) + vector[k]);
                    //}
                    for (int k = 0; k < amParams; k++)
                    {
                        next.Add(vector[k]);
                    }
                    for (int k = 0; k < amMod; k++)
                    {
                        int number = rand.Next(0, amParams);
                        next[number] = rand.Next(0, (int)max[number]);

                        
                    }
                    if (func(vector) > func(next))
                        vector = new Vector(next);
                    Console.WriteLine("п: v = " + vector.ToString() + "n = " + next.ToString() + "j = " + func(vector) + " " + func(next));


                }
                if (func(res) > func(vector))
                    res = new Vector(vector);
                Console.WriteLine("сп: " + res.ToString());

            }
            return res;
        }
    }
}
