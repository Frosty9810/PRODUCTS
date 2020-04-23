using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.BusinessLogic
{
    public class ProductsListLogic : IProductsListLogic
    {
        private readonly IProductsDB  _productTableDB;
        

        public ProductsListLogic(IProductsDB productTableDB) 
        {
            _productTableDB = productTableDB;
        }

        public List<ProductDTO> GetListProducts() 
        {
            // Retrieve all students from database
            List<Product> allProducts = _productTableDB.GetAll();
            
            List<ProductDTO> listToAdd = GetEmptyList();

            // Process all stundents
            foreach (Product product in allProducts)
            {
                addToList(listToAdd, product);
            }
            
            return listToAdd;
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
