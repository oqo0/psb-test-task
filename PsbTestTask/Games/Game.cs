namespace PsbTestTask.Games;

public class Game
{
    public int TeamOneScore { get; }
    public int TeamTwoScore { get; }
    public GameResult GameResult { get; }    

    public Game(int teamOneScore, int teamTwoScore)
    {
        TeamOneScore = teamOneScore;
        TeamTwoScore = teamTwoScore;
        GameResult = GetWinner();
    }
    
    private GameResult GetWinner()
    {
        if (TeamOneScore > TeamTwoScore)
            return GameResult.TeamOneWin;

        if (TeamOneScore < TeamTwoScore)
            return GameResult.TeamTwoWin;

        return GameResult.Draw;
    }

    public static Game? Parse(string data)
    {
        var splitData = data.Split(':');
        if (splitData.Length != 2)
        {
            return null;
        }

        var parseResult = Int32.TryParse(splitData[0], out int teamOneScore) & 
                          Int32.TryParse(splitData[1], out int teamTwoScore);
        if (!parseResult)
        {
            return null;
        }

        return new Game(teamOneScore, teamTwoScore);
    }
}