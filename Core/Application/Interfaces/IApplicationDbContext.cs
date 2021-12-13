//using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Users> Users { get; set; }
    DbSet<Tenants> Tenants { get; set; }
    DbSet<Apartments> Apartments { get; set; }
    DbSet<Rooms> Rooms { get; set; }
    DbSet<Payements> Payements { get; set; }
    Task<int> SaveChanges();
}