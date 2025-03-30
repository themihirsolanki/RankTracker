namespace RankTracker.Core.Entities;
public class SearchEngine
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
