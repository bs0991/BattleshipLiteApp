using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Grid
    {   
        private List<string> PlayerGridSelections;
        private List<string> HitTargets;
        private List<string> MissedTargets;
        private string CurrentTarget;
  
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

        public void CreateGrid()
        {
            var grid = new[]
            {
                new[] {"   ", "  1", "  2", "  3", "  4", "  5"},
                new[] {"  A", "   ", "   ", "   ", "   ", "   "},
                new[] {"  B", "   ", "   ", "   ", "   ", "   "},
                new[] {"  C", "   ", "   ", "   ", "   ", "   "},
                new[] {"  D", "   ", "   ", "   ", "   ", "   "},
                new[] {"  E", "   ", "   ", "   ", "   ", "   "}
            };

            if (PlayerGridSelections != null)
            {

                //Switch case for each player grid selection string
                for ( int i = 0; i < PlayerGridSelections.Count; i++)
                {
                    switch (PlayerGridSelections[i])
                    {
                        case "A1":
                            grid[1][1] = "  X";
                            break;
                        case "A2":
                            grid[1][2] = "  X";
                            break;
                        case "A3":
                            grid[1][3] = "  X";
                            break;
                        case "A4":
                            grid[1][4] = "  X";
                            break;
                        case "A5":
                            grid[1][5] = "  X";
                            break;

                        case "B1":
                            grid[2][1] = "  X";
                            break;
                        case "B2":
                            grid[2][2] = "  X";
                            break;
                        case "B3":
                            grid[2][3] = "  X";
                            break;
                        case "B4":
                            grid[2][4] = "  X";
                            break;
                        case "B5":
                            grid[2][5] = "  X";
                            break;

                        case "C1":
                            grid[3][1] = "  X";
                            break;
                        case "C2":
                            grid[3][2] = "  X";
                            break;
                        case "C3":
                            grid[3][3] = "  X";
                            break;
                        case "C4":
                            grid[3][4] = "  X";
                            break;
                        case "C5":
                            grid[3][5] = "  X";
                            break;

                        case "D1":
                            grid[4][1] = "  X";
                            break;
                        case "D2":
                            grid[4][2] = "  X";
                            break;
                        case "D3":
                            grid[4][3] = "  X";
                            break;
                        case "D4":
                            grid[4][4] = "  X";
                            break;
                        case "D5":
                            grid[4][5] = "  X";
                            break;

                        case "E1":
                            grid[5][1] = "  X";
                            break;
                        case "E2":
                            grid[5][2] = "  X";
                            break;
                        case "E3":
                            grid[5][3] = "  X";
                            break;
                        case "E4":
                            grid[5][4] = "  X";
                            break;
                        case "E5":
                            grid[5][5] = "  X";
                            break;
                    }
                }
            }

            if (HitTargets != null)
            {
                //Switch case for each player hit target string
                for (int i = 0; i < HitTargets.Count; i++)
                {
                    switch (HitTargets[i])
                    {
                        case "A1":
                            grid[1][1] = "  X";
                            break;
                        case "A2":
                            grid[1][2] = "  X";
                            break;
                        case "A3":
                            grid[1][3] = "  X";
                            break;
                        case "A4":
                            grid[1][4] = "  X";
                            break;
                        case "A5":
                            grid[1][5] = "  X";
                            break;

                        case "B1":
                            grid[2][1] = "  X";
                            break;
                        case "B2":
                            grid[2][2] = "  X";
                            break;
                        case "B3":
                            grid[2][3] = "  X";
                            break;
                        case "B4":
                            grid[2][4] = "  X";
                            break;
                        case "B5":
                            grid[2][5] = "  X";
                            break;

                        case "C1":
                            grid[3][1] = "  X";
                            break;
                        case "C2":
                            grid[3][2] = "  X";
                            break;
                        case "C3":
                            grid[3][3] = "  X";
                            break;
                        case "C4":
                            grid[3][4] = "  X";
                            break;
                        case "C5":
                            grid[3][5] = "  X";
                            break;

                        case "D1":
                            grid[4][1] = "  X";
                            break;
                        case "D2":
                            grid[4][2] = "  X";
                            break;
                        case "D3":
                            grid[4][3] = "  X";
                            break;
                        case "D4":
                            grid[4][4] = "  X";
                            break;
                        case "D5":
                            grid[4][5] = "  X";
                            break;

                        case "E1":
                            grid[5][1] = "  X";
                            break;
                        case "E2":
                            grid[5][2] = "  X";
                            break;
                        case "E3":
                            grid[5][3] = "  X";
                            break;
                        case "E4":
                            grid[5][4] = "  X";
                            break;
                        case "E5":
                            grid[5][5] = "  X";
                            break;
                    }
                }
            }

            if (MissedTargets != null)
            {

                //Switch case for each player missed target string
                for (int i = 0; i < MissedTargets.Count; i++)
                {
                    switch (MissedTargets[i])
                    {
                        case "A1":
                            grid[1][1] = "  O";
                            break;
                        case "A2":
                            grid[1][2] = "  O";
                            break;
                        case "A3":
                            grid[1][3] = "  O";
                            break;
                        case "A4":
                            grid[1][4] = "  O";
                            break;
                        case "A5":
                            grid[1][5] = "  O";
                            break;

                        case "B1":
                            grid[2][1] = "  O";
                            break;
                        case "B2":
                            grid[2][2] = "  O";
                            break;
                        case "B3":
                            grid[2][3] = "  O";
                            break;
                        case "B4":
                            grid[2][4] = "  O";
                            break;
                        case "B5":
                            grid[2][5] = "  O";
                            break;

                        case "C1":
                            grid[3][1] = "  O";
                            break;
                        case "C2":
                            grid[3][2] = "  O";
                            break;
                        case "C3":
                            grid[3][3] = "  O";
                            break;
                        case "C4":
                            grid[3][4] = "  O";
                            break;
                        case "C5":
                            grid[3][5] = "  O";
                            break;

                        case "D1":
                            grid[4][1] = "  O";
                            break;
                        case "D2":
                            grid[4][2] = "  O";
                            break;
                        case "D3":
                            grid[4][3] = "  O";
                            break;
                        case "D4":
                            grid[4][4] = "  O";
                            break;
                        case "D5":
                            grid[4][5] = "  O";
                            break;

                        case "E1":
                            grid[5][1] = "  O";
                            break;
                        case "E2":
                            grid[5][2] = "  O";
                            break;
                        case "E3":
                            grid[5][3] = "  O";
                            break;
                        case "E4":
                            grid[5][4] = "  O";
                            break;
                        case "E5":
                            grid[5][5] = "  O";
                            break;
                    }
                }
            }

            var rows = grid.Length;
            var cols = grid.First().Length;
            var header = $"┌{string.Join("", Enumerable.Repeat("──────┬", cols - 1))}──────┐";
            var headExt= $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var upper  = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var middle = $"├{string.Join("", Enumerable.Repeat("──────┼", cols - 1))}──────┤";
            var lower  = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var footExt= $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
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
