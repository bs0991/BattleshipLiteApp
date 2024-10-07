using ClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Game
    {
        public void Run()
        {
            Console.Title = "Battleship";

            SetConsoleSettings();

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

        private void SetConsoleSettings()
        {
            int consoleWidth = 180;
            int consoleHeight = 67;

            Console.SetWindowSize(consoleWidth, consoleHeight);
        }

        private (int, bool) RunMainMenu()
        {
            string prompt = @"       
            . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .
            .                                                                         |__                                                                           .
            .                                                                         |\/                                                                           .
            .                                                                         ---                                                                           .
            .                                                                         / | [                                                                         .
            .                                                                  !      | |||                                                                         .
            .                                                                _/|     _/|-++'                                                                        .
            .                                                            +  +--|    |--|--|_ |----                                                                  .
            .                                                         { /|__|  |/\__|  |--- |||_^^                                                                  .
            .                                                        +---------------___[}-_===_.'____                 /\                                           .
            .                                                    ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _                                       .
            .                                     __..._____--==/___]_|__|_____________________________[___\==--____,------' .7                                     .
            .                                    |                                                                     BB-61/                                       .
            .                                     \_________________________________________________________________________|                                       .
            .  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /\  /.
            .\/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/  \/ .
            .                                                                                                                                                       .
            .                         _______   ________   _________  _________  __       ______   ______   ___   ___    ________  ______                           .
            .                       /_______/\ /_______/\ /________/\/________/\/_/\     /_____/\ /_____/\ /__/\ /__/\  /_______/\/_____/\                          .
            .                       \::: _  \ \\::: _  \ \\__.::.__\/\__.::.__\/\:\ \    \::::_\/_\::::_\/_\::\ \\  \ \ \__.::._\/\:::_ \ \                         .
            .                        \::(_)  \/_\::(_)  \ \  \::\ \     \::\ \   \:\ \    \:\/___/\\:\/___/\\::\/_\ .\ \   \::\ \  \:(_) \ \                        .
            .                         \::  _  \ \\:: __  \ \  \::\ \     \::\ \   \:\ \____\::___\/_\_::._\:\\:: ___::\ \  _\::\ \__\: ___\/                        .
            .                          \::(_)  \ \\:.\ \  \ \  \::\ \     \::\ \   \:\/___/\\:\____/\ /____\:\\: \ \\::\ \/__\::\__/\\ \ \                          .
            .                           \_______\/ \__\/\__\/   \__\/      \__\/    \_____\/ \_____\/ \_____\/ \__\/ \::\/\________\/ \_\/                          .
            .                                                                                                                                                       .
            . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .

";
            string[] options = { "Play", "Instructions", "Exit" };
            bool isMainMenu = true;

            MenuOptions menu = new MenuOptions(prompt, options, isMainMenu);

            int selectedIndex = menu.SelectOption();

            isMainMenu = false;

            return (selectedIndex, isMainMenu);
        }

        private (int, bool) RunGameInstructions()
        {
            Console.Clear();

            string prompt = @"
            . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .    
            .                                                                                                                                                       .
            .              ________  ___   __    ______   _________  ______    __  __   ______  _________  ________  ______   ___   __    ______                    .
            .             /_______/\/__/\ /__/\ /_____/\ /________/\/_____/\  /_/\/_/\ /_____/\/________/\/_______/\/_____/\ /__/\ /__/\ /_____/\                   .
            .             \__.::._\/\::\_\\  \ \\::::_\/_\__.::.__\/\:::_ \ \ \:\ \:\ \\:::__\/\__.::.__\/\__.::._\/\:::_  \ \\::\_\\  \ \\::::_\/_                 .
            .                \::\ \  \:. `-\  \ \\:\/___/\  \::\ \   \:(_) ) )_\:\ \:\ \\:\ \  __ \::\ \     \::\ \  \:\ \ \ \\:. `-\  \ \\:\/___/\                 .
            .                _\::\ \__\:. _    \ \\_::._\:\  \::\ \   \: __ `\ \\:\ \:\ \\:\ \/_/\ \::\ \    _\::\ \__\:\ \ \ \\:. _    \ \\_::._\:\                .
            .               /__\::\__/\\. \`-\  \ \ /____\:\  \::\ \   \ \ `\ \ \\:\_\:\ \\:\_\ \ \ \::\ \  /__\::\__/\\:\_\ \ \\. \`-\  \ \ /____\:\               .
            .               \________\/ \__\/ \__\/ \_____\/   \__\/    \_\/ \_\/ \_____\/ \_____\/  \__\/  \________\/ \_____\/ \__\/ \__\/ \_____\/               .
            .                                                                                                                                                       .
            . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .                                                                                                                                         
             

                                                                          Welcome to Battlefield Lite!

            
            OBJECT OF THE GAME 

                    >> Be the first to sink all 5 of your opponent's ships
            
            HOW TO PLAY 

                    >> Each player will be given a 5x5 grid (A1 - E5) to select their ship positions

                    >> Each ship position represents a single grid spot (Ex. Ship 1: A1, Ship 2: A3, etc.)

                    >> Each player will then take turns entering their shots to hit their opponent

                    >> Hits are annotated with a red 'X'. Misses are annoated with a white 'O'.

                    >> The first player to hit all 5 of their opponent's ships wins!


                                                                                   GOOD LUCK!

            --------------------------------------------------------------------------------------------------------------------------------------------------------
";
            string[] options = { "Play", "Previous", "Exit" };
            bool isMainMenu = false;

            MenuOptions instructions = new MenuOptions(prompt, options, isMainMenu);

            int selectedIndex = instructions.SelectOption();

            isMainMenu = true;

            return (selectedIndex, isMainMenu);
        }
    }
}
