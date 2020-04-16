using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using PRODUCTS.DTOModels;
using PRODUCTS.BusinessLogic;


namespace PRODUCTS.Controllers
{
    [Route("api/ProductList")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly IProductsListLogic _productLogic;
        public ProductListController(IProductsListLogic productLogic)
        {

               _productLogic = productLogic;

        }

        // GET api/list
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Getstrings()
        {
            return new List<string> { };
        }

        // GET api/list/5
        [HttpGet("{id}")]
        public IEnumerable<ProductDTO> GetAll()//READ
        {
            //DEPENDENCY INJECTION.

            return _productLogic.GetListProducts();
        }

        /*
        // POST api/list
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/list/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/list/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
        */
    }
}