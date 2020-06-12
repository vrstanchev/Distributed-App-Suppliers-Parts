using System.Collections.Generic;
using Suppliers.SuppBusiness.DTOs;
using Suppliers.SuppBusiness.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace  Suppliers.WebAPI.Controllers{
[Route("api/[Controller]")]
[Authorize]
[ApiController]
public class SuppliersController:ControllerBase{
private readonly SuppliersService suppliersService;
public SuppliersController()
{
    this.suppliersService=new SuppliersService();
}
[HttpGet]
public IEnumerable<SuppliersDTO> GetAll([FromQuery] string Name){
    return suppliersService.GetAll(Name);
}
[HttpGet("{id}")]
public ActionResult<SuppliersDTO> Get([FromRoute] int id){
    var res=suppliersService.GetById(id);
    if(res==null){
        return NotFound();
    }
    return Ok(res);
}
[HttpPost]
public IActionResult Create([FromBody] SuppliersDTO suppliersDto){
    if(!suppliersDto.isValid()){
        return BadRequest;
    }
    if(suppliersService.Create(suppliersDto)){
        return NoContent(); 
    }
    return BadRequest();
}
[HttpPut("{id}")]
public IActionResult Update([FromRoute] int id,[FromBody] SuppliersDTO suppliersDTO){
    if(!suppliersDTO.isValid()){
        return BadRequest();
    }
    suppliersDTO.Id=id;
    if(suppliersDTO.isValid
    ){
        return NoContent();
    }
    return BadRequest();
}
[HttpDelete("{id}")]
public IActionResult Delete ([FromRoute] int id){
if(suppliersService.Delete(id)){
    return NoContent();
}
return BadRequest();
}

}    

}