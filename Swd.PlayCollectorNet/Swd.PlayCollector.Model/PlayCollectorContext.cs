using Microsoft.EntityFrameworkCore;

namespace Swd.PlayCollector.Model;

public class PlayCollectorContext : DbContext
{
    public DbSet<CollectionItem> CollectionItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        string connectionString = "data source=.;initial catalog=Swd.PlayCollector;integrated security=True;TrustServerCertificate=True;Trusted_Connection=True;";
        
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CollectionItem>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.Property(k => k.Name).IsRequired();
        });
    }
}