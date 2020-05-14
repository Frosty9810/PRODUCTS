using PRODUCTS.DataBase.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using DataBase.Models;
using Microsoft.Extensions.Logging;

namespace PRODUCTS.DataBase
{
    public class ProductListDBManager : IProductListDBManager
    {
        private readonly IConfiguration _configuration;
        private string _dbPath;
        private List<Product> _products { get; set; }
        private DBContext _dbContext;
        public readonly ILogger<ProductListDBManager> _logger;

        public ProductListDBManager(IConfiguration config, ILogger<ProductListDBManager> logger)
        {
            // assign config
            _configuration = config;
            _logger = logger;
            InitDBContext(); // new List<T>()   
        }

        public void InitDBContext()
        {
            // read path from config for DB (JSON)
            _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;
            // "Connect to JSON File" => DeserializeObject
            _dbContext = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));
            _products = _dbContext.Products;
            //  _logger.LogInformation("This app is using db path" + _dbpath);  //lOGGER INFO
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
               // if (productToUpdate.Stock != 0)
                //{
                   // productToUpdate.Stock = productToUp.Stock;
                //}
                //else
               // {
                    productToUp.Stock = productToUpdate.Stock; 
                //}
                if (string.IsNullOrEmpty(productToUpdate.Type))
                {
                    productToUpdate.Type = productToUp.Type;
                }
                else
                {
                    productToUp.Type = productToUpdate.Type;
                }
            }
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
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContext));
        }
    }
}