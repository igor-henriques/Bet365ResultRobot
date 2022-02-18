namespace CommonDatabase.Entities;

public partial record Match
{
    public long Id { get; set; }
    public long IdCompetition { get; set; }
    public long? IdChallenge { get; set; }
    public long? IdFixture { get; set; }
    public string Title { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime UserDate { get; set; }
    public int IdTeamHome { get; set; }
    public int IdTeamAway { get; set; }
    public int IdTeamWinnerHalfTime { get; set; }
    public int IdTeamWinner { get; set; }
    public int IdTeamScoreFirst { get; set; }
    public string HalfTimeResult { get; set; } = null!;
    public string FinalTimeResult { get; set; } = null!;
    public byte HalfTimeHomeScore { get; set; }
    public byte HalfTimeAwayScore { get; set; }
    public bool HalfTimeDraw { get; set; }
    public bool FinalTimeDraw { get; set; }
    public byte HomeScore { get; set; }
    public byte AwayScore { get; set; }
    public byte SumScore { get; set; }
    public int? IdTeamScoreLast { get; set; }
    public string? PositionFirstGoalscorer { get; set; }
}