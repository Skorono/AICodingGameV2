using AICodingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.DAL.Context;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
        Database.Migrate();
    }

    public virtual DbSet<Battle> Battles { get; set; }
    public virtual DbSet<Robot> Robots { get; set; }
    public virtual DbSet<Statistic> Statistics { get; set; }
    public virtual DbSet<BattleMember> BattleMembers { get; set; }
    public virtual DbSet<BattleStatus> BattleStatuses { get; set; }
    public virtual DbSet<MemberBattleStatistic> BattleStatistics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Robot>().HasAlternateKey(r => new { r.ProjectPath });
        modelBuilder.Entity<BattleStatus>().HasData(new List<BattleStatus>()
        {
            new() { Id = 1,  Name = "Завершён"},
            new() { Id = 2, Name = "Идёт" },
            new() { Id = 3, Name = "Удалён" },
            new() { Id = 4, Name = "Прерван" }
        });
        base.OnModelCreating(modelBuilder);
    }
}