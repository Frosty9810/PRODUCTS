using System.Collections.Generic;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase;
using PRODUCTS.DataBase.Models;
using Microsoft.Extensions.Logging;
using Serilog;


namespace PRODUCTS.BusinessLogic
{
    public class ProductsListLogic : IProductsListLogic
    {
        private readonly IProductListDBManager _productListDBManager;
        public readonly ILogger<ProductListDBManager> _logger;

        public ProductsListLogic(IProductListDBManager productListDBManager, ILogger<ProductListDBManager> logger) 
        {

            _productListDBManager = productListDBManager;
            _logger = logger;
        }

        public List<ProductDTO> GetListProducts() 
        {
            _logger.LogInformation("Getting all Product Lists");
            return DTOUtil.MapProductDTOList(_productListDBManager.GetAll());
        }

        private List<ProductDTO> GetEmptyList() 
        {
            _logger.LogInformation("Getting empty Product Lists");
            List<ProductDTO> emptyList = new List<ProductDTO>();
            return emptyList;
        }

        private void addToList(List<ProductDTO> listToAdd, Product product) 
        {
           listToAdd.Add(new ProductDTO() { Name = product.Name , Type = product.Type, Code = product.Code , Stock = product.Stock});
           _logger.LogInformation("Adding to list product: " + product.Code);
        }
    }
}
