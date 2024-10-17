using ClassLibrary.Builders;
using ClassLibrary.Classes;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;

namespace ClassLibrary.Methods
{
    public class ConsoleHelper
    {

        /// <summary>
        /// Plays a .wav audio file. Supports looping playback if specified.
        /// </summary>
        /// <param name="wavFile">The path to the .wav file.</param>
        /// <param name="isLoop">Indicates whether the audio should loop continuously.</param>
        public static SoundPlayer PlayFile(string wavFile, bool isLoop)
        {
            SoundPlayer soundPlayer = new SoundPlayer(wavFile);
            if (!isLoop)
            {
                soundPlayer.Load();
                soundPlayer.Play();
            }
            else
            {
                soundPlayer.Load();
                soundPlayer.PlayLooping();
            }

            return soundPlayer;
        }

        public static void StopFile(SoundPlayer soundPlayer)
        {
            soundPlayer.Stop();
        }

        public static void SetConsoleSettings()
        {
            int consoleWidth = 180;
            int consoleHeight = 67;

            Console.SetWindowSize(consoleWidth, consoleHeight);
        }

        /// <summary>
        /// Prompts the user for input, optionally displaying a message, and returns the input in uppercase.
        /// </summary>
        /// <param name="message">Optional message to display before reading input.</param>
        /// <returns>The user input converted to uppercase.</returns>
        public static string GetInfoFromConsole([Optional] string message)
        {
            Console.Write(message);
            string output = Console.ReadLine();
            return output.ToUpper();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void PrintToConsole(string ascii)
        {
            Console.Clear();
            Console.WriteLine(ascii);
        }

        public static void PrintTurnHeader(PlayerModel player)
        {
            Console.WriteLine("\n" + new string('-', 180) + "\n");

            Console.Write("It's your turn ");
            Console.BackgroundColor = player.PlayerID == "P1" ? Constants.Player1Background : Constants.Player2Background;

            Console.Write(player.Name);
            Console.ResetColor();
            Console.WriteLine(".");
        }

        /// <summary>
        /// Displays an error message for invalid selections and waits for the user 
        /// to press Enter to continue.
        /// </summary>
        public static void PrintInvalidSelectionMessage()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.SetCursorPosition(0, 43);
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Invalid selection. Choose a position between A1 - E5 " +
                                  "that has not already been selected. Press Enter to continue...");

                keyPressed = Console.ReadKey(true).Key;
            }
            while (keyPressed != ConsoleKey.Enter);

            Console.ResetColor();
            Console.SetCursorPosition(0, 43);
            ConsoleHelper.ClearCurrentConsoleLine();
        }

        /// <summary>
        /// Prints the player's grid with special formatting for hits and selections.
        /// </summary>
        public static void PrintGrid(PlayerModel player)
        {   
            var rows = player.PlayerGrid.Grid.Length;
            var cols = player.PlayerGrid.Grid.First().Length;
            var header  = $"┌{string.Join("", Enumerable.Repeat("──────┬", cols - 1))}──────┐";
            var headExt = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var upper   = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var middle  = $"├{string.Join("", Enumerable.Repeat("──────┼", cols - 1))}──────┤";
            var lower   = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var footExt = $"│{string.Join("", Enumerable.Repeat("      │", cols - 1))}      │";
            var footer  = $"└{string.Join("", Enumerable.Repeat("──────┴", cols - 1))}──────┘";


            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(header);

            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(headExt);

            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);

                foreach (var cell in player.PlayerGrid.Grid[i])
                {
                    if (cell == "  X" && player.PlayerGrid.HitTargets?.Count > 0)
                    {
                        Console.Write("│ ");
                        Console.ForegroundColor = Constants.TargetHit;
                        Console.Write($"{cell ?? ""}  ");
                        Console.ResetColor();
                    }
                    else if (cell == "  X")
                    {
                        Console.Write("│ ");
                        Console.ForegroundColor = Constants.GridSelect;
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

        /// <summary>
        /// Displays the game results for all players and prompts the user to continue.
        /// </summary>
        public static void PrintGameResults(List<PlayerModel> finalResults)
        {
            PrintToConsole(Constants.GameResultsASCII);

            foreach (PlayerModel player in finalResults)
            {
                PrintPlayerResults(player);
            }

            Console.SetCursorPosition(((180 - 43) / 2) + 10, Console.CursorTop);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the results for an individual player, including their name and grid.
        /// </summary>
        private static void PrintPlayerResults(PlayerModel player)
        {
            Console.SetCursorPosition((180 - 43) / 2, Console.CursorTop);

            if (player.PlayerGrid.HitTargets.Count == 5)
            {
                Console.BackgroundColor = Constants.WinnerBackground;
                Console.WriteLine("WINNER");
                Console.ResetColor();
            }

            Console.SetCursorPosition((180 - 43) / 2, Console.CursorTop);
            Console.WriteLine(player.Name);

            PrintGrid(player);
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
        }

    }
}
