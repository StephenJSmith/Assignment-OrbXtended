using System.Security.Cryptography.X509Certificates;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      options.UseInMemoryDatabase(databaseName: "TopProductsDB");
    }

    // protected override void OnModelCreating(ModelBuilder builder) {
    //     builder.Entity<Product>()
    //         .HasMany(p => p.Simulators)
    //         .WithMany(s => s.Products)
    //         .UsingEntity<ProductSimulator>();
    // }

    public DbSet<Product> Products { get; set; }
    public DbSet<Simulator> Simulators {get; set;}
    public DbSet<ProductSimulator> ProductSimulators { get; set;}
}
