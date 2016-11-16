namespace GAF
{
    /// <summary>
    /// Public interface for calculating the fitness for a specific chromosome
    /// </summary>
    public interface IFitness
    {
        /// <summary>
        /// Calculates the fitness for a specific chromosome
        /// </summary>
        /// <param name="chromosone">The chromosone.</param>
        /// <param name="generation">The current generation.</param>
        /// <param name="finished">if set to <c>true</c> [finished].</param>
        /// <returns>fitness for the chromosome</returns>
        double CalculateFitness(IChromosome chromosone, int generation, out bool finished);
    }
}