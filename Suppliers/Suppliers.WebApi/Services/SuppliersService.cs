using System;
using System.Collections.Generic;
using System.Linq;
using Suppliers.WebApi.DTOs;
using Suppliers.WebApi.SuppData;
using Microsoft.EntityFrameworkCore;
using Suppliers.WebApi.Entities;

namespace  Suppliers.WebApi.Services{
public class SuppliersService {
public IEnumerable<SuppliersDTO> GetAll(string Name=null){
using (UnitOfWork unitOfWork=new UnitOfWork())
{
    var suppliers=Name!=null
    ? unitOfWork.SuppliersRepository.GetAll(p=>p.Name==Name)
    : unitOfWork.SuppliersRepository.GetAll();
    return suppliers.Select(supplier=>new SuppliersDTO{
       Id=supplier.Id,
       Name=supplier.Name 
    });
}

}
public SuppliersDTO GetById(int id){
    using (UnitOfWork unitOfWork = new UnitOfWork()){
var supplier=unitOfWork.SuppliersRepository.GetById(id);
return supplier==null ? null : new SuppliersDTO{
    Id=supplier.Id,
Name=supplier.Name
};}}
public bool Create(SuppliersDTO suppliersDTO){
using (UnitOfWork unitOfWork=new UnitOfWork()){
var supplier=new Suppliers(){
    Name=supplier.Name,
    CreatedOn=DateTime.Now
};
unitOfWork.SuppliersRepository.Create(supplier);
return unitOfWork.Save();
}
}
public bool Update(SuppliersDTO suppliersDTO){
using (UnitOfWork unitOfWork=new UnitOfWork()){
var res=unitOfWork.SuppliersRepository.GetById(suppliersDTO.Id);
if(res==null){
    return false;
}
res.Name=suppliersDTO.Name;
res.UpdatedOn=DateTime.Now;
unitOfWork.SuppliersRepository.Update(res);
return unitOfWork.Save();
}} 
public bool Delete(int id){
using (UnitOfWork unitOfWork= new UnitOfWork())
{
    SuppliersEntity res=unitOfWork.SuppliersRepository.GetById(id);
    if (res==null)
    {
        return false;
    }
unitOfWork.SuppliersRepository.Delete(res);
return unitOfWork.Save();
}

}

   
    


}





}