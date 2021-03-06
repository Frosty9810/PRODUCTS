﻿
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
            
            List<Product> allProducts = _productTableDB.GetAll();
            
            List<ProductDTO> listToAdd = new List<ProductDTO>();

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
            bool flag = false;

            List<Product> allProducts = _productTableDB.GetAll();

            Product productDB = new Product();

            foreach(Product product in allProducts)
            {
                if(product.Code == newProduct.Code)
                {
                    product.Name = newProduct.Name;
                    product.Type = newProduct.Type;
                    product.Stock = newProduct.Stock + product.Stock;
                    productDB.Code = product.Code;
                    flag = true;
                }
            }

            if(flag)
            {
                updateProduct(newProduct, productDB.Code);
            }
            else
            {
                ProductDTO productCode = generateCode(allProducts, newProduct);

                productDB.Name = productCode.Name;
                productDB.Type = productCode.Type;
                productDB.Code = productCode.Code;
                productDB.Stock = productCode.Stock;

                _productTableDB.AddNew(productDB);
            }

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
                string code = "SOCCER-"+id;
                foreach(Product sl in soccerList){
                    if(code == sl.Code){
                        id +=1;
                        code = "SOCCER-"+id;
                    }
                }
                product.Code = code;
            }
            if(product.Type == "BASKET"){
                int id = basketList.Count() + 1;
                string code = "BASKET-"+id;
                foreach(Product sl in soccerList){
                    if(code == sl.Code){
                        id +=1;
                        code = "BASKET-"+id;
                    }
                }
                product.Code = code;
            }
            return product;
        }
    
    }
}
