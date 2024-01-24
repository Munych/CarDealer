using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Car>().HasData(
    //         new User[] 
    //         {
    //             new User { Id=1, Name="Tom", Age=23},
    //             new User { Id=2, Name="Alice", Age=26},
    //             new User { Id=3, Name="Sam", Age=28}
    //         });
    // }
}