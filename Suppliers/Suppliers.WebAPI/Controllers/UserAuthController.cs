using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Suppliers.WebAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Suppliers.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
private IConfiguration _config;
[HttpGet]
public IActionResult UserAuth(string username, string pass){
User user=new User();
user.Username=username;
user.Password=pass;
IActionResult response= Unauthorized();
var us = AuthenticateUser(user);
if (us!=null)
{
    var tokenStr=GenerateJSONWebToken(us);
    response = Ok(new {token=tokenStr});

}
return response;
}

private User AuthenticateUser(User u){
    User usr=null;
    if(u.Username=="user1" && u.Password=="testpass"){
        usr=new User{Username="User1",Password="testpass"};
    }
    return usr;
}
private string GenerateJSONWebToken(User uinfo){
    var SecKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    var credentials=new SigningCredentials(SecKey,SecurityAlgorithms.HmacSha256);

    var claims = new[]{
new Claim(JwtRegisteredClaimNames.Sub,uinfo.Username),
new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

    };
    var token=new JwtSecurityToken(
        issuer:_config["Jwt:Issuer"],
        audience:_config["Jwt:Issuer"],
        claims,
        expires:DateTime.Now.AddMinutes(120),
        signingCredentials: credentials
    );
    var encodetoken=new JwtSecurityTokenHandler().WriteToken(token);
    return encodetoken;
}
[Authorize]
[HttpPost("Post")]
public string Post(){
    var identity=HttpContext.User.Identity as ClaimsIdentity;
    IList<Claim> claim=identity.Claims.ToList();
    var userName = claim[0].Value;
    return "Wellcome To:" + userName;
}
[HttpGet("GetValue")]
public ActionResult<IEnumerable<string>> Get(){
    return new string[]{"Value1","Value2","Value3"};
}
    }
    
    }