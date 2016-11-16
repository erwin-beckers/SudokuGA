namespace GAF
{
    /// <summary>
    /// The main class for performing the genetic algorithm
    /// </summary>
    public class GeneticAlgorithm
    {
        /// <summary>
        /// The elite operator to use
        /// </summary>
        private IElite _elite;

        /// <summary>
        /// The mutate operator to use
        /// </summary>
        private IMutate _mutate;

        /// <summary>
        /// The crossover operator to use
        /// </summary>
        private ICrossOver _crossover;

        /// <summary>
        /// The diversify operator to use
        /// </summary>
        private IDiversify _diversify;

        /// <summary>
        /// Runs the genetic algorithm until we found a solution
        /// </summary>
        /// <param name="population">The initial population.</param>
        /// <param name="selection">The selection operator .</param>
        /// <param name="fitnessCalculator">The fitness calculator</param>
        public void Run(Population population, ISelection selection, IFitness fitnessCalculator, IGenerationCallback callback)
        {
            int generation = 0;
            while (!population.Finished)
            {
                callback.OnStart(generation);
                // calculate fitness of all chromosones in the population
                population.Calculate(fitnessCalculator, generation);

                double bestFitness = population[0].Fitness;

                // create a new popuplation based on the current population
                population = selection.CreateNewPopulation(population, _elite, _mutate, _crossover, _diversify);

                callback.OnEnd(generation, bestFitness);
                generation++;
            }
        }

        /// <summary>
        /// Adds the specified diversify operator
        /// </summary>
        /// <param name="diversify">The diversify operator</param>
        public void Add(IDiversify diversify)
        {
            _diversify = diversify;
        }
        /// <summary>
        /// Adds the specified elite operator
        /// </summary>
        /// <param name="elite">The elite operator</param>
        public void Add(IElite elite)
        {
            _elite = elite;
        }

        /// <summary>
        /// Adds the specified mutate operator
        /// </summary>
        /// <param name="elite">The mutate operator</param>
        public void Add(IMutate mutate)
        {
            _mutate = mutate;
        }

        /// <summary>
        /// Adds the specified crossover operator
        /// </summary>
        /// <param name="elite">The crossover operator</param>
        public void Add(ICrossOver crossover)
        {
            _crossover = crossover;
        }
    }
}