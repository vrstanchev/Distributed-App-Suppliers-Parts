using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Suppliers.WebAPI.Models;
namespace Suppliers.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SupplierContext _db;
        

   static List<string> strings = new List<string>{
       "Mitko","Petko","Pavel"
   };
   [HttpGet]
        public IEnumerable<string> Get()
        {
          return strings;
        }
        public string Get(int id){
            return strings[id];
        }
        public void Post([FromBody]string value){
            strings.Add(value);
        }
        public void Put(int id,[FromBody]string value){
            strings[id]=value;
        }
        public void Delete(int id){
            strings.RemoveAt(id);
        }
      //
    }
}
