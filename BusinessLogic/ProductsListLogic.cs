using System.Collections.Generic;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase;
using PRODUCTS.DataBase.Models;


namespace PRODUCTS.BusinessLogic
{
    public class ProductsListLogic : IProductsListLogic
    {
        private readonly IProductListDBManager _productListDBManager;
  

        public ProductsListLogic(IProductListDBManager productListDBManager, ) 
        {

            _productListDBManager = productListDBManager;

        }

        public List<ProductDTO> GetListProducts() 
        {
         
            return DTOUtil.MapProductDTOList(_productListDBManager.GetAll());
        }

        private List<ProductDTO> GetEmptyList() 
        {
         
            List<ProductDTO> emptyList = new List<ProductDTO>();
            return emptyList;
        }

        private void addToList(List<ProductDTO> listToAdd, Product product) 
        {
           listToAdd.Add(new ProductDTO() { Name = product.Name , Type = product.Type, Code = product.Code , Stock = product.Stock});
     
        }
    }
}
