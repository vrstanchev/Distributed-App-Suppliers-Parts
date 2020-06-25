using System;
using System.Collections.Generic;
using System.Linq;
using Suppliers.SuppBusiness.DTOs;
using Suppliers.SuppData;
using Suppliers.SuppModels.Entities;
namespace  Suppliers.SuppBusiness.Services{
public class SuppliersPartsService{
public IEnumerable <SuppliersPartsDTO> GetAllByCity(string city){
using (UnitOfWork unitOfWork = new UnitOfWork())
{
    var suppliersparts=unitOfWork.SuppliersPartsRepository.GetAll(p=>p.City.Contains(city));
    var res=suppliersparts.Select(Sp=>new SuppliersPartsDTO{
Id =Sp.Id,
Quantity=Sp.Quantity,
City=Sp.City,
SuppliersEntity =new SuppliersDTO{
Id=SID,
Name=Sp.SuppliersEntity.Name 

},
PartsEntity=new PartsDTO{
    Id=Sp.Id,
    Part_Name=Sp.Part_Name
    }}).ToList();
return res;
}}






}}