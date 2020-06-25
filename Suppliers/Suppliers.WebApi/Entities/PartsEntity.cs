using System.Collections.Generic;
using Suppliers.WebApi.Entities;
namespace Suppliers.WebApi.Entities{
public class PartsEntity :   BaseEntity{
public int Part_ID { get; set; }
public string Part_Name { get; set; }
public string Color { get; set; }
public double Weight { get; set; }
public virtual ICollection <SuppliersPartsEntity> SP {get;set;}
}
}