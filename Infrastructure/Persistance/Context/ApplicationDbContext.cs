//using Application;
//using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Apartments> Apartments { get; set; }
    public DbSet<Rooms> Rooms { get; set; }
    public DbSet<Tenants> Tenants { get; set; }
    public DbSet<Payements> Payements { get; set; }
    public async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}