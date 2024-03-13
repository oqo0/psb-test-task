namespace PsbTestTask.Games;

public class GamesManager
{
    private const int WinPoints = 3;
    private const int DrawPoints = 1;

    public int[] GetGameTable(IEnumerable<Game?> games)
    {
        var gameTable = new int[2];

        foreach (var game in games)
        {
            if (game != null)
            {
                UpdateGameTable(gameTable, game.GameResult);
            }
        }

        return gameTable;
    }

    private static void UpdateGameTable(IList<int> gameTable, GameResult gameResult)
    {
        switch (gameResult)
        {
            case GameResult.TeamOneWin:
                gameTable[0] += WinPoints;
                break;
            case GameResult.TeamTwoWin:
                gameTable[1] += WinPoints;
                break;
            case GameResult.Draw:
                gameTable[0] += DrawPoints;
                gameTable[1] += DrawPoints;
                break;
        }
    }
}
