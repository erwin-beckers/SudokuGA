using System;
using System.Collections.Generic;

namespace GAF
{
    /// <summary>
    /// Base class implementing a chromosone
    /// </summary>
    /// <seealso cref="GAF.IChromosome" />
    public class Chromosome : IChromosome
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chromosome"/> class.
        /// </summary>
        public Chromosome()
        {
            Genes = new List<IGene>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chromosome"/> class.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        public Chromosome(Chromosome chromosome)
        {
            Genes = new List<IGene>();
            foreach (var gene in chromosome.Genes)
            {
                Genes.Add(gene.Clone());
            }
        }

        /// <summary>
        /// Gets or sets the genes.
        /// </summary>
        /// <value>
        /// The genes.
        /// </value>
        public List<IGene> Genes { get; set; }

        /// <summary>
        /// Gets or sets the fitness of the chromosome.
        /// </summary>
        /// <value>
        /// The fitness.
        /// </value>
        public double Fitness { get; set; }

        /// <summary>
        /// Clones this chromosome.
        /// </summary>
        /// <returns>
        /// cloned version of this chromosome
        /// </returns>
        public IChromosome Clone()
        {
            return new Chromosome(this);
        }
    }
}