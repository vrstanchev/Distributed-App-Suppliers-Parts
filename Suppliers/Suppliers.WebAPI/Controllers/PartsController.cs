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
private readonly PartsService partsService;
public SuppliersController()
{
    this.partsService=new PartsService();
}
[HttpGet]
public IEnumerable<PartsDTO> GetAll([FromQuery] string p_name){
    return PartsService.GetAll(p_name);
}
[HttpGet("{id}")]
public ActionResult<PartsDTO> Get([FromRoute] int id){
    var res=PartsService.GetById(id);
    if(res==null){
        return NotFound();
    }
    return Ok(res);
}
[HttpPost]
public IActionResult Create([FromBody] PartsDTO partsDTO){
    if(!partsDTO.isValid()){
        return BadRequest;
    }
    if(PartsService.Create(PartsDTO)){
        return NoContent(); 
    }
    return BadRequest();
}
[HttpPut("{id}")]
public IActionResult Update([FromRoute] int id,[FromBody] PartsDTO PartsDTO){
    if(!PartsDTO.isValid()){
        return BadRequest();
    }
    PartsDTO.Id=id;
    if(PartsDTO.isValid
    ){
        return NoContent();
    }
    return BadRequest();
}
[HttpDelete("{id}")]
public IActionResult Delete ([FromRoute] int id){
if(PartsService.Delete(id)){
    return NoContent();
}
return BadRequest();
}

}    

}