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
                new Product() { NameProd = "objeto1", TypeProd = "Soccer", CodeProd = "SOCCER-001" },
                new Product() { NameProd = "objeto2", TypeProd = "Basket", CodeProd = "BASKET-001" },
                new Product() { NameProd = "objeto3", TypeProd = "Soccer", CodeProd = "SOCCER-002" }
            };
        }
    }
}