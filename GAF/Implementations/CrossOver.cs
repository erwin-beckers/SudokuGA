using System;

namespace GAF
{
    /// <summary>
    /// Base class implementing a simple crossover operator
    /// </summary>
    /// <seealso cref="GAF.ICrossOver" />
    public class CrossOver : ICrossOver
    {
        private readonly double _crossOverProbabilty;
        private static Random _rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossOver"/> class.
        /// </summary>
        /// <param name="crosssOverProbabilty">The crosss over probabilty.</param> 
        public CrossOver(double crosssOverProbabilty = 0.65d)
        {
            if (crosssOverProbabilty < 0 || crosssOverProbabilty > 1)
                throw new ArgumentOutOfRangeException("crosssOverProbabilty");
            _crossOverProbabilty = crosssOverProbabilty;
        }

        /// <summary>
        /// Performs a crossover between 2 parents and returns 2 child
        /// </summary>
        /// <param name="parent1">The first parent.</param>
        /// <param name="parent2">The second parent.</param>
        /// <param name="child1">the first offspring of the 2 parents</param>
        /// <param name="child2">the 2nd offspring of the 2 parents</param>
        public void Process(IChromosome parent1, IChromosome parent2, out IChromosome child1, out IChromosome child2)
        {
            // check if we need to do a crossover
            var val = _rnd.NextDouble();
            if (val > _crossOverProbabilty)
            {
                // no, then simply return the parents
                child1 = parent1;
                child2 = parent2;
                return;
            }

            // do the crossover
            DoCrossOver(parent1, parent2, out child1, out child2);
        }

        /// <summary>
        /// Performs a simple crossover of 2 parents by selecting random genes from both parent.
        /// </summary>
        /// <param name="parent1">The parent1.</param>
        /// <param name="parent2">The parent2.</param>
        /// <param name="child1">the first offspring of the 2 parents</param>
        /// <param name="child2">the 2nd offspring of the 2 parents</param>
        protected virtual void DoCrossOver(IChromosome parent1, IChromosome parent2, out IChromosome child1, out IChromosome child2)
        {
            child1 = parent1.Clone();
            child2 = parent2.Clone();

            var x = _rnd.Next() % parent1.Genes.Count;
            for (var i = 0; i < x; ++i)
            {
                child1.Genes[i] = parent2.Genes[i].Clone();
            }

            x = _rnd.Next() % parent2.Genes.Count;
            for (var i = 0; i < x; ++i)
            {
                child2.Genes[i] = parent1.Genes[i].Clone();
            }
        }
    }
}