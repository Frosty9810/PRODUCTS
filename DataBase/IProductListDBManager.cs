using System.Collections.Generic;
using Database;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.DataBase
{
    public interface IProductListDBManager : IDBManager
    {
        public List<Product> GetAll();
        public void AddNew(Product newProduct);
        public void Update(Product studentToUpdate, string code);
        public void Delete(string code);
    }
}