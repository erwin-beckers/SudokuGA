using System.Collections.Generic;

namespace GAF
{
    /// <summary>
    /// Public interface for a single chromosome
    /// </summary>
    public interface IChromosome
    {
        /// <summary>
        /// Gets or sets the fitness of the chromosome.
        /// </summary>
        /// <value>
        /// The fitness.
        /// </value>
        double Fitness { get; set; }

        /// <summary>
        /// Gets or sets the genes.
        /// </summary>
        /// <value>
        /// The genes.
        /// </value>
        List<IGene> Genes { get; set; }

        /// <summary>
        /// Clones this chromosome.
        /// </summary>
        /// <returns>cloned version of this chromosome</returns>
        IChromosome Clone();
    }
}