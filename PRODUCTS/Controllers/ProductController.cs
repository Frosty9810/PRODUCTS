using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using PRODUCTS.DTOModels;

namespace PRODUCTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        // GET api/product
        [HttpGet("")]
        public IEnumerable<string> GetAll()
        {
            return new List<string> { };
        }
        /*
        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<string> GetstringById(int id)
        {
            return null;
        }
*/
        // POST api/product
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
        
    }
}