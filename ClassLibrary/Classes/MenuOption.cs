using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MenuOption
    {
        /// <summary>
        /// Displays the menu options on the console, highlighting the selected option.
        /// </summary>
        /// <param name="menu">The menu model containing options and current selection.</param>
        private void DisplayOptions(MenuModel menu)
        {
            Console.WriteLine();
            Console.WriteLine(menu.ASCII);

            for (int i = 0; i < menu.Options.Length; i++)
            {
                string currentOption = menu.Options[i];
                string prefix;

                if (i == menu.SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                }

                //If on the Main Menu and selected index is "Instructions"...
                //PadLeft(99) to center "Instructions"

                if (currentOption == menu.Options[1] && menu.IsMainMenu == true)
                {
                    Console.WriteLine($"{prefix} << {currentOption} >> {prefix}".PadLeft(99));
                }

                //If NOT on Main Menu (Instructions) and selected index is "Previous"...
                //PadLeft(97) to center "Previous"
                else if (currentOption == menu.Options[1] && menu.IsMainMenu == false)
                {
                    Console.WriteLine($"{prefix} << {currentOption} >> {prefix}".PadLeft(97));
                }

                //Set every other menu option to PadLeft(95)
                else
                {
                    Console.WriteLine($"{prefix} << {currentOption} >> {prefix}".PadLeft(95));
                }

            }
            Console.ResetColor();
        }

        /// <summary>
        /// Handles user input to navigate and select an option from the menu.
        /// </summary>
        /// <param name="menu">The menu model containing the options and the selected index.</param>
        /// <returns>The index of the selected option when Enter is pressed.</returns>
        public int SelectOption(MenuModel menu)
        {

            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                DisplayOptions(menu);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    menu.SelectedIndex--;

                    if (menu.SelectedIndex == -1)
                    {
                        menu.SelectedIndex = menu.Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    menu.SelectedIndex++;

                    if (menu.SelectedIndex == menu.Options.Length)
                    {
                        menu.SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return (menu.SelectedIndex);
        }
    }
}
