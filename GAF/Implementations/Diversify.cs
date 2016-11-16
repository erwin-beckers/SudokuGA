using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAF
{
    public abstract class Diversify : IDiversify
    {
        double _replacePopulationPercentage;
        /// <summary>
        /// Initializes a new instance of the <see cref="Diversify"/> class.
        /// </summary>
        /// <param name="replacePopulationPercentage">The replace population percentage.</param>
        public Diversify(double replacePopulationPercentage = 0.1)
        {
            _replacePopulationPercentage = replacePopulationPercentage;
        }

        /// <summary>
        /// Adds new random chromosone to the next population to make sure the population is diversified enough.
        /// </summary>
        /// <param name="nextPopulation">The next population.</param>
        /// <param name="populationSize">Size of the population.</param>
        public void Process(Population nextPopulation, int populationSize)
        {
            var amount = (int)(populationSize * _replacePopulationPercentage);
            for (var i = 0; i < amount; ++i)
            {
                var chromosome = CreateRandomChromosome();
                if (chromosome != null)
                    nextPopulation.Add(chromosome);
                if (nextPopulation.Count >= populationSize) return;
            }
        }

        /// <summary>
        /// Creates a new random chromosome.
        /// </summary>
        /// <returns></returns>
        public abstract IChromosome CreateRandomChromosome();
    }
}
