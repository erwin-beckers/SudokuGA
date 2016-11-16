namespace SudokuSolver
{
    internal class Program
    {
        private static void Main()
        {
            // create a sudoku to solve
            var sudoku = new Sudoku();

            // solve the sudoku
            var solver = new SudokuSolver();
            solver.Solve(sudoku);
        }
    }
}