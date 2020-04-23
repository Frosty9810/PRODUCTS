using System.Collections.Generic;

using PRODUCTS.DataBase.Models;

namespace PRODUCTS.DataBase
{
    public class ProductTableDB : IProductsDB
    {
        private List<Product> products { get; set;}

        public ProductTableDB()
        {
            products = new List<Product>()
            {
                new Product() { Name = "objeto1", Type = "Soccer", Code = "SOCCER-001" , Stock = 1},
                new Product() { Name = "objeto2", Type = "Basket", Code = "BASKET-001" , Stock = 1 },
                new Product() { Name = "objeto3", Type = "Soccer", Code = "SOCCER-002" , Stock = 1}
            };
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public void AddNew(Product newProduct)
        {
            products.Add(newProduct);
        }
        public void Update(Product studentToUpdate, string code)
        {
             foreach(Product product in GetAll())
            {
                if (product.Code.Equals(code))
                {   
                    product.Name = studentToUpdate.Name;
                    product.Type = studentToUpdate.Type;
                    product.Code = code;
                    product.Stock = studentToUpdate.Stock;
                    break;
                }
            }
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
        }
    }
}