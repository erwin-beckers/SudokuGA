using GAF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    /// <summary>
    /// Gene specific for a sudoku
    /// This gene will contain a single row of the sudoku
    /// </summary>
    /// <seealso cref="GAF.IGene" />
    public class SudokuGene : IGene
    {
        static Random _rnd = new Random();

        /// <summary>
        /// The values for the 9 colums
        /// </summary>
        public int[] Columns = new int[9];

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuGene"/> class.
        /// </summary>
        public SudokuGene()
        {
            for (var i = 0; i < 9; ++i)
            {
                Columns[i] = (_rnd.Next(9)) + 1;
            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuGene"/> class.
        /// </summary>
        /// <param name="gene">The gene.</param>
        public SudokuGene(SudokuGene gene)
        {
            for (var i = 0; i < 9; ++i)
                Columns[i] = gene.Columns[i];
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// Cloned instance of this gene
        /// </returns>
        public IGene Clone()
        {
            return new SudokuGene(this);
        }

        /// <summary>
        /// Performs a single mutation on this gene
        /// We simply put a random value (1-9) in 3  columns
        /// </summary>
        public void Mutate()
        {
            var pos = _rnd.Next(9);
            Columns[pos] = (_rnd.Next(9)) + 1;
        }
    }
}
