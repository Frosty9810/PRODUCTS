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

        private void generateCode(List<ProductDTO> listToAdd, Product product){
            IEnumerable<ProductDTO> soccerList = listToAdd.Where(product => product.Type == "SOCCER");
            IEnumerable<ProductDTO> basketList = listToAdd.Where(product => product.Type == "BASKET");
            if(product.Type == "SOCCER"){
                int id = soccerList.Count()+1;
                product.Code = "SOCCER-"+id;
            }
            if(product.Type == "BASKET"){
                int id = basketList.Count() + 1;
                product.Code = "BASKET-"+id;
            }
        }

        private Product readProduct(List<Product> listProducts , Product productR)
        {
            Product showProduct = null;
            foreach(Product product in listProducts)
            {
                if (product.Equals(productR))
                {
                    showProduct = product;
                }
            }
            return showProduct; 
        }

        private void updateProduct(List<Product> listProducts, Product productU)
        {
            foreach(Product product in listProducts)
            {
                if (product.Equals(productU))
                {   
                    product.Name = "";
                    product.Type = "";
                    product.Code = "";
                    product.Stock = 0;
                    break;
                }
            }
        }

        private void deleteProduct(List<Product> listProducts, Product productD)
        {
            int count = 0;
            foreach(Product product in listProducts)
            {
                count += 1;
                if (product.Equals(productD))
                {   
                    listProducts.RemoveAt(count);
                    break;
                }
            }
        }
    }
}
