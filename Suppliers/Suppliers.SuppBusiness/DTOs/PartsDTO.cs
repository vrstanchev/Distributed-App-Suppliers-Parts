using System.ComponentModel.DataAnnotations;
namespace Suppliers.SuppBusiness{
public class PartsDTO:BaseDTO, isValid{
    public string Part_Name { get; set; }
    public bool isValid(){
        return !string.IsNullOrWhiteSpace(Part_Name) && Part_Name.Length<50;
    }
}



}