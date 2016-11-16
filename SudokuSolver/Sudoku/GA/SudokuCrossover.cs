using System;
using GAF;

namespace SudokuSolver
{
    /// <summary>
    /// Cross over operator specific for a sudoku
    /// </summary>
    /// <seealso cref="GAF.CrossOver" />
    public class SudokuCrossOver : CrossOver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuCrossOver"/> class.
        /// </summary>
        /// <param name="crosssOverProbabilty">The crosss over probabilty.</param>
        public SudokuCrossOver(double crosssOverProbabilty = 0.65d)
            : base(crosssOverProbabilty)
        {
        }

        /// <summary>
        /// Performs a crossover of 2 parents
        /// The first child will contain all the best rows of the 2 parents
        /// The second child will contain all the best columns of the 2 parents
        /// </summary>
        /// <param name="parent1">The first parent1.</param>
        /// <param name="parent2">The second parent2.</param>
        /// <param name="child1">the first offspring of the 2 parents</param>
        /// <param name="child2">the 2nd offspring of the 2 parents</param>
        protected override void DoCrossOver(IChromosome parent1, IChromosome parent2, out IChromosome child1, out IChromosome child2)
        {
            // child 1 receives the best rows of parent 1 & parent 2
            child1 = parent1.Clone();
            for (var row = 0; row < 9; ++row)
            {
                var gene1 = (SudokuGene)parent1.Genes[row];
                var gene2 = (SudokuGene)parent2.Genes[row];
                if (RowScore(gene2) > RowScore(gene1))
                {
                    child1.Genes[row] = gene2.Clone();
                }
            }

            // child 2 receives the best colums of parent 1 & parent 2
            child2 = parent1.Clone();
            for (var col = 0; col < 9; ++col)
            {
                if (ColumnScore(parent2, col) > ColumnScore(parent1, col))
                {
                    for (var row = 0; row < 9; row++)
                    {
                        var gene2 = (SudokuGene)parent2.Genes[row];
                        var geneChild = (SudokuGene)child2.Genes[row];
                        geneChild.Columns[col] = gene2.Columns[col];
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the score for a column.
        /// The score simply is the number of unique values used in a column
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <param name="col">The column for which the score should be calculate</param>
        /// <returns>the score (higher=better)</returns>
        private int ColumnScore(IChromosome chromosome, int col)
        {
            var uniqueValues = 0;
            var used = new bool[10];
            for (var row = 0; row < 9; ++row)
            {
                var gene = (SudokuGene)chromosome.Genes[row];
                var val = gene.Columns[col];
                if (used[val]) continue;
                used[val] = true;
                uniqueValues++;
            }
            return uniqueValues;
        }

        /// <summary>
        /// Calculate the score for a row.
        /// The score simply is the number of unique values used in a row
        /// </summary>
        /// <param name="gene">The gene.</param>
        /// <returns>the score (higher=better)</returns>
        private int RowScore(SudokuGene gene)
        {
            var uniqueValues = 0;
            var used = new bool[10];
            for (var col = 0; col < 9; ++col)
            {
                var val = gene.Columns[col];
                if (used[val]) continue;
                used[val] = true;
                uniqueValues++;
            }
            return uniqueValues;
        }
    }
}