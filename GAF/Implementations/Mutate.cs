using System;

namespace GAF
{
    /// <summary>
    /// A basic mutation operator
    /// </summary>
    /// <seealso cref="GAF.IMutate" />
    public class Mutate : IMutate
    {
        private readonly double _mutationProbability;
        private static Random _rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Mutate"/> class.
        /// </summary>
        /// <param name="mutationProbability">The mutation probability.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">mutationProbability</exception>
        public Mutate(double mutationProbability = 0.08d)
        {
            if (mutationProbability < 0 || mutationProbability > 1)
                throw new ArgumentOutOfRangeException("mutationProbability");
            _mutationProbability = mutationProbability;
        }

        /// <summary>
        /// Performs the mutation on the chromosome
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        public void Process(IChromosome chromosome)
        {
            var val = _rnd.NextDouble();
            if (val <= _mutationProbability)
            {
                DoMutate(chromosome);
            }
        }

        /// <summary>
        /// Mutates a single gene for a chromosome
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        protected virtual void DoMutate(IChromosome chromosome)
        {
            var x = _rnd.Next() % chromosome.Genes.Count;
            chromosome.Genes[x].Mutate();
        }
    }
}