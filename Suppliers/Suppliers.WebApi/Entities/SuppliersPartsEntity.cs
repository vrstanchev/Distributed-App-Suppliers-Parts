namespace Suppliers.WebApi.Entities{
    public class SuppliersPartsEntity :  BaseEntity{
public int SID { get; set; }
public int Part_ID { get; set; }
public int Quantity { get; set; }
public string City{get;set;}
public virtual PartsEntity PartsEntity { get;set; }
public virtual SuppliersEntity SuppliersEntity {get;set;}

    }
}
