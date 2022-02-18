namespace CommonDatabase.Entities;

public partial record MatchStatistic
{
    public long Id { get; set; }
    public long IdMatch { get; set; }
    public bool Over05 { get; set; }
    public bool Over15 { get; set; }
    public bool Over25 { get; set; }
    public bool Over35 { get; set; }
    public bool Under05 { get; set; }
    public bool Under15 { get; set; }
    public bool Under25 { get; set; }
    public bool Under35 { get; set; }
}