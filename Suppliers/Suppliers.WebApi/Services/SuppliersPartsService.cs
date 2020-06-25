using System;
using System.Collections.Generic;
using System.Linq;
using Suppliers.WebApi.DTOs;
using Suppliers.WebApi.SuppData;
using Suppliers.WebApi.Entities;
namespace  Suppliers.WebApi.Services{
public class SuppliersPartsService {
public IEnumerable <SuppliersPartsDTO> GetAllByCity(string city){
using (UnitOfWork unitOfWork = new UnitOfWork())
{
    var suppliersparts=unitOfWork.SuppliersPartsRepository.GetAll(p=>p.City.Contains(city));
    var res=suppliersparts.Select(Sp=>new SuppliersPartsDTO{
Id =Sp.Id,
Quantity=Sp.Quantity.ToString(),
City=Sp.City,
SuppliersEntity =new SuppliersDTO{
Id=Sp.SID,
Name=Sp.Name 

},
PartsEntity=new PartsDTO{
    Id=Sp.Id,
    Part_Name=Sp.Part_Name
    }}).ToList();
return res;
}}






}}