using System;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

namespace ClassLibrary
{
    public class MenuOptions
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private bool IsMainMenu;

        public MenuOptions(string prompt, string[] options, bool isMainMenu)
        {
            Prompt = prompt;
            Options = options;
            IsMainMenu = isMainMenu;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            Console.WriteLine();
            Console.WriteLine(Prompt);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (currentOption == Options[1] && IsMainMenu == true)
                {
                    Console.WriteLine($"{prefix} << {currentOption} >> {prefix}".PadLeft(99));                   
                }
                else if (currentOption == Options[1] && IsMainMenu == false)
                {
                    Console.WriteLine($"{prefix} << {currentOption} >> {prefix}".PadLeft(97));                   
                }
                else
                {
                    Console.WriteLine($"{prefix} << {currentOption} >> {prefix}".PadLeft(95));
                }
               
            }
            Console.ResetColor();
        }

        public int SelectOption()
        {
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update SelectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;

                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;

                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            
            return (SelectedIndex);
        }

    }
}
