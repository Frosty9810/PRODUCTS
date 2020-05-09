using PRODUCTS.DataBase.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Database.Models;

namespace PRODUCTS.DataBase
{
    public class ProductListDBManager : IProductListDBManager
    {
        private readonly IConfiguration _configuration;
        private string _dbPath;
        private List<Product> _products { get; set; }
        private DBContext _dbContext;

        public ProductListDBManager(IConfiguration config)
        {
            // assign config
            _configuration = config;
            InitDBContext(); // new List<T>()   
        }

        public void InitDBContext()
        {
            // read path from config for DB (JSON)
            _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;
            // "Connect to JSON File" => DeserializeObject
            _dbContext = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));
            _products = _dbContext.Products;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void AddNew(Product newProduct)
        {
            _products.Add(newProduct);
            SaveChanges();
        }
        public void Update(Product productToUpdate, string code)
        {
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
            SaveChanges();
        }
        public void Delete(string code)
        {
            int count = 0;

            foreach(Product product in GetAll())
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
            SaveChanges();
        }

        public void SaveChanges()
        {
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContext));
        }
    }
}