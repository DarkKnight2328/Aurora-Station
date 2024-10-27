using AuroraStationApp.Models;
using Microsoft.EntityFrameworkCore;

public class AuroraStationContext : DbContext
{
    public AuroraStationContext(DbContextOptions<AuroraStationContext> options) : base(options) { }

    public DbSet<Giocatore> Giocatori { get; set; }
    public DbSet<Partita> Partite { get; set; }
    public DbSet<Media> Media { get; set; }
}

