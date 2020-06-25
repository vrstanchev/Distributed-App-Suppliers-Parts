using System.Collections.Generic;
namespace Suppliers.SuppModels.Entities{
    public class SuppliersEntity : BaseEntity {
        
public int SID { get; set; }
public string Name{get;set;}
public double  Rating { get; set; }
public string City { get; set; }
public string Phone { get; set; }

public virtual ICollection <SuppliersPartsEntity> SP {get;set;}
    }
}