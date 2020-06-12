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
private readonly SuppliersPartsService SuppliersPartsService;
public SuppliersController()
{
    this.SuppliersPartsService=new SuppliersPartsService();
}
[HttpGet]
public IEnumerable<SuppliersPartsDTO> GetAll([FromQuery] string Name){
    return SuppliersPartsService.GetAll(Name);
}
[HttpGet("{id}")]
public ActionResult<SuppliersPartsDTO> Get([FromRoute] int id){
    var res=SuppliersPartsService.GetById(id);
    if(res==null){
        return NotFound();
    }
    return Ok(res);
}
[HttpPost]
public IActionResult Create([FromBody] SuppliersPartsDTO SuppliersPartsDTO){
    if(!SuppliersPartsDTO.isValid()){
        return BadRequest;
    }
    if(SuppliersPartsService.Create(SuppliersPartsDTO)){
        return NoContent(); 
    }
    return BadRequest();
}
[HttpPut("{id}")]
public IActionResult Update([FromRoute] int id,[FromBody] SuppliersPartsDTO SuppliersPartsDTO){
    if(!SuppliersPartsDTO.isValid()){
        return BadRequest();
    }
    SuppliersPartsDTO.Id=id;
    if(SuppliersPartsDTO.isValid
    ){
        return NoContent();
    }
    return BadRequest();
}
[HttpDelete("{id}")]
public IActionResult Delete ([FromRoute] int id){
if(SuppliersPartsService.Delete(id)){
    return NoContent();
}
return BadRequest();
}

}    

}