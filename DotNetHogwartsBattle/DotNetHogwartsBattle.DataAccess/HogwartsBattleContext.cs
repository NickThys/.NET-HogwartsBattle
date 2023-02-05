using DotNetHogwartsBattle.Common;
using DotNetHogwartsBattle.Domain;
using DotNetHogwartsBattle.Domain.Cards;
using Microsoft.EntityFrameworkCore;

namespace DotNetHogwartsBattle.DataAccess;

public class HogwartsBattleContext : DbContext
{
    public HogwartsBattleContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Villain> Villains { get; set; }
    public DbSet<DarkArts> DarkArts { get; set; }
    public DbSet<Hero> Heros { get; set; }
    public DbSet<StartHero> StartHeros { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Hogwarts> Hogwarts { get; set; }
    public DbSet<PlayerBoard> PlayerBoards { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Villain>("Villain")
            .HasValue<DarkArts>("DarkArts")
            .HasValue<Hero>("Hero")
            .HasValue<StartHero>("StartHero")
            .HasValue<Hogwarts>("Hogwarts")
            .HasValue<Location>("Location");

        modelBuilder.Entity<TriggerEvent>().HasKey(cha => new { cha.TriggerId, cha.Event });
        modelBuilder.Entity<TriggerEvent>()
            .HasOne(cha => cha.Trigger)
            .WithMany(tag => tag.Events)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(cha => cha.TriggerId);

        modelBuilder.Entity<TriggerTriggeredBy>().HasKey(cha => new { cha.TriggerId, cha.CardType });
        modelBuilder.Entity<TriggerTriggeredBy>()
            .HasOne(cha => cha.Trigger)
            .WithMany(tag => tag.TriggertBy)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(cha => cha.TriggerId);

        base.OnModelCreating(modelBuilder);
    }
}