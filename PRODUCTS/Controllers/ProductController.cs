using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PRODUCTS.BusinessLogic;
using PRODUCTS.DTOModels;

namespace PRODUCTS.Controllers
{
    //[Route("Products")]
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
        [Route("product")]
        public List<ProductDTO> GetAll()
        {
            return _productLogic.GetAll();
        }
         //<response code="201">Returns the newly created item</response>

        // POST api/product
        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]

        [Route("product")]
        public ProductDTO Post([FromBody] ProductDTO newproductDTO)
        {
           // Console.WriteLine("End point");
            return _productLogic.CreateProduct(newproductDTO);
        }

        // PUT api/product/5
        [HttpPut]
        [Route("product/{id}")]
        public ProductDTO Put(string id,[FromBody] ProductDTO updateProduct)
        {
           return _productLogic.updateProduct(updateProduct, id);
        }

        // DELETE api/product/5
        [HttpDelete]
        [Route("product/{id}")]
        public bool Delete(string id)
        {
            return _productLogic.deleteProduct(id);
        }
    }
}