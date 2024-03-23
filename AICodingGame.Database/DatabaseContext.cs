using AICodingGame.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace AICodingGame.Database;

public class DatabaseContext: DbContext
{
    public virtual DbSet<Battles> Battles { get; set; }
    public virtual  DbSet<Robot> Robots { get; set; }
    public virtual DbSet<BattleInfo> BattleInfo { get; set; }
    
    public DatabaseContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlServer("Server=localhost;Database=AICodingGame;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}