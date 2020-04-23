using System.Collections.Generic;

using PRODUCTS.DataBase.Models;

namespace PRODUCTS.DataBase
{
    public interface IProductsDB 
    {
        public List<Product> GetAll();
        public void AddNew(Product newProduct);
        public void Update(Product studentToUpdate, string code);
        public void Delete(string code);
    }
}