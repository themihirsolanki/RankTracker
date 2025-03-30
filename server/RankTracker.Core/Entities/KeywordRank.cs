namespace RankTracker.Core.Entities;
public class KeywordRank
{
    public int Id { get; set; }
    public int KeywordId { get; set; }
    public int SearchEngineId { get; set; }
    public int Rank { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }

}
