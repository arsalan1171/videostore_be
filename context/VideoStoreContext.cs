using Microsoft.EntityFrameworkCore;
namespace videostore_be.Models;

public class VideoStoreContext : DbContext
{
    public VideoStoreContext(DbContextOptions<VideoStoreContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Videos>()
            .Property(v => v.RentalPrice)
            .HasColumnType("decimal(18, 2)");


        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Videos> Videos { get; set; }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<VideosCustomer> VideosCustomer { get; set; }

}