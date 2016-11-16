# SudokuGA
Using genetic algorithms to solve sudoku puzzles.

This project tries to solve sudoku puzzles using genetic algorithms.


# Genetic Algorithm Framework

The project is written in C# and contains a generic framework for genetic algorithms which applications can use.
It also contains a simple console application which uses the GA framework to solve sudoku puzzles.

The framework itself uses C# tasks for multithreading, so the fitness of multiple chromosones are calculated in parallel.

All sources are fully documented so it should be fairly easy to get started. 


## Building

Simply download the sources, open the solution in visual studio and run it

The main part of the program can be found in SudokuSolver.cs:
```
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
```
