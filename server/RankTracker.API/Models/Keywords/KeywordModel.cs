namespace RankTracker.API.Models.Keywords;

public class KeywordModel
{
    public int Id { get; set; }
    public string Keyword { get; set; }
    public int? GoogleRank { get; set; }
    public int? BingRank { get; set; }
    public DateTime DateUpdated { get; set; }
}
