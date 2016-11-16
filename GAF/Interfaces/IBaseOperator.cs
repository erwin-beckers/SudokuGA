namespace GAF
{
    /// <summary>
    /// Public interface for operators working on chromosomes
    /// </summary>
    public interface IChromosomeOperator
    {
        /// <summary>
        /// Processes the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        void Process(IChromosome chromosome);
    }
}