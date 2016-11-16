using System;

namespace GAF
{
    /// <summary>
    /// Class implementing a tournament selector
    /// </summary>
    /// <seealso cref="GAF.ISelection" />
    public class TournamentSelection : ISelection
    {
        private int _tournamentSize;
        private Random _rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentSelection"/> class.
        /// </summary>
        /// <param name="tournamentSize">Size of the tournament.</param>
        public TournamentSelection(int tournamentSize = 10)
        {
            _tournamentSize = tournamentSize;
        }

        /// <summary>
        /// Creates a new population.
        /// </summary>
        /// <param name="population">The current population.</param>
        /// <param name="elite">The elite operator.</param>
        /// <param name="mutate">The mutate operator.</param>
        /// <param name="crossover">The crossover operator.</param>
        /// <returns></returns>
        public Population CreateNewPopulation(Population population, IElite elite, IMutate mutate, ICrossOver crossover)
        {
            IChromosome parent1, parent2;
            IChromosome child1 = null, child2 = null;

            // create a new population
            var nextPopulation = new Population();

            // copy all elites to the new population
            elite?.Process(population, nextPopulation);

            // while next population is not filled completely
            while (nextPopulation.Count < population.Count)
            {
                // select 2 parents
                DoTournament(population, out parent1, out parent2);

                // perform crossover so we get 2 children
                crossover?.Process(parent1, parent2, out child1, out child2);

                // mutate both children
                mutate?.Process(child1);
                mutate?.Process(child2);

                // and add the children to the next population
                nextPopulation.Add(child1);
                if (nextPopulation.Count < population.Count) nextPopulation.Add(child2);
            }
            return nextPopulation;
        }

        /// <summary>
        /// Returns 2 parents from the population based on tournament selection.
        /// </summary>
        /// <param name="population">The population.</param>
        /// <param name="parent1">The first parent.</param>
        /// <param name="parent2">The second parent.</param>
        private void DoTournament(Population population, out IChromosome parent1, out IChromosome parent2)
        {
            // we start with nothing
            parent1 = null;
            parent2 = null;

            // hold a tournament 
            for (var i = 0; i < _tournamentSize; ++i)
            {
                // get 2 random parents
                var r1 = _rnd.Next(population.Count);
                var r2 = _rnd.Next(population.Count);
                while (r1 == r2) r2 = _rnd.Next(population.Count);

                if (parent1 == null || parent2 == null)
                {
                    // if we have no parents yet, then simple use these 2 random parents
                    parent1 = population[r1];
                    parent2 = population[r2];
                }
                else
                {
                    // Otherwise we select the best parents based on their fitness
                    parent1 = parent1.Fitness > population[r1].Fitness ? parent1 : population[r1];
                    parent2 = parent2.Fitness > population[r2].Fitness ? parent2 : population[r2];
                }
            }
        }
    }
}