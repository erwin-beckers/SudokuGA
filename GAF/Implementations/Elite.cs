using System;

namespace GAF
{
    /// <summary>
    /// Implements a basic elite operator
    /// </summary>
    /// <seealso cref="GAF.IElite" />
    public class Elite : IElite
    {
        private readonly double _elitePercentage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Elite"/> class.
        /// </summary>
        /// <param name="elitePercentage">The elite percentage.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">elitePercentage</exception>
        public Elite(double elitePercentage = 0.1d)
        {
            if (elitePercentage < 0 || elitePercentage > 1)
                throw new ArgumentOutOfRangeException("elitePercentage");
            _elitePercentage = elitePercentage;
        }

        /// <summary>
        /// Performs the elite operator.
        /// This will copy the best chromosones from the current population to the next population
        /// </summary>
        /// <param name="currentPopulation">The current population.</param>
        /// <param name="nextPopulation">The next population.</param>
        public virtual void Process(Population currentPopulation, Population nextPopulation)
        {
            var amountToKeep = (int)(_elitePercentage * currentPopulation.Count);
            for (var x = 0; x < amountToKeep; ++x)
            {
                nextPopulation.Add(currentPopulation[x].Clone());
            }
        }
    }
}