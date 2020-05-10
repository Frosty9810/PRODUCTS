//using BackingServices.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class ProductBackingService : IProductBackingService
    {
        private readonly IConfiguration _configuration;
        private List<ProductBsDTO> _products;
        private string _dbPath = "C:/Users/bramo/OneDrive/Escritorio/Certificacion/productos.json";

        public ProductBackingService(IConfiguration configuration)
        {
            _configuration = configuration;
            //_products = JsonConvert.DeserializeObject<List<ProductBsDTO>>(File.ReadAllText(_dbPath));
        }

        public List<ProductBsDTO> GetAllProducts()
        {
            return _products;
        }

        public string GetAllProductsjson()
        {
            return File.ReadAllText(_dbPath);
        }

        public async Task<List<ProductBsDTO>> GetAllProduct()
        {
            // Creating HTTP Client
            HttpClient productMS = new HttpClient();
            string msPath = _configuration.GetSection("Microservices").GetSection("Products").Value;
            // Executing an ASYNC HTTP Method could be: Get, Post, Put, Delete
            // In this case is a GET
            // HttpContent content = new 
            HttpResponseMessage response = await productMS.GetAsync($"{msPath}/products");
            int statusCode = (int)response.StatusCode;
            if (statusCode == 200) // OK
            {
                // Read ASYNC response from HTTPResponse 
                String jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserialize response
                List<ProductBsDTO> products = JsonConvert.DeserializeObject<List<ProductBsDTO>>(jsonResponse);
                return products;
            }
            else
            {
                // something wrong happens!
                throw new NotImplementedException();
            }
            //List<ProductBsDTO> productss = JsonConvert.DeserializeObject<List<ProductBsDTO>>(File.ReadAllText(_dbPath));
            //return productss;
        }

        public void SaveChanges(List<ProductBsDTO> productsBsDTOs)
        {
            _products = productsBsDTOs;
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(productsBsDTOs));
        }

        public void SaveChanges(string productsBsDTOs)
        {
            _products = JsonConvert.DeserializeObject<List<ProductBsDTO>>(productsBsDTOs);
            File.WriteAllText(_dbPath, productsBsDTOs);
        }
    }
}