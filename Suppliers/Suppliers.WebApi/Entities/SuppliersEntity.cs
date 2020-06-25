using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Suppliers.WebApi.Entities{
    public class SuppliersEntity :   BaseEntity {
        
public int SID { get; set; }
public string Name{get;set;}
public double  Rating { get; set; }
public string City { get; set; }
public string Phone { get; set; }

public virtual ICollection <SuppliersPartsEntity>  SP {get;set;}
    }
}