using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Suppliers.WebSite{
public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions options)
    :base(options)
    {
        
    }
public DbSet<Supplier>  Suppliers { get; set; }

}




}










