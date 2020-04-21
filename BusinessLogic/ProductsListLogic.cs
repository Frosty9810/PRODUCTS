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

        private Product generateCode(List<ProductDTO> listToAdd, Product product){
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
            return product;
        }

        public Product CreateProduct(Product product)
        {
            List<Product> allProducts = _productTableDB.GetAll();

            Product productCode = generateCode(GetListProducts(), product);

            allProducts.Add(new Product(){ Name = productCode.Name , Type = productCode.Type, Code = productCode.Code , Stock = productCode.Stock});

            return productCode;
        }
        public Product readProduct(List<Product> listProducts , Product productR)
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

        public Product updateProduct(string code, string name, string type, int stock)
        {
            List<Product> listProducts = _productTableDB.GetAll();
            Product product1 = null;

            foreach(Product product in listProducts)
            {
                if (product.Code.Equals(code))
                {   
                    product1 = product;
                    product.Name = name;
                    product.Type = type;
                    product.Code = code;
                    product.Stock = stock;
                    break;
                }
                 else
                {
                    product.Name = "Este No Es";
                    product.Type = "Este tampoco";
                    product.Code = "Este peor";
                    product.Stock = 404;
                }
            }
            return product1;
        }

        public Product deleteProduct(string code)
        {
            List<Product> listProducts = _productTableDB.GetAll();
            int count = 0;
            Product product1 = null;
            foreach(Product product in listProducts)
            {
                count += 1;
                if (product.Code.Equals(code))
                {   
                    product1 = product;
                    listProducts.RemoveAt(count);
                    break;
                }
                else
                {
                    product.Name = "Este No Es";
                    product.Type = "Este tampoco";
                    product.Code = "Este peor";
                    product.Stock = 404;
                }
            }
            return product1;
        }
    }
}
