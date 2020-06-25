using System.ComponentModel.DataAnnotations;
namespace Suppliers.SuppBusiness.DTOs{
public class PartsDTO:BaseDTO, IsValid{
    public string Part_Name { get; set; }
    public bool isValid(){
        return !string.IsNullOrWhiteSpace(Part_Name) && Part_Name.Length<50;
    }
}



}