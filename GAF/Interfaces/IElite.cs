namespace GAF
{
    /// <summary>
    /// Public interface for the Elite operator
    /// </summary>
    public interface IElite
    {
        /// <summary>
        /// Performs the elite operator.
        /// </summary>
        /// <param name="currentPopulation">The current population.</param>
        /// <param name="nextPopulation">The next population.</param>
        void Process(Population currentPopulation, Population nextPopulation);
    }
}