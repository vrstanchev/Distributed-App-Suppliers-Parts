namespace Suppliers.SuppBusiness{
public class SuppliersDTO:BaseDTO,isValid {
public string Name { get; set; }
public bool isValid(){
    return !string.IsNullOrWhiteSpace(Name) && Name.Length<50;
}
}

}