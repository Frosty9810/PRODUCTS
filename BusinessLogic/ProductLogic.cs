using System;
using System.Collections.Generic;
using System.Linq;

using PRODUCTS.DataBase;
using PRODUCTS.DataBase.Models;
using PRODUCTS.DTOModels;

namespace PRODUCTS.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductsDB  _productTableDB;

        public ProductLogic(IProductsDB productTableDB) 
        {
            _productTableDB = productTableDB;
        }

        public List<ProductDTO> GetAll() 
        {
            // Retrieve all students from database
            List<Product> allProducts = _productTableDB.GetAll();
            
            List<ProductDTO> listToAdd = new List<ProductDTO>();

            // Process all stundents
            foreach (Product product in allProducts)
            {
                listToAdd.Add(
                    new ProductDTO() 
                    { 
                        Name = product.Name, 
                        Type = product.Type, 
                        Code = product.Code, 
                        Stock = product.Stock
                        
                    }
                );
            }
            
            return listToAdd;
        }
        public void CreateProduct(ProductDTO newProduct)
        {
            List<Product> allProducts = _productTableDB.GetAll();

            ProductDTO productCode = generateCode(allProducts, newProduct);

            Product product = new Product();

            product.Name = productCode.Name;
            product.Type = productCode.Type;
            product.Code = productCode.Code;
            product.Stock = productCode.Stock;

            _productTableDB.AddNew(product);

        }
        public void readProduct(List<Product> listProducts , Product productR)
        {
            Product showProduct = null;
            foreach(Product product in listProducts)
            {
                if (product.Equals(productR))
                {
                    showProduct = product;
                }
            }
        }

        public void updateProduct(ProductDTO upProduct, string code)
        {
            foreach(ProductDTO product in GetAll())
            {
                if (product.Code.Equals(code))
                {   
                    product.Name = upProduct.Name;
                    product.Type = upProduct.Type;
                    product.Code = code;
                    product.Stock = upProduct.Stock;
                    break;
                }
            }

            Product productDB = new Product();

            productDB.Name = upProduct.Name;
            productDB.Type = upProduct.Type;
            productDB.Code = code;
            productDB.Stock = upProduct.Stock;

            _productTableDB.Update(productDB, code);
        }

        public void deleteProduct(string code)
        {
            int count = 0;

            foreach(ProductDTO product in GetAll())
            {
                if (product.Code.Equals(code))
                {   
                    GetAll().RemoveAt(count);
                    break;
                }
                else
                {
                    count += 1;
                }
            }

            _productTableDB.Delete(code);
        }

         private ProductDTO generateCode(List<Product> listToAdd, ProductDTO product){
            IEnumerable<Product> soccerList = listToAdd.Where(product => product.Type == "SOCCER");
            IEnumerable<Product> basketList = listToAdd.Where(product => product.Type == "BASKET");
            if(product.Type == "SOCCER"){
                int id = soccerList.Count()+1;
                product.Code = "SOCCER-"+id;
            }
            if(product.Type == "BASKET"){
                int id = basketList.Count() + 1;
                product.Code = "BASKET-"+id;
            }
            return product;
        }
    
    }
}
