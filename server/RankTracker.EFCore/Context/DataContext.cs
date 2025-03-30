using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;

namespace RankTracker.EFCore.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("RankTracker");
    }

    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<KeywordRank> KeywordRanks { get; set; }
    public DbSet<SearchEngine> SearchEngines { get; set; }
    public DbSet<Website> Websites { get; set; }
}
