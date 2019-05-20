using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public class GeneticAlgorithm
    {
        Function func;
        int amChromosomes, amGenes, amPopulations;
        List<Vector> population;
        public GeneticAlgorithm(int amChromosomes, int amGenes, int amPopulations, Function func)
        {
            this.amChromosomes = amChromosomes;
            this.amGenes = amGenes;
            this.amPopulations = amPopulations;
            this.func = func;

        }
        public GeneticAlgorithm(int amChromosomes, int amGenes, int amPopulations, Vector startPop, Function func)
        {
            this.amChromosomes = amChromosomes;
            this.amGenes = amGenes;
            this.amPopulations = amPopulations;
            this.func = func;

        }
        void CreateStartPopulation()
        {
            Random rnd = new Random();
            population = new List<Vector>();
            for (int i = 0; i < amChromosomes; i++)
            {
                Vector chromosome = new Vector();
                for (int j = 0; j < amGenes; j++)
                {
                    double gen = rnd.Next(0, 100);
                    chromosome.Add(gen);
                }
                population.Add(chromosome);
            }
        }

        void Crossover()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            for (int i = 0; i < amChromosomes; i++)
            {
                //Выбор родителей для размножения (репродукция)
                Vector parent1 = new Vector();
                Vector parent2 = new Vector();
                int parentIndex1, parentIndex2;

                parentIndex1 = rnd1.Next(0, amChromosomes);
                parentIndex2 = rnd2.Next(0, amChromosomes);

                if (parentIndex1 == parentIndex2)
                {
                    if (parentIndex2 == amChromosomes - 1)
                        parentIndex2--;
                    else
                        parentIndex2++;
                }
                parent1 = population[parentIndex1];
                parent2 = population[parentIndex2];
                Vector child1 = new Vector(amGenes);
                Vector child2 = new Vector(amGenes);

                int crossoverPoint = amGenes / 2;

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
        private void Mutation()
        {
            Random rnd = new Random();
            double mutationProbability = 0.33;
            for (int i = amChromosomes; i < population.Count * mutationProbability; i++)
            {
                int numbMutChrom = rnd.Next(amChromosomes, population.Count);
                int numbMutGen = rnd.Next(0, amGenes);
                population[numbMutChrom][numbMutGen] += rnd.Next(-10, 10) * rnd.NextDouble();
            }
        }
        private void Selection()
        {
            var query = population.OrderBy(x => func(x)).ToList();
            query.RemoveRange(amChromosomes, (population.Count) - amChromosomes);
            population = new List<Vector>(query.ToList());
        }
        public Vector result()
        {
            int i;
            CreateStartPopulation();
            Selection();
            for (i = 0; i < amPopulations; i++)
            {
                Vector prevMin = population.First();
                Console.WriteLine(i.ToString() + ":");
                Selection();
                Crossover();
                Mutation();


            }
            Vector res = population.First();
            
            return res;
        }
    }
}
