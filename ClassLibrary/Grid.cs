using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    /// <summary>
    /// NEED DOCUMENTATION
    /// </summary>
    public class Grid
    {
        private List<string> PlayerGridSelections;
        private List<string> HitTargets;
        private List<string> MissedTargets;
        private string CurrentTarget;

        /// <summary>
        /// DOCUMENT ME!!!!
        /// </summary>
        /// <param name="playerGridSelections"></param>
        /// <param name="hitTargets"></param>
        /// <param name="missedTargets"></param>
        /// <param name="currentTarget"></param>
        public Grid([Optional] List<string> playerGridSelections, [Optional] List<string> hitTargets,
            [Optional] List<string> missedTargets, [Optional] string currentTarget)
        {
            PlayerGridSelections = playerGridSelections;
            HitTargets = hitTargets;
            MissedTargets = missedTargets;
            CurrentTarget = currentTarget;
        }

        public List<string> GridTable
        {
            get
            {
                return _gridTable;
            }

        }

        private List<string> _gridTable = new List<string>()
        {
            "A1", "A2", "A3", "A4", "A5",
            "B1", "B2", "B3", "B4", "B5",
            "C1", "C2", "C3", "C4", "C5",
            "D1", "D2", "D3", "D4", "D5",
            "E1", "E2", "E3", "E4", "E5",
        };

        // There is a ton happening in this one method.  You should break it up into smaller methods or helper methods that do a singular task and can be reused.
        // Your larger player grid methods could be for loops that map this and in helper functions then this create grid function would be much cleaner and easier to read.
        public void CreateGrid()
        {
            // This could be optimized no need to write it all out like this. You could use a loop to generate the grid.
            string[][] grid = new[]
            {
                new[] {"   ", "  1", "  2", "  3", "  4", "  5"},
                new[] {"  A", "   ", "   ", "   ", "   ", "   "},
                new[] {"  B", "   ", "   ", "   ", "   ", "   "},
                new[] {"  C", "   ", "   ", "   ", "   ", "   "},
                new[] {"  D", "   ", "   ", "   ", "   ", "   "},
                new[] {"  E", "   ", "   ", "   ", "   ", "   "}
            };
            // I did not figure this out on my own definitely some chat GPT on this part but I totally get why you would be mapping without it to learn.
            Dictionary<string, (int, int)> gridMapping = new Dictionary<string, (int, int)>
            {
                { "A1", (1, 1) }, { "A2", (1, 2) }, { "A3", (1, 3) }, { "A4", (1, 4) }, { "A5", (1, 5) },
                { "B1", (2, 1) }, { "B2", (2, 2) }, { "B3", (2, 3) }, { "B4", (2, 4) }, { "B5", (2, 5) },
                { "C1", (3, 1) }, { "C2", (3, 2) }, { "C3", (3, 3) }, { "C4", (3, 4) }, { "C5", (3, 5) },
                { "D1", (4, 1) }, { "D2", (4, 2) }, { "D3", (4, 3) }, { "D4", (4, 4) }, { "D5", (4, 5) },
                { "E1", (5, 1) }, { "E2", (5, 2) }, { "E3", (5, 3) }, { "E4", (5, 4) }, { "E5", (5, 5) }
            };

            if (PlayerGridSelections != null)
            {
                // I would avoid massive switch statements like the above.  You just need a clever way to map the grid selection to the grid
                // Here is an example.
                // Switch case for each player grid selection string
                foreach (string selection in PlayerGridSelections)
                {
                    if (gridMapping.TryGetValue(selection, out var position))
                    {
                        grid[position.Item1][position.Item2] = "  X";
                    }
                }
            }
            // Now that this code is reduced you can see that you are repeating your logic a bit on player selection and hit targets.  You could combine these into one loop.
            // Or create a helper function that does the logic for you.
            if (HitTargets != null)
            {
                foreach (string hitTarget in HitTargets)
                {
                    if (gridMapping.TryGetValue(hitTarget, out var position))
                    {
                        grid[position.Item1][position.Item2] = "  X";
                    }
                }
            }

            if (MissedTargets != null)
            {
                foreach (string missedTarget in MissedTargets)
                {
                    if (gridMapping.TryGetValue(missedTarget, out var position))
                    {
                        grid[position.Item1][position.Item2] = "  O";
                    }
                }
            }

            // Avoid using var at all costs.  It makes the code harder to read and understand.  Use the actual type instead.
            // C# is a statically typed language so you should always know the type of the variable you are working with.
            // Also, you should always use the most specific type possible.  In this case, you should use string[][] instead of var.

            // You also need to document your code.  You should have a comment at the top of each method explaining what the method does.
            var rows = grid.Length;
            var cols = grid.First().Length;
            var header = $"┌{string.Join("", Enumerable.Repeat("──────┬", cols - 1))}──────┐";
            var headExt = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var upper = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var middle = $"├{string.Join("", Enumerable.Repeat("──────┼", cols - 1))}──────┤";
            var lower = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var footExt = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var footer = $"└{string.Join("", Enumerable.Repeat("──────┴", cols - 1))}──────┘";

            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(header);

            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(headExt);

            for (int i = 0; i < rows; ++i)
            {
                Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
                foreach (var cell in grid[i])
                {

                    //Set players hit targets to red

                    // Create a constant for the string your looking for so hit targets are indicated it appears if the cell has space space X
                    // Honestly this whole section needs some love. 
                    if (HitTargets != null && HitTargets.Count > 0 && cell == "  X")
                    {
                        Console.Write("│ ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{cell ?? ""}  ");
                        Console.ResetColor();
                    }

                    //Set players initial grid selections to green
                    else if (cell == "  X")
                    {
                        Console.Write("│ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{cell ?? ""}  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"│ {cell ?? ""}  ");
                    }
                }

                Console.WriteLine("│");

                if (i < rows - 1)
                {
                    Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
                    Console.WriteLine(upper);

                    Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
                    Console.WriteLine(middle);

                    Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
                    Console.WriteLine(lower);
                }

            }
            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(footExt);

            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(footer);
        }

    }
}
