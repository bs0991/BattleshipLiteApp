using ClassLibrary.Models;
using ClassLibrary;
using System.Media;
using System.Runtime.InteropServices;

class Program
{
    private static List<Player> players = new List<Player>();
    private static List<string> player1GridSelections = new List<string>();
    private static List<string> player2GridSelections = new List<string>();
    private static List<Player> finalResults = new List<Player>();
    public static void Main()
    {
        try
        {
            Game newGame = new Game();

            //Can only execute IsWindows() in Main
            if (OperatingSystem.IsWindows())
            {
                //SoundPlayer musicPlayer = new SoundPlayer("Background_Music.wav");
                //musicPlayer.Load();
                //musicPlayer.PlayLooping();

                //Console Settings, Main Menu, and Instructions
                newGame.Run();

                //Get Players Name, ID, and Grid Selections
                players = GetPlayersInfo();

                //musicPlayer.Stop();
            }

            finalResults = StartGame(players);

            DisplayGameResults(finalResults);

            Main();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    public static List<Player> StartGame(List<Player> players)
    {

        int hitCount = 0;

        // This is a painful foreach / Do while hell loop.  I would refactor this to be more readable.
        // Never use var ever again.
        foreach (var player in players)
        {
            if (player.PlayerID == "P1")
            {
                player1GridSelections = player.GridSelections;
            }
            else
            {
                player2GridSelections = player.GridSelections;
            }
        }

        do
        {
            foreach (var player in players)
            {
                if (player.PlayerID == "P1")
                {
                    hitCount = StartPlayerIterations(player, player1GridSelections, player2GridSelections);
                }
                else
                {
                    hitCount = StartPlayerIterations(player, player1GridSelections, player2GridSelections);
                }

                if (hitCount == 5)
                {
                    break;
                }
            }
        } while (hitCount < 5);

        return players;
    }

    public static int StartPlayerIterations(Player player, List<string> player1GridSelections, List<string> player2GridSelections)
    {
        ShowHeader();

        Grid playerGrid = new Grid(hitTargets: player.HitTargets, missedTargets: player.MissedTargets);

        playerGrid.CreateGrid();

        Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

        Console.Write("It's your turn ");
        // Neat thing to do,  Keep your string literals in a resource file.
        // like P1 could be mapped to valid player IDs ,   
        // string[] ValidPlayerIDs = { "P1", "P2", "P3" }; then you can call that here and just do ValidPlayerIDs.P1
        // It makes it easier to update when you decide that player ID or something like this needs to be updated.  Then you update the resource file and not the code.
        // ConsoleColor.DarkBlue is a great example.
        if (player.PlayerID == "P1")
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{player.Name}");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{player.Name}");
        }
        Console.ResetColor();
        Console.WriteLine(".");

        string currentTargetSelection;
        bool isTargetValid;

        do
        {
            currentTargetSelection = GetInfoFromConsole($"Enter your target selection: ");

            isTargetValid = ValidateGridSelection(currentTargetSelection, player.AllTargetSelections);

            if (!isTargetValid)
            {
                ConsoleKey keyPressed;
                do
                {
                    Console.SetCursorPosition(0, 43);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry that position is not valid. Please select a position between " +
                     "A1 - E5 that has not already been selected. Press enter to continue...");


                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    keyPressed = keyInfo.Key;
                }
                while (keyPressed != ConsoleKey.Enter);

                Console.ResetColor();

                Console.SetCursorPosition(0, 43);
                ClearCurrentConsoleLine();
            }
            else
            {
                player.AllTargetSelections.Add(currentTargetSelection);
            }
        }
        while (!isTargetValid);
        

        //pause for three seconds before running shot sound
        Thread.Sleep(3000);


        //Player 1 turn iteration
        if (player.PlayerID == "P1" && player2GridSelections.Contains(currentTargetSelection))
        {
            if (OperatingSystem.IsWindows())
            {
                //SoundPlayer soundPlayer = new SoundPlayer("Explosion_Sound.wav");
                //soundPlayer.Load();
                //soundPlayer.Play();
            }
            player.HitCount++;

            player.HitTargets.Add(currentTargetSelection);

            Grid updatedGrid = new Grid(hitTargets: player.HitTargets, missedTargets: player.MissedTargets, 
                currentTarget: currentTargetSelection);

            Console.SetCursorPosition((180 - 43) / 2, 14);

            updatedGrid.CreateGrid();

            Thread.Sleep(3000);
        }

        //Player 2 turn iteration
        else if (player.PlayerID == "P2" && player1GridSelections.Contains(currentTargetSelection))
        {
            if (OperatingSystem.IsWindows())
            {
                //SoundPlayer soundPlayer = new SoundPlayer("Explosion_Sound.wav");
                //soundPlayer.Load();
                //soundPlayer.Play();
            }
            player.HitCount++;

            player.HitTargets.Add(currentTargetSelection);

            Grid updatedGrid = new Grid(hitTargets: player.HitTargets, missedTargets: player.MissedTargets, 
                currentTarget: currentTargetSelection);

            Console.SetCursorPosition((180 - 43) / 2, 14);

            updatedGrid.CreateGrid();

            Thread.Sleep(3000);
        }
        else
        {
            player.MissedTargets.Add(currentTargetSelection);

            Grid updatedGrid = new Grid(hitTargets: player.HitTargets, missedTargets: player.MissedTargets,
                currentTarget: currentTargetSelection);

            Console.SetCursorPosition((180 - 43) / 2, 14);

            updatedGrid.CreateGrid();

           Thread.Sleep(2000);
        }

        return player.HitCount;
    }

    public static void DisplayGameResults(List<Player> finalResults)
    {
        ShowResultsHeader();

        foreach(var player in finalResults)
        {
            Grid finalGrid = new Grid(hitTargets: player.HitTargets, missedTargets: player.MissedTargets);

            if (player.PlayerID == "P1")
            {
                Console.SetCursorPosition((180 - 43) / 2, Console.CursorTop);
                if (player.HitCount == 5)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("WINNER");
                    Console.ResetColor();
                }

                Console.SetCursorPosition((180 - 43) / 2, Console.CursorTop);
                Console.WriteLine(player.Name);

                finalGrid.CreateGrid();

                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (player.PlayerID == "P2")
            {
                Console.SetCursorPosition((180 - 43) / 2, Console.CursorTop);
                if (player.HitCount == 5)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("WINNER");
                    Console.ResetColor();                   
                }

                Console.SetCursorPosition((180 - 43) / 2, Console.CursorTop);
                Console.WriteLine(player.Name);

                finalGrid.CreateGrid();
            }
        }

        Console.SetCursorPosition(((180 - 43) / 2) + 10, Console.CursorTop);
        Console.WriteLine("Press any key to continue...");

        Console.ReadLine();
    }

    public static List<Player> GetPlayersInfo()
    {
        for (int i = 1; i < 3; i++)
        {
            ShowHeader();

            Grid newGrid = new Grid();

            newGrid.CreateGrid();

            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");

            string playerID = "P" + i;

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
            string name = GetInfoFromConsole(", please enter your name: ");
            List<string> gridSelections = GetGridSelections();

            Player player = new Player(playerID, name, gridSelections);

            players.Add(player);

            Console.Clear();
        }
        return players;
    }

    public static List<string> GetGridSelections()
    {
        List<string> playerGridSelections = new List<string>();
        string playerGridSelection = "";
        bool isSelectionValid;

        
        Console.WriteLine("Please enter your 5 grid selections:\n");

        for (int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(0, 45 + i);
            Console.Write($"{i + 1}. ");
            do
            {
                playerGridSelection = GetInfoFromConsole();
                isSelectionValid = ValidateGridSelection(playerGridSelection, playerGridSelections);

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
                    ClearCurrentConsoleLine();
                    Console.Write($"{i + 1}. ");
                }
                else
                {
                    playerGridSelections.Add(playerGridSelection);
                }

            }
            while (!isSelectionValid);

            Grid updatedGrid = new Grid(playerGridSelections);
            Console.SetCursorPosition((180 - 43) / 2, 14);
            updatedGrid.CreateGrid();

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

        return playerGridSelections;

    }
    public static bool ValidateGridSelection(string currentGridSelection, List<string> gridSelectionList)
    {
        Grid newGrid = new Grid();

        if (!newGrid.GridTable.Contains(currentGridSelection))
        {
            return false;
        }
        else if (gridSelectionList.Contains(currentGridSelection))
        {
            return false;
        }

        else return true;
    }
    public static string GetInfoFromConsole([Optional]string message)
    {
        Console.Write(message);
        string output = Console.ReadLine();
        return output.ToUpper();
    }

    public static void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine(@"       
            . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .
            .                                                                                                                                                       .
            .                       _______   ________   _________  _________  __       ______   ______   ___   ___    ________  ______                             .
            .                     /_______/\ /_______/\ /________/\/________/\/_/\     /_____/\ /_____/\ /__/\ /__/\  /_______/\/_____/\                            .
            .                     \::: _  \ \\::: _  \ \\__.::.__\/\__.::.__\/\:\ \    \::::_\/_\::::_\/_\::\ \\  \ \ \__.::._\/\:::_ \ \                           .
            .                      \::(_)  \/_\::(_)  \ \  \::\ \     \::\ \   \:\ \    \:\/___/\\:\/___/\\::\/_\ .\ \   \::\ \  \:(_) \ \                          .
            .                       \::  _  \ \\:: __  \ \  \::\ \     \::\ \   \:\ \____\::___\/_\_::._\:\\:: ___::\ \  _\::\ \__\: ___\/                          .
            .                        \::(_)  \ \\:.\ \  \ \  \::\ \     \::\ \   \:\/___/\\:\____/\ /____\:\\: \ \\::\ \/__\::\__/\\ \ \                            .
            .                         \_______\/ \__\/\__\/   \__\/      \__\/    \_____\/ \_____\/ \_____\/ \__\/ \::\/\________\/ \_\/                            .
            .                                                                                                                                                       . 
            . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . 

");
    }

    public static void ShowResultsHeader()
    {
        Console.Clear();
        Console.WriteLine(@"
        . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .
        .                                                                                                                                                       .
        .                         _______    ________   ___ __ __   ______       ______    ______   ______   __  __   __     _________  ______                  .
        .                        /______/\  /_______/\ /__//_//_/\ /_____/\     /_____/\  /_____/\ /_____/\ /_/\/_/\ /_/\   /________/\/_____/\                 .
        .                        \::::__\/__\::: _  \ \\::\| \| \ \\::::_\/_    \:::_ \ \ \::::_\/_\::::_\/_\:\ \:\ \\:\ \  \__.::.__\/\::::_\/_                .
        .                         \:\ /____/\\::(_)  \ \\:.      \ \\:\/___/\    \:(_) ) )_\:\/___/\\:\/___/\\:\ \:\ \\:\ \    \::\ \   \:\/___/\               .
        .                          \:\\_  _\/ \:: __  \ \\:.\-/\  \ \\::___\/_    \: __ `\ \\::___\/_\_::._\:\\:\ \:\ \\:\ \____\::\ \   \_::._\:\              .
        .                           \:\_\ \ \  \:.\ \  \ \\. \  \  \ \\:\____/\    \ \ `\ \ \\:\____/\ /____\:\\:\_\:\ \\:\/___/\\::\ \    /____\:\             .
        .                            \_____\/   \__\/\__\/ \__\/ \__\/ \_____\/     \_\/ \_\/ \_____\/ \_____\/ \_____\/ \_____\/ \__\/    \_____\/             .
        .                                                                                                                                                       .
        . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .

");
    }
    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

}

