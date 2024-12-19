using Microsoft.EntityFrameworkCore;
using OMS.DataAccess.Entities;

namespace OMS.DataAccess;

public class OMSDbContext : DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderItem> Customers { get; set; }

    public OMSDbContext(DbContextOptions options) : base(options)
    {
    }
}
