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
  //  [Route("api/ProductList")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly IProductsListLogic _productLisLogic;
        public ProductListController(IProductsListLogic productListLogic)
        {

            _productLisLogic = productListLogic;

        }

        
        [HttpGet]
        [Route("product/product-list")]
        public IEnumerable<ProductDTO> GetAll()//READ
        {
            //DEPENDENCY INJECTION.

            return _productLisLogic.GetListProducts();
        }
    }
}