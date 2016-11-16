using GAF;
using System;

namespace SudokuSolver
{
    public class SudokuSolver
    {
        private const int POPULATION_SIZE = 3000;

        /// <summary>
        /// Solves the specified sudoku.
        /// </summary>
        /// <param name="sudoku">The sudoku.</param>
        public void Solve(Sudoku sudoku)
        {
            var ga = new GeneticAlgorithm();
            var population = new Population();

            // create an initial population
            for (var i = 0; i < POPULATION_SIZE; ++i)
            {
                var chromosome = new Chromosome();
                for (var row = 0; row < sudoku.Rows; ++row)
                {
                    chromosome.Genes.Add(new SudokuGene());
                }
                population.Add(chromosome);
            }

            var fitnessCalculator = new SudokuFitnessCalculator(sudoku);
            ga.Add(new Elite(0.1));
            ga.Add(new Mutate(0.8));
            ga.Add(new SudokuCrossOver(0.5));
            ga.Run(population, new TournamentSelection(), fitnessCalculator);
        }
    }
}