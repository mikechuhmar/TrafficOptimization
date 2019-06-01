using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    class GeneticAlgorithm: Method
    {
        int amIndividuals, amPopulations;
        int amGenes
        {
            get
            {
                return amParams;
            }
            set
            {
                amParams = value;
            }
        }

        List<Vector> population;
        //Конструктор
        public GeneticAlgorithm(int amIndividuals, int amGenes, int amPopulations, Function func, GenVectorFunction genVectorFunction, Vector max): base(amGenes, func, genVectorFunction, max)
        {
            this.amIndividuals = amIndividuals;
            this.amPopulations = amPopulations;
        }
        public GeneticAlgorithm(int amIndividuals, int amGenes, int amPopulations, Function func): base(amGenes, func)
        {
            this.amIndividuals = amIndividuals;
            this.amPopulations = amPopulations;
        }
        
        //Создание начального поколения
        void CreateStartGeneration()
        {
            Random rnd = new Random();
            population = new List<Vector>();
            for (int i = 0; i < amIndividuals; i++)
            {

                Vector chromosome = genVectorFunction(rand);
                
                population.Add(chromosome);
            }
        }


        //Отбор и скрещивание
        void Crossover()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            for (int i = 0; i < amIndividuals; i++)
            {
                //Выбор родителей для размножения 
                int parentIndex1, parentIndex2;
                int parentIndex11, parentIndex12, parentIndex21, parentIndex22;

                //Выбор первого родителя
                parentIndex11 = rnd1.Next(0, amIndividuals);
                parentIndex12 = rnd1.Next(0, amIndividuals);
                if (parentIndex11 == parentIndex12)
                {
                    if (parentIndex12 == amIndividuals - 1)
                        parentIndex12--;
                    else
                        parentIndex12++;
                }
                if (func(population[parentIndex11]) <= func(population[parentIndex12]))
                    parentIndex1 = parentIndex11;
                else
                    parentIndex1 = parentIndex12;

                //Выбор второго родителя
                parentIndex21 = rnd1.Next(0, amIndividuals);
                parentIndex22 = rnd1.Next(0, amIndividuals);
                if (parentIndex21 == parentIndex22)
                {
                    if (parentIndex22 == amIndividuals - 1)
                        parentIndex22--;
                    else
                        parentIndex22++;
                }
                if (func(population[parentIndex21]) <= func(population[parentIndex22]))
                    parentIndex2 = parentIndex21;
                else
                    parentIndex2 = parentIndex22;

                //parentIndex1 = rnd1.Next(0, amIndividuals);
                //parentIndex2 = rnd2.Next(0, amIndividuals);

                //Если оба родителя оказались одной особью
                if (parentIndex1 == parentIndex2)
                {
                    if (parentIndex2 == amIndividuals - 1)
                        parentIndex2--;
                    else
                        parentIndex2++;
                }

                Vector parent1 = new Vector();
                Vector parent2 = new Vector();             

                

                
                parent1 = population[parentIndex1];
                parent2 = population[parentIndex2];
                Vector child1 = new Vector(amGenes);
                Vector child2 = new Vector(amGenes);

                //int crossoverPoint = amGenes / 2;
                //Поиск точки скрещивания
                int crossoverPoint = rand.Next(1, amGenes);

                //Создание новых особей
                for (int j = 0; j < crossoverPoint; j++)
                {
                    child1.Add(parent1[j]);
                    child2.Add(parent2[j]);
                }
                for (int j = crossoverPoint; j < amGenes; j++)
                {
                    child1.Add(parent2[j]);
                    child2.Add(parent1[j]);
                }

                population.Add(child1);
                population.Add(child2);
            }
        }

        //Мутация
        private void Mutation()
        {
            Random rnd = new Random();
            double mutationProbability = 0.33;
            for (int i = amIndividuals; i < population.Count * mutationProbability; i++)
            {
                int numbMutChrom = rnd.Next(amIndividuals, population.Count);
                int numbMutGen = rnd.Next(0, amGenes);
                //population[numbMutChrom][numbMutGen] += rnd.Next(-10, 10) * rnd.NextDouble();
            }
        }

        //Создание нового поколения
        private void CreateNewGeneration()
        {
            var query = population.OrderBy(x => func(x)).ToList();
            query.RemoveRange(amIndividuals, (population.Count) - amIndividuals);
            population = new List<Vector>(query.ToList());
        }

        //Результат алгоритма
        public Vector result()
        {
            int i;
            CreateStartGeneration();
            //CreateNewGeneration();
            for (i = 0; i < amPopulations; i++)
            {
                Vector prevMin = population.First();
                Console.WriteLine("\n" + i.ToString() + ":");
                Console.WriteLine(prevMin.ToString());
                foreach (var p in population)
                {
                    Console.WriteLine(p.ToString());
                    Console.WriteLine(func(p).ToString());
                }

                Crossover();
                Mutation();
                CreateNewGeneration();


            }
            Vector res = population.First();
            
            return res;
        }
    }
}
