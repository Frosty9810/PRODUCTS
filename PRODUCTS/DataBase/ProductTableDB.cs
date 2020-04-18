using System.Collections.Generic;

using PRODUCTS.DataBase.Models;

namespace PRODUCTS.DataBase
{
    public class ProductTableDB : IProductsDB
    {
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product() { Name = "objeto1", Type = "Soccer", Code = "SOCCER-001" , Stock = 1},
                new Product() { Name = "objeto2", Type = "Basket", Code = "BASKET-001" , Stock = 1 },
                new Product() { Name = "objeto3", Type = "Soccer", Code = "SOCCER-002" , Stock = 1}
            };
        }
    }
}