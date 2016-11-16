using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAF;

namespace SudokuSolver
{
    public class SudokuDiversify : Diversify
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuDiversify"/> class.
        /// </summary>
        /// <param name="replacePopulationPercentage">The replace population percentage.</param>
        public SudokuDiversify(double replacePopulationPercentage)
            : base(replacePopulationPercentage)
        {
        }

        /// <summary>
        /// Creates a new random chromosome.
        /// </summary>
        /// <returns></returns>
        public override IChromosome CreateRandomChromosome()
        {
            var chromosome = new Chromosome();
            for (var row = 0; row < 9; ++row)
            {
                chromosome.Genes.Add(new SudokuGene());
            }
            return chromosome;
        }

    }
}
