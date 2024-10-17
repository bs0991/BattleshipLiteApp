using ClassLibrary.Builders;
using ClassLibrary.Classes;
using ClassLibrary.Methods;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace ClassLibrary
{
    public class Game
    {
        private static List<PlayerModel> players = new List<PlayerModel>();
        private static List<string> p1GridSelections = new List<string>();
        private static List<string> p2GridSelections = new List<string>();
        private static SoundPlayer soundPlayer = new SoundPlayer();

        /// <summary>
        /// Main entry point for the game. Initializes the game, handles menus, and controls game flow.
        /// </summary>
        public static void Run()
        {
            Console.Title = "Battleship";

            ConsoleHelper.SetConsoleSettings();
            
            soundPlayer = ConsoleHelper.PlayFile("The_Midnight_The_Equaliser_Not_Alone.wav", true);

            var (selectedIndex, isMainMenu) = RunMainMenu();
            bool startGame = false;

            do
            {
                if (selectedIndex == 2)
                {
                    Environment.Exit(0);
                }
                else if (selectedIndex == 1 && isMainMenu == false)
                {
                    (selectedIndex, isMainMenu) = RunGameInstructions();
                }

                else if (selectedIndex == 1 && isMainMenu == true)
                {
                    (selectedIndex, isMainMenu) = RunMainMenu();
                }
                else
                {
                    startGame = true;
                }

            } while (!startGame);

        }

        /// <summary>
        /// Displays the main menu and returns the selected option.
        /// </summary>
        /// 
        /// <returns>A tuple containing the selected option index and a flag indicating 
        /// if it's the main menu.</returns>
        private static (int, bool) RunMainMenu()
        {
            string ascii = Constants.BattleshipImageASCII;
            string[] options = { "Play", "Instructions", "Exit" };
            bool isMainMenu = true;

            MenuModel menu = new MenuBuilder()
                .AddASCII(ascii)
                .AddOptions(options)
                .IsMainMenu(isMainMenu)
                .Build();

            MenuOption selectedOption = new MenuOption();

            int selectedIndex = selectedOption.SelectOption(menu);

            isMainMenu = false;

            return (selectedIndex, isMainMenu);
        }

        /// <summary>
        /// Displays the game instructions and returns the selected option.
        /// </summary>
        ///
        /// <returns>A tuple containing the selected option index and a flag indicating 
        /// if it's the main menu.</returns>
        private static (int, bool) RunGameInstructions()
        {
            string ascii = Constants.InstructionsASCII;
            string[] options = { "Play", "Previous", "Exit" };
            bool isMainMenu = false;

            MenuModel menu = new MenuBuilder()
                .AddASCII(ascii)
                .AddOptions(options)
                .IsMainMenu(isMainMenu)
                .Build();

            MenuOption selectedOption = new MenuOption();

            int selectedIndex = selectedOption.SelectOption(menu);

            isMainMenu = true;

            return (selectedIndex, isMainMenu);
        }


        /// <summary>
        /// Starts a new game by resetting player grids and controlling game flow
        /// </summary>
        /// 
        /// <returns>Each players instance in a list</returns>
        public static List<PlayerModel> StartNewGame(List<PlayerModel> players)
        {
            ConsoleHelper.StopFile(soundPlayer);

            // Extract player grid selections using LINQ
            p1GridSelections = players.FirstOrDefault(p => p.PlayerID == "P1")?.PlayerGrid.GridSelections;
            p2GridSelections = players.FirstOrDefault(p => p.PlayerID == "P2")?.PlayerGrid.GridSelections;

            // Initialize new grids for each player
            players.ForEach(p => p.PlayerGrid = new GridBuilder().AddNewGrid().Build());

            int hitCount = 0;

            do
            {
                foreach (var player in players)
                {

                    hitCount = StartPlayerIterations(player, p1GridSelections, p2GridSelections);

                    if (hitCount >= 5)
                    {
                        break;
                    }
                }
            } while (hitCount < 5);

            return players;
        }

        /// <summary>
        /// Controls a player's turn and returns the total number of hits so far.
        /// </summary>
        /// 
        /// <returns>Number of hit targets for current player</returns>
        private static int StartPlayerIterations(PlayerModel player, 
                                                 List<string> p1GridSelections, 
                                                 List<string> p2GridSelections)
        {

            ConsoleHelper.PrintToConsole(Constants.BattleshipTextASCII);

            ConsoleHelper.PrintGrid(player);

            ConsoleHelper.PrintTurnHeader(player);

            string currentTargetSelection = GetValidTargetSelection(player);

            Thread.Sleep(3000);

            bool isHit = ProcessTurn(player, currentTargetSelection);

            Thread.Sleep(isHit ? 3000 : 2000);

            return player.PlayerGrid.HitTargets.Count;
        }


        /// <summary>
        /// Prompts the player for target selection and validates it.
        /// </summary>
        /// 
        /// <returns>Current target selection (string) if valid</returns>
        private static string GetValidTargetSelection(PlayerModel player)
        {
            string targetSelection;
            bool isValid;

            do
            {
                targetSelection = ConsoleHelper.GetInfoFromConsole("Enter your target selection: ");
                isValid = Grid.ValidateGridSelection(targetSelection, player.PlayerGrid.AllTargetSelections);

                if (!isValid)
                {
                    ConsoleHelper.PrintInvalidSelectionMessage();
                }
                else
                {
                    player.PlayerGrid.AllTargetSelections.Add(targetSelection);
                }
            }
            while (!isValid);

            return targetSelection;
        }

        /// <summary>
        /// Processes the player's shot and updates the grid based on the result.
        /// </summary>
        ///
        /// <returns>Bool indicating if target selection was a hit or not</returns>
        private static bool ProcessTurn(PlayerModel player, string targetSelection)
        {
            
            //Do we need to explicitly define both player conditions?
            bool isHit = (player.PlayerID == "P1" && p2GridSelections.Contains(targetSelection)) ||
                         (player.PlayerID == "P2" && p1GridSelections.Contains(targetSelection));

            if (isHit)
            {
                ConsoleHelper.PlayFile("Explosion_Sound.wav", false);
                player.PlayerGrid.HitTargets.Add(targetSelection);

            }
            else
            {
                player.PlayerGrid.MissedTargets.Add(targetSelection);
                
            }

            // Update the game grid after the shot
            Grid.UpdateGrid(player.PlayerGrid.Grid, "  X", player.PlayerGrid.HitTargets);
            Grid.UpdateGrid(player.PlayerGrid.Grid, "  O", player.PlayerGrid.MissedTargets);

            Console.SetCursorPosition((180 - 43) / 2, 14);
            ConsoleHelper.PrintGrid(player);

            return isHit;
        }

    }
}
