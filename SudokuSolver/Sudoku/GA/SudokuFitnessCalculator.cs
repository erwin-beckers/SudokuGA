using GAF;
using System;

namespace SudokuSolver
{
    /// <summary>
    /// Fitness calculator for a sudoku
    /// </summary>
    /// <seealso cref="GAF.IFitness" />
    public class SudokuFitnessCalculator : IFitness
    {
        private Sudoku _sudoku;
        private double _bestFitness = 0;
        private int _bestGeneration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuFitnessCalculator"/> class.
        /// </summary>
        /// <param name="sudoku">The sudoku we want to solve.</param>
        public SudokuFitnessCalculator(Sudoku sudoku)
        {
            _sudoku = sudoku;
        }

        /// <summary>
        /// Calculates the fitness for a specific chromosome
        /// </summary>
        /// <param name="chromo">The chromosone.</param>
        /// <param name="generation">The generation.</param>
        /// <param name="finished">if set to <c>true</c> [finished].</param>
        /// <returns></returns>
        public double CalculateFitness(IChromosome chromo, int generation, out bool finished)
        {
            finished = false;
            // get a clone of the original sudoku
            var solution = _sudoku.Clone();

            // next fill in the soduku with all the values from the chromosone
            for (var row = 0; row < _sudoku.Rows; ++row)
            {
                var geneRow = ((SudokuGene)chromo.Genes[row]);
                for (var col = 0; col < _sudoku.Columns; ++col)
                {
                    var val = geneRow.Columns[col];

                    // don't overwrite values which are already specified in the sodoku
                    if (!solution.IsFixed(row, col))
                    {
                        solution.Set(row, col, val);
                    }
                }
            }

            // get the amount of errors for this solution
            var errorCount = solution.GetErrorCount();

            // calculate the fitness
            double errors = (double)errorCount;
            double totalNrs = (double)(_sudoku.Rows * _sudoku.Columns) * 3;
            double fitnessValue = (totalNrs - errors) / totalNrs;

            // log best fitnesses
            if (fitnessValue > _bestFitness)
            {
                _bestFitness = fitnessValue;
                _bestGeneration = generation;
                lock (_sudoku)
                {
                    Console.WriteLine($"generation:{generation} errors:#{errors} of total:#{totalNrs} : fitness:{fitnessValue}");
                    solution.Dump();
                }
            }

            // no errors ? then we are done
            if (errorCount == 0)
            {
                finished = true;
                solution.Dump();
            }
            return fitnessValue;
        }
    }
}