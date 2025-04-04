﻿namespace RankTracker.Core.Entities;

public class Keyword
{
    public int Id { get; set; }
    public int WebsiteId { get; set; }

    public required string Text { get; set; }
    
    public int? GoogleRank { get; set; }
    public int? BingRank { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
