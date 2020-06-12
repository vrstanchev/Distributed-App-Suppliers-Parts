namespace Suppliers.SuppBusiness{
    public class SuppliersPartsDTO:BaseDTO,isValid{
  public string Name { get; set; }
public string Part_Name { get; set; }
public int SID { get; set; }
public int Part_ID { get; set; }
   public string City { get; set; }
   public bool isValid(){
return string.IsNullOrWhiteSpace(City) && City.Length<100;

   }
   
    }

}