using ClassLibrary.Builders;
using ClassLibrary.Classes;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;


namespace ClassLibrary.Methods
{
    public class Player
    {
        /// <summary>
        /// Collects player information, including names and initial grid selections, 
        /// and returns a list of players.
        /// </summary>
        public static List<PlayerModel> GetPlayersInfo()
        {
            List<PlayerModel> players = new List<PlayerModel>();

            for (int i = 1; i < 3; i++)
            {
                ConsoleHelper.PrintToConsole(Constants.BattleshipTextASCII);

                string playerID = "P" + i; // Unique ID for each player

                //Initialize new/empty grid
                GridModel newGrid = new GridBuilder()
                    .AddNewGrid()
                    .Build();

                //Initial creation of each player
                PlayerModel player = new PlayerBuilder()
                    .AddPlayerID(playerID)
                    .AddPlayerGrid(newGrid)
                    .Build();

                ConsoleHelper.PrintGrid(player);

                Console.WriteLine("\n" + new string('-', 180) + "\n");

                if (playerID == "P1")
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"Player {i}");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"Player {i}");
                    Console.ResetColor();
                }
                player.Name = ConsoleHelper.GetInfoFromConsole(", please enter your name: ");

                GetGridSelections(player);

                players.Add(player);

                Console.Clear();
            }
            return players;
        }

        /// <summary>
        /// Collects 5 valid grid selections from the player and updates their grid.
        /// </summary>
        /// <param name="player">The player whose selections are being recorded.</param>
        public static void GetGridSelections(PlayerModel player)
        {
            string playerGridSelection = "";
            bool isSelectionValid;

            Console.WriteLine("Please enter your 5 grid selections:\n");

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, 45 + i);
                Console.Write($"{i + 1}. ");
                do
                {
                    playerGridSelection = ConsoleHelper.GetInfoFromConsole();
                    isSelectionValid = Grid.ValidateGridSelection(playerGridSelection, player.PlayerGrid.GridSelections);

                    if (!isSelectionValid)
                    {
                        ConsoleKey keyPressed;
                        do
                        {
                            Console.SetCursorPosition(0, 45 + i);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("I'm sorry that position is not valid. Please select a position between " +
                             "A1 - E5 that has not already been selected. Press enter to continue...");


                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            keyPressed = keyInfo.Key;
                        }
                        while (keyPressed != ConsoleKey.Enter);

                        Console.ResetColor();

                        Console.SetCursorPosition(0, 45 + i);
                        ConsoleHelper.ClearCurrentConsoleLine();
                        Console.Write($"{i + 1}. ");
                    }
                    else
                    {
                        player.PlayerGrid.GridSelections.Add(playerGridSelection);
                    }

                }
                while (!isSelectionValid);

                // Update existing PlayerGrid with GridSelections
                player.PlayerGrid = new GridBuilder()
                    .AddNewGrid()
                    .AddGridSelections(player.PlayerGrid.GridSelections)
                    .Build();

                // Mark players grid selection with an 'X'
                Grid.UpdateGrid(player.PlayerGrid.Grid, "  X", player.PlayerGrid.GridSelections);

                Console.SetCursorPosition((180 - 43) / 2, 14);
                ConsoleHelper.PrintGrid(player);

            }

            ConsoleKey pressedKey;
            do
            {
                Console.SetCursorPosition(0, 51);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have made your selections! Press enter to continue...");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                pressedKey = keyInfo.Key;
            }
            while (pressedKey != ConsoleKey.Enter);

            Console.ResetColor();

        }
    }
}
