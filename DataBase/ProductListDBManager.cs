using PRODUCTS.DataBase.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using DataBase.Models;
using Services;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace PRODUCTS.DataBase
{
    public class ProductListDBManager : IProductListDBManager
    {
        private readonly IConfiguration _configuration;
        //private string _dbPath;
        private List<Product> _products { get; set; }
        //private DBContext _dbContext;
        private ProductBackingService _productBackingServices;
        private string _productsBsDTOjson;

        public ProductListDBManager(IConfiguration config)
        {
            // assign config
            _configuration = config;
            InitDBContext(); // new List<T>()   
        }

        public void InitDBContext()
        {
            // read path from config for DB (JSON)
            //_dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;
            // "Connect to JSON File" => DeserializeObject
            //_dbContext = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));
            //_products = _dbContext.Products;
            _productBackingServices = new ProductBackingService(_configuration);
            _productsBsDTOjson = _productBackingServices.GetAllProductsjson();
            /*_productsBsDTO = _productBackingServices.GetAllProducts();
            foreach (ProductBsDTO productBsDTO in _productsBsDTO)
            {
                //Console.WriteLine(productBsDTO.Name + " " + productBsDTO.Code);
                _products.Add(new Product(productBsDTO.Name, productBsDTO.Type, productBsDTO.Code, productBsDTO.Stock));
                //Console.WriteLine(productBsDTO.Name + " " + productBsDTO.Code);
            }*/
            _products = JsonConvert.DeserializeObject<List<Product>>(_productsBsDTOjson);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product AddNew(Product newProduct)
        {
            _products.Add(newProduct);
            SaveChanges();
            return newProduct;
        }
        public Product Update(Product productToUpdate, string code)
        {

            //var productToUp = _products.First(d => d.Code.Equals(code));

                 Product productToUp = _products.Find(product => product.Code == code);
                if (productToUp != null) 
                {
                    productToUpdate.Code = code;
                    if (string.IsNullOrEmpty(productToUpdate.Name))
                    {
                        productToUpdate.Name = productToUp.Name;
                    }
                    else
                    {
                        productToUp.Name = productToUpdate.Name;
                    }
                    if (productToUpdate.Stock != 0)
                    {
                        productToUpdate.Stock = productToUp.Stock;
                    }
                    else
                    {
                        productToUp.Stock = productToUpdate.Stock;
                    }
                    if (string.IsNullOrEmpty(productToUpdate.Type))
                    {
                        productToUpdate.Type = productToUp.Type;
                    }
                    else
                    {
                        productToUp.Type = productToUpdate.Type;
                    }

            }
             /*
            foreach(Product product in _products)
            {
                if (product.Code.Equals(code))
                {   
                    product.Name = productToUpdate.Name;
                    product.Type = productToUpdate.Type;
                    product.Code = code;
                    product.Stock = productToUpdate.Stock;
                    break;
                }
            }
            */
            SaveChanges();
            return productToUp;
        }
        public bool Delete(string code)
        {
           
            Product productfound = _products.Find(product => product.Code == code);
          
            bool removed = _products.Remove(productfound);
               
            
            
            SaveChanges();
            return removed;

        }

        public void SaveChanges()
        {
            //File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContext));
            /*_productsBsDTO.Clear();
            foreach (Product product in _products)
            {
                _productsBsDTO.Add(new ProductBsDTO(product.Name, product.Type, product.Code, product.Stock));
            }
            _productBackingServices.SaveChanges(_productsBsDTO);*/
            _productsBsDTOjson = JsonConvert.SerializeObject(_products);
            _productBackingServices.SaveChanges(_productsBsDTOjson);
        }
    }
}