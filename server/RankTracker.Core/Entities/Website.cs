namespace RankTracker.Core.Entities;

public class Website
{
    public int Id { get; set; }
    public required string Domain { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
