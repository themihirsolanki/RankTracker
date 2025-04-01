using Microsoft.EntityFrameworkCore;
using RankTracker.Core.Entities;

namespace RankTracker.EFCore.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure singular table names
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(entityType.Name).ToTable(entityType.ClrType.Name);
        }

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<KeywordRank> KeywordRanks { get; set; }
    public DbSet<SearchEngine> SearchEngines { get; set; }
    public DbSet<Website> Websites { get; set; }
}
