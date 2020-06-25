namespace Suppliers.SuppBusiness.DTOs{
public class SuppliersDTO:BaseDTO,IsValid {
public string Name { get; set; }
public bool isValid(){
    return !string.IsNullOrWhiteSpace(Name) && Name.Length<50;
}
}

}