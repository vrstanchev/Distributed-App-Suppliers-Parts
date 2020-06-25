using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Suppliers.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
namespace Suppliers.WebApi.SuppData{
public class SuppDbContext : DbContext{
public SuppDbContext():base()
{
    
}
public virtual DbSet<PartsEntity> Parts {get;set;}
public virtual DbSet<SuppliersEntity> Suppliers {get;set;}
public virtual DbSet<SuppliersPartsEntity> SP {get;set;}
protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
  =>  optionBuilder.UseSqlite(@"Data Source=Suppliers.db");
   
protected override void OnModelCreating(ModelBuilder modelBuilder){
modelBuilder.Entity<SuppliersEntity>()
.Property(g =>g.Name)
.HasMaxLength(50)
.IsRequired();

modelBuilder.Entity<SuppliersPartsEntity>()
.HasOne(p=>p. SuppliersEntity)
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
