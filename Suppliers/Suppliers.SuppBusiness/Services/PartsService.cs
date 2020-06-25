using System;
using System.Collections.Generic;
using System.Linq;
using Suppliers.SuppBusiness.DTOs;
using Suppliers.SuppData;
using Suppliers.SuppModels.Entities;
namespace  Suppliers.SuppBusiness.Services{
public class PartsService{
public IEnumerable<PartsDTO>GetAllByName(string part_name){
using (UnitOfWork unitOfWork=new UnitOfWork())
{
    var parts=unitOfWork<PartsRepository>GetAll(g=>g.Part_Name=part_name);
    return parts.Select(part=>new PartsDTO{
    Id=part.Id,
    part_name=part.Part_Name
    });
}
}
public IEnumerable<PartsDTO>GetAll(){
using (UnitOfWork unitOfWork=new UnitOfWork())
{
    var parts=unitOfWork.PartsRepository.GetAll();
    return parts.Select(part=> new PartsDTO {
        Id=part.Id,
    part_name=part.Part_Name

    });
}}
public PartsDTO GetById(int id){
using (UnitOfWork unitOfWork=new UnitOfWork()){
var part=unitOfWork.PartsRepository.GetById(id);
return part==null ? null : new PartsDTO{
 Id=part.Id,
    part_name=part.Part_Name
};

}

}
public bool Create(PartsDTO partsDTO){
using (UnitOfWork unitOfWork=new UnitOfWork()){
var part=new Suppliers(){
    Name=part.Part_Name,
    CreatedOn=DateTime.Now
};
unitOfWork.SuppliersRepository.Create(part);
return unitOfWork.Save;
}
}
public bool Update(PartsDTO partsDTO){
using (UnitOfWork unitOfWork=new UnitOfWork()){
var res=unitOfWork.PartsRepository.GetById(partsDTO.Id);
if(res==null){
    return false;
}
res.Name=partsDTO.Part_Name;
res.UpdatedOn=DateTime.Now;
unitOfWork.PartsRepository.Update(res);
return unitOfWork.Save;
}} 
public bool Delete(int id){
using (UnitOfWork unitOfWork=new UnitOfWork())
{
    Parts res=unitOfWork.PartsRepository.GetById(id);
    if (res==null)
    {
        return false;
    }
unitOfWork.PartsRepository.Delete(res);
return unitOfWork.Save();
}

}




}

}