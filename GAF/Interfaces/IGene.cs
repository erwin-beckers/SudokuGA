using System;

namespace GAF
{
    /// <summary>
    /// public inteface for a Gene
    /// </summary>
    public interface IGene
    {
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Cloned instance of this gene</returns>
        IGene Clone();

        /// <summary>
        /// Performs a single mutation on this gene
        /// </summary>
        void Mutate();
    }
}