using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using PRODUCTS.BusinessLogic;
using PRODUCTS.DTOModels;

namespace PRODUCTS.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductLogic _productLogic;
        public ProductController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        // GET api/product
        [HttpGet]
        public List<ProductDTO> GetAll()
        {
            return _productLogic.GetAll();
        }
        
        // POST api/product
        [HttpPost]
        [Route("product")]
        public void Post([FromBody] ProductDTO newproductDTO)
        {
            _productLogic.CreateProduct(newproductDTO);
        }

        // PUT api/product/5
        [HttpPut]
        [Route("product/{id}")]
        public void Put(string id,[FromBody] ProductDTO updateProduct)
        {
            _productLogic.updateProduct(updateProduct, id);
        }

        // DELETE api/product/5
        [HttpDelete]
        [Route("product/{id}")]
        public void Delete(string id)
        {
            _productLogic.deleteProduct(id);
        }
        
    }
}