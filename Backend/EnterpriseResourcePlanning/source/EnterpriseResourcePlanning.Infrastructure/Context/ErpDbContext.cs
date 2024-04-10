using EnterpriseResourcePlanning.Domain.Entities;
using EnterpriseResourcePlanning.Infrastructure.ConvertType;

using Microsoft.EntityFrameworkCore;

namespace EnterpriseResourcePlanning.Infrastructure.Context;

public sealed class ErpDbContext : DbContext
{
    public DbSet<Products> Products { get; set; }

    public ErpDbContext(DbContextOptions<ErpDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var products = modelBuilder.Entity<Products>();
        products.Property(p => p.Id).HasConversion(new CustomerIdConvert()).HasColumnName("ProductId");
        products.Property(p => p.ProductName).HasMaxLength(150).HasColumnName("ProductName");
        products.Property(p => p.ProductCode).HasMaxLength(50).HasColumnName("ProductCode");
        products.Property(p => p.Price).HasColumnType("decimal(10,2)");
        
    }
}
