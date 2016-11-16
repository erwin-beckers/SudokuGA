namespace GAF
{
    /// <summary>
    /// Public interface for a selection operator
    /// </summary>
    public interface ISelection
    {
        /// <summary>
        /// Creates a new population based on the current population
        /// </summary>
        /// <param name="currentPopulation">The current population.</param>
        /// <param name="elite">The elite operator</param>
        /// <param name="mutate">The mutate operator</param>
        /// <param name="crossover">The crossover operator</param>
        /// <param name="diversify">The diversify operator</param>
        /// <returns>New population</returns>
        Population CreateNewPopulation(Population currentPopulation, IElite elite, IMutate mutate, ICrossOver crossover, IDiversify diversify);
    }
}