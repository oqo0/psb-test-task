namespace PsbTestTask.Games;

public class GamesManager
{
    public int[] GetGameTable(IList<Game?> games)
    {
        // типа таблица игр
        var result = new int[2];

        foreach (var game in games)
        {
            if (game is null)
                continue;
                
            switch (game.GameResult)
            {
                case GameResult.TeamOneWin:
                    result[0] += 3;
                    break;
                case GameResult.TeamTwoWin:
                    result[1] += 3;
                    break;
                case GameResult.Draw:
                    result[0]++;
                    result[1]++;
                    break;
            }
        }

        return result;
    }
}