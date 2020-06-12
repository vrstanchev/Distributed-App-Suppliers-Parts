using Suppliers.SuppModels.Entities;
using Microsoft.EntityFramework.Core;
namespace Suppliers.SuppData{
public class SuppDbContext : DbContext{
public SuppDbContext():base()
{
    
}
public virtual DbSet<PartsEntity> Parts {get;set;}
public virtual DbSet<SuppliersEntity> Suppliers {get;set;}
public virtual DbSet<SuppliersPartsEntity> SuppliersParts {get;set;}
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
optionsBuilder
.UseLazyLoadingProxies()
.SqlServer(@"Server;"+
           @"DataBase=SuppliersDB;" +
            @"Integrated Security=true;"  );
            base.OnConfiguring(optionsBuilder);
}
protected override void OnModelCreating(ModelBuilder modelBuilder){
modelBuilder.Entity<SuppliersEntity>()
.Property(g =>g.Name)
.HasMaxLength(50)
.isRequired();

modelBuilder.Entity<SuppliersPartsEntity>()
.HasOne(p=>p.SuppliersEntity)
.WithMany(m=>m.SuppliersPartsEntity)
.HasForeignKey(l=>l.SID)
.OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<SuppliersPartsEntity>()
.HasOne(p=>p.PartsEntity)
.WithMany(m=>m.SuppliersPartsEntity)
.HasForeignKey(l=>l.Part_ID)
.OnDelete(DeleteBehavior.Restrict);

base.OnModelCreating(modelBuilder);
}

}




}