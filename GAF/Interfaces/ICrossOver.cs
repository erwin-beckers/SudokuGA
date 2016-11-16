namespace GAF
{
    /// <summary>
    /// public interface for a Crossover operator
    /// </summary>
    public interface ICrossOver
    {
        /// <summary>
        /// Performs a crossover between 2 parents and returns 2 child
        /// </summary>
        /// <param name="parent1">The first parent.</param>
        /// <param name="parent2">The second parent.</param>
        /// <returns>
        /// the 2 offspring childs
        /// </returns>
        void Process(IChromosome parent1, IChromosome parent2, out IChromosome child1, out IChromosome child2);
    }
}