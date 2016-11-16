using System;

namespace SudokuSolver
{
    /// <summary>
    /// Class containing a Sudoku
    /// </summary>
    public class Sudoku
    {
        /// <summary>
        /// The sudoku
        /// </summary>
        private int[][] _sudoku;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sudoku"/> class.
        /// </summary>
        public Sudoku()
        {
            _sudoku = CreateSudoku();
        }

        /// <summary>
        /// Creates the sudoku.
        /// </summary>
        /// <returns></returns>
        private int[][] CreateSudoku()
        {
            int[][] sodoku = new int[9][];
            sodoku[0] = new int[] { 0, 0, 6, 2, 0, 0, 0, 8, 0 };
            sodoku[1] = new int[] { 0, 0, 8, 9, 7, 0, 0, 0, 0 };
            sodoku[2] = new int[] { 0, 0, 4, 8, 1, 0, 5, 0, 0 };
            sodoku[3] = new int[] { 0, 0, 0, 0, 6, 0, 0, 0, 2 };
            sodoku[4] = new int[] { 0, 7, 0, 0, 0, 0, 0, 3, 0 };
            sodoku[5] = new int[] { 6, 0, 0, 0, 5, 0, 0, 0, 0 };
            sodoku[6] = new int[] { 0, 0, 2, 0, 4, 7, 1, 0, 0 };
            sodoku[7] = new int[] { 0, 0, 3, 0, 2, 8, 4, 0, 0 };
            sodoku[8] = new int[] { 0, 5, 0, 0, 0, 1, 2, 0, 0 };
            return sodoku;
        }

        /// <summary>
        /// Gets the number of rows in the sudoku
        /// </summary>
        /// <value>
        /// The number of rows
        /// </value>
        public int Rows
        {
            get
            {
                return _sudoku.Length;
            }
        }

        /// <summary>
        /// Gets the number of columns in the sudoku
        /// </summary>
        /// <value>
        /// The number of columns
        /// </value>
        public int Columns
        {
            get
            {
                return _sudoku[0].Length;
            }
        }

        /// <summary>
        /// Determines whether the specified value at (row,col) is fixed.
        /// </summary>
        /// <param name="row">The row nr.</param>
        /// <param name="col">The column nr.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is fixed; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFixed(int row, int col)
        {
            return _sudoku[row][col] != 0;
        }

        /// <summary>
        /// Sets the a nr in the sudoku at the specific row/column
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <param name="val">The value (1-9).</param>
        public void Set(int row, int col, int val)
        {
            val = val > 9 ? 9 : val;
            val = val < 1 ? 1 : val;
            _sudoku[row][col] = val;
        }

        /// <summary>
        /// Returns the number of errors in the sudoku
        /// </summary>
        /// <returns></returns>
        public int GetErrorCount()
        {
            var errors = 0;
            for (var row = 0; row < Rows; ++row)
            {
                for (var col = 0; col < Columns; ++col)
                {
                    if (HasRowError(row, col)) errors++;
                    if (HasColumnError(row, col)) errors++;
                    if (HasSubGridError(row, col)) errors++;
                }
            }
            return errors;
        }

        /// <summary>
        /// Returns if the value at (row,col) contains a row error.
        /// A row error occurs if the value at (row,col) is used multiple times in the row specified
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <returns>
        ///   <c>true</c> if the value at (row,col) contains a row error; otherwise, <c>false</c>.
        /// </returns>
        private bool HasRowError(int row, int col)
        {
            var used = new int[10];
            for (var x = 0; x < 9; ++x)
            {
                var val = _sudoku[row][x];
                used[val]++;
            }
            var colVal = _sudoku[row][col];
            return used[colVal] > 1;
        }

        /// <summary>
        /// Returns if the value at (row,col) contains a column error.
        /// A column error occurs if the value at (row,col) is used multiple times in the column specified
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <returns>
        ///   <c>true</c> if the value at (row,col) contains a row error; otherwise, <c>false</c>.
        /// </returns>
        private bool HasColumnError(int row, int col)
        {
            var used = new int[10];
            for (var x = 0; x < 9; ++x)
            {
                var val = _sudoku[x][col];
                used[val]++;
            }
            var colVal = _sudoku[row][col];
            return used[colVal] > 1;
        }

        /// <summary>
        /// Returns if the value at (row,col) contains a subgrid error.
        /// A subgrid error occurs if the value at (row,col) is used multiple times in the column specified
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The column.</param>
        /// <returns>
        ///   <c>true</c> if the value at (row,col) contains a row error; otherwise, <c>false</c>.
        /// </returns>
        private bool HasSubGridError(int row, int col)
        {
            var gridY = (int)(row / 3);
            var gridX = (int)(col / 3);

            var used = new int[10];
            for (var y = 0; y < 3; ++y)
            {
                for (var x = 0; x < 3; ++x)
                {
                    var val = _sudoku[gridY * 3 + y][gridX * 3 + x];
                    used[val]++;
                }
            }
            var colVal = _sudoku[row][col];
            return used[colVal] > 1;
        }

        /// <summary>
        /// Dumps this sudoku to the console.
        /// </summary>
        public void Dump()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            for (var row = 0; row < _sudoku.Length; ++row)
            {
                for (var col = 0; col < _sudoku[row].Length; ++col)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    var hasRowError = HasRowError(row, col);
                    var hasColError = HasColumnError(row, col);
                    var hasSubGridError = HasSubGridError(row, col);
                    if (hasRowError && hasColError && hasSubGridError) Console.BackgroundColor = ConsoleColor.Red;
                    else if (hasRowError && hasColError) Console.BackgroundColor = ConsoleColor.Magenta;
                    else if (hasRowError) Console.BackgroundColor = ConsoleColor.Yellow;
                    else if (hasColError) Console.BackgroundColor = ConsoleColor.Blue;
                    else if (hasSubGridError) Console.BackgroundColor = ConsoleColor.Green;

                    Console.Write(_sudoku[row][col]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Clones this sudoku.
        /// </summary>
        /// <returns></returns>
        internal Sudoku Clone()
        {
            return new Sudoku();
        }
    }
}