using AICodingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Context;

public class GameContext: DbContext
{
    public  virtual DbSet<Battle> Battles { get; set; }
    public  virtual DbSet<Robot> Robots { get; set; }
    public  virtual DbSet<Statistic> Statistics { get; set; }
    public  virtual DbSet<BattleMember> BattleMembers { get; set; }
    public  virtual DbSet<MemberBattleStatistic> BattleStatistics { get; set; }

    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Robot>().HasAlternateKey(r => new { r.ProjectPath });
        base.OnModelCreating(modelBuilder);
    }
}