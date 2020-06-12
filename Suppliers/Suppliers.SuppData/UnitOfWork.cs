using System;
using Suppliers.SuppModels.Entities;
namespace Suppliers.SuppData{
public class UnitOfWork{
private readonly SuppDbContext dbContext;
private BaseRepository<SuppliersPartsEntity> suppliersPartsRepository;
private BaseRepository<PartsEntity> partsRepository;
private BaseRepository<SuppliersEntity> suppliersRepository;
private bool disposed=false;
public UnitOfWork()
{
    this.dbContext=new SuppDbContext();

}
public BaseRepository<SuppliersPartsEntity> SuppliersPartsRepository{
get{
if(this.suppliersPartsRepository==null){
    this.suppliersPartsRepository=new BaseRepository<SuppliersPartsEntity>(dbContext);
}
return suppliersPartsRepository;
}

}
public BaseRepository<SuppliersEntity> SuppliersRepository{
    get{
        if(this.suppliersRepository==null){
            this.suppliersRepository= new BaseRepository<SuppliersEntity>(dbContext);
        }
        return suppliersRepository;
    }
}
public BaseRepository<PartsEntity> PartsRepository{
    get{
        if(this.partsRepository==null){
            this.partsRepository=new BaseRepository<PartsEntity>(dbContext);
        }
        return partsRepository;
    }
}
public bool Save(){
    try
    {
        dbContext.SaveChanges();
        return true;
    }
    catch
    {
        
       return false;
    }
}
public void Dispose(){
    Dispose(true);
    GC.SuppressFinalize(this);
}
protected virtual void Dispose(bool disposing){
if(!this.disposed){
    if(disposing){
        dbContext.Dispose();
    }
    disposed=true;
}

}

}



}