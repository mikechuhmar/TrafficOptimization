using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public class GeneticAlgorithm 
    {
        private int amChromosomes;
        private int amGenes;
        private int amPopulations;
        private Function func;

        public GeneticAlgorithm(int amChromosomes, int amGenes, int amPopulations, Function func)
        {
            this.amChromosomes = amChromosomes;
            this.amGenes = amGenes;
            this.amPopulations = amPopulations;
            this.func = func;

        }
    }
}
