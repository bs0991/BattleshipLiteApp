using ClassLibrary.Models;
using ClassLibrary;
using System.Media;
using ClassLibrary.Methods;

class Program
{
    public static void Main()
    {
        try
        {

            Game.Run();

            List<PlayerModel> players = Player.GetPlayersInfo();

            List<PlayerModel> finalResults = Game.StartNewGame(players);

            ConsoleHelper.PrintGameResults(finalResults);

            Main();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

}

