using Microsoft.EntityFrameworkCore;
namespace Suppliers.WebAPI.Models{
    public class SupplierContext : DbContext{
public SupplierContext(DbContextOptions<SupplierContext> options)
:base(options)
{}
public DbSet<Supplier> Suppliers {get;set;}

    }
}