using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suppliers.WebApi.DTOs;
using Suppliers.WebApi.Services;
namespace Suppliers.WebApi.Controllers{
[Route("api/[controller]")]
 [ApiController]     
public class SupplierController: ControllerBase {
private readonly SuppliersService suppliersService;
public SupplierController()
{
    this.suppliersService= new SuppliersService();
}
//Get: api/suppliers
[HttpGet]
public IEnumerable<SuppliersDTO> GetAll([FromQuery] string fname){
    return suppliersService.GetAll(fname);
}
[HttpGet("{id}")]
public ActionResult<SuppliersDTO> Get([FromRoute] int id){
var res=suppliersService.GetById(id);
if (res==null)
{
    return NotFound();
}
return Ok(res);

}
[HttpPost]
public IActionResult Create([FromBody] SuppliersDTO suppliersDTO ){
    if (!suppliersDTO.isValid()){
        return BadRequest();
    }
    if (suppliersService.Create(suppliersDTO))
    {
        return NoContent();
    }
    return BadRequest();
}
[HttpPut("{temp}")]
public IActionResult Update([FromRoute] int id, [FromBody] SuppliersDTO suppliersDTO){
if (!suppliersDTO.isValid())
{
    return BadRequest();
}
suppliersDTO.Id=id;
if (suppliersService.Update(suppliersDTO))
{
    return NoContent();
}
return BadRequest();

}
[HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id){
if (suppliersService.Delete(id))
{
    return NoContent();
}
return BadRequest();
}


}

}