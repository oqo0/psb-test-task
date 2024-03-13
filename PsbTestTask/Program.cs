using PsbTestTask.Games;

namespace PsbTestTask;

public static class Program
{
    public static void Main()
    {
        var games = GetGamesFromUserInput();

        DisplayGameResults(games);
    }

    private static List<Game?> GetGamesFromUserInput()
    {
        Console.WriteLine("Введите список матчей (<команда 1>:<команда 2>, <команда 1>:<команда 2> ...)");
        var gamesInput = Console.ReadLine();

        if (string.IsNullOrEmpty(gamesInput))
        {
            return [];
        }

        var gamesInputData = gamesInput.Split(", ");
        var games = gamesInputData.Select(Game.Parse).ToList();

        return games;
    }

    private static void DisplayGameResults(List<Game?> games)
    {
        var gameManager = new GamesManager();
        var gameTable = gameManager.GetGameTable(games);

        Console.WriteLine($"Команда №1 - {gameTable[0]}, Команда №2 - {gameTable[1]}");
    }
}
