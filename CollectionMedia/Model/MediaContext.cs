using Microsoft.EntityFrameworkCore;
using Model;

namespace Swd.PlayCollector.Model;

public class MediaContext : DbContext
{
    public DbSet<Media> MediaItem { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        string connectionString = "data source=.;initial catalog=Swd.TestMediaItem;integrated security=True;TrustServerCertificate=True;Trusted_Connection=True;";
        
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.ApplyConfiguration(new MediaItemConfig());
        modelBuilder.ApplyConfiguration(new DocumentTypeConfig());

    }
}