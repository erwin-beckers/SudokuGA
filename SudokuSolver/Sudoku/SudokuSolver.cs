using GAF;
using System;

namespace SudokuSolver
{
    public class SudokuSolver : IGenerationCallback
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
            ga.Add(new Elite(0.01));
            ga.Add(new Mutate(0.8));
            ga.Add(new SudokuDiversify(0.2));
            ga.Add(new SudokuCrossOver(0.8));
            ga.Run(population, new TournamentSelection(), fitnessCalculator, this);
        }

        public void OnStart(int generation)
        {
        }

        public void OnEnd(int generation, double bestFitness)
        {
            if ((generation % 50) == 0)
            {
                Console.WriteLine($"gen:{generation} best fitness:{bestFitness}");
            }
        }

    }
}