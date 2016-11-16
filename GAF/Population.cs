using System.Collections.Generic;
using System.Threading.Tasks;

namespace GAF
{
    /// <summary>
    /// Class which holds a population of Chromosomes
    /// </summary>
    public class Population : List<IChromosome>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Population"/> class.
        /// </summary>
        public Population()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Population"/> class.
        /// </summary>
        /// <param name="population">The population.</param>
        public Population(List<IChromosome> population)
        {
            foreach (var chromosome in population)
            {
                Add(chromosome.Clone());
            }
        }

        /// <summary>
        /// Gets a value indicating whether this calculation is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if finished; otherwise, <c>false</c>.
        /// </value>
        public bool Finished { get; internal set; }

        /// <summary>
        /// Calculates the fitness for all chromosones in this population
        /// </summary>
        /// <param name="fitnessCalculator">The fitness.</param>
        /// <param name="generation">The generation.</param>
        internal void Calculate(IFitness fitnessCalculator, int generation)
        {
            // calculate fitness for all chromosones in parallel
            var tasks = new List<Task>();
            foreach (var chromosome in this)
            {
                tasks.Add(Task.Run(() =>
                {
                    bool finished;
                    chromosome.Fitness = fitnessCalculator.CalculateFitness(chromosome, generation, out finished);
                    if (finished) Finished = true;
                }));
            }

            // wait until all fitnesses are calculated
            Task.WaitAll(tasks.ToArray());

            // sort chromosones on descending fitness
            this.Sort(new ChromosomeSorter());
        }
    }
}