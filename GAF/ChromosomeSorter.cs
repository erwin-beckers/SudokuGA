using System.Collections.Generic;

namespace GAF
{
    /// <summary>
    /// Class which sorts chromosones by descending fitness
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{GAF.IChromosome}" />
    public class ChromosomeSorter : IComparer<IChromosome>
    {
        /// <summary>
        /// Compares two chromosones and returns a value indicating which has the best fitness.
        /// </summary>
        /// <param name="x">The first chromosone to compare.</param>
        /// <param name="y">The second chromosone to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(IChromosome x, IChromosome y)
        {
            return y.Fitness.CompareTo(x.Fitness);
        }
    }
}