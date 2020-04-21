using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRODUCTS.DTOModels;
using PRODUCTS.BusinessLogic;
using PRODUCTS.DataBase.Models;
using PRODUCTS.DataBase;


namespace PRODUCTS.Controllers
{
    [Route("api/ProductList")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly IProductsListLogic _productLisLogic;
         private readonly IProductsDB  _productTableDB;
        public ProductListController(IProductsListLogic productListLogic, IProductsDB productTableDB)
        {

            _productLisLogic = productListLogic;
            _productTableDB = productTableDB;

        }

        // GET api/list/5
        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()//READ
        {
            //DEPENDENCY INJECTION.

            return _productLisLogic.GetListProducts();
        }

        [HttpPost]
        public Product Post ([FromBody] Product product)
        {       
            return _productLisLogic.CreateProduct(product);
        }

         [HttpPut("{id}")]
        public Product Put(string id,[FromBody] Product product)
        {
            return _productLisLogic.updateProduct(id, product.Name, product.Type, product.Stock );
        }

        [HttpDelete("{id}")]
        public Product Delete(string id)
        {
            return _productLisLogic.deleteProduct(id);
        }

    }
}