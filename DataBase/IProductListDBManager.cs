using System.Collections.Generic;
using DataBase;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.DataBase
{
    public interface IProductListDBManager : IDBManager
    {
        public List<Product> GetAll();
        public Product AddNew(Product newProduct);
        public Product Update(Product studentToUpdate, string code);
        public bool Delete(string code);
    }
}