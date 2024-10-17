using ClassLibrary.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class Grid
    {
        /// <summary>
        /// Initializes a new 6x6 grid for the game.
        /// The first row and column serve as headers (numbers and letters).
        /// </summary>
        /// <returns>A 2D string array representing the grid.</returns>
        public static string[][] InitializeGrid()
        {
            string[][] grid = new[]
            {
                new[] {"   ", "  1", "  2", "  3", "  4", "  5"},
                new[] {"  A", "   ", "   ", "   ", "   ", "   "},
                new[] {"  B", "   ", "   ", "   ", "   ", "   "},
                new[] {"  C", "   ", "   ", "   ", "   ", "   "},
                new[] {"  D", "   ", "   ", "   ", "   ", "   "},
                new[] {"  E", "   ", "   ", "   ", "   ", "   "}
            };
            return grid;
        }

        /// <summary>
        /// Updates the grid with a specified marker at positions defined by the selection list.
        /// </summary>
        /// <param name="grid">The current grid to update.</param>
        /// <param name="marker">The marker (e.g., "X" or "O") to place on the grid.</param>
        /// <param name="selections">A list of grid selections (e.g., "A1", "B2").</param>
        /// <returns>The updated grid.</returns>
        public static string[][] UpdateGrid(string[][]grid, string marker, List<string> selections)
        {
            InitializeGrid();

            foreach (var selection in selections)
            {
                (int row, int col) = ConvertSelectionToIndex(selection);
                if (row != -1 && col != -1)
                {
                    grid[row][col] = marker;
                }
            }
            return grid;
        }

        /// <summary>
        /// Converts a grid selection string (e.g., "A1") to corresponding row and column indices.
        /// </summary>
        /// <param name="selection">The grid selection (e.g., "A1").</param>
        /// <returns>A tuple containing the row and column indices, or (-1, -1) if invalid.</returns>
        private static (int row, int col) ConvertSelectionToIndex(string selection)
        {
            if (string.IsNullOrWhiteSpace(selection) || selection.Length != 2)
                return (-1, -1);

            int row = selection[0] - 'A' + 1;  // A -> 1, B -> 2, etc.
            int col = selection[1] - '0';      // '1' -> 1, '2' -> 2, etc.

            return (row >= 1 && row <= 5 && col >= 1 && col <= 5) ? (row, col) : (-1, -1);
        }

        /// <summary>
        /// Validates a grid selection to ensure it is within the allowed grid and not already chosen.
        /// </summary>
        /// <param name="currentGridSelection">The selection being validated (e.g., "A1").</param>
        /// <param name="selectionList">A list of previously chosen selections.</param>
        /// <returns>True if the selection is valid, false otherwise.</returns>
        public static bool ValidateGridSelection(string currentGridSelection, List<string> selectionList)
        {

            if (!Constants.GridTable.Contains(currentGridSelection))
            {
                return false;
            }
            else if (selectionList.Contains(currentGridSelection))
            {
                return false;
            }

            else return true;
        }
    }
}
