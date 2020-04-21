using System.Collections.Generic;

using PRODUCTS.DataBase.Models;

namespace PRODUCTS.DataBase
{
    public interface IProductsDB 
    {
        public List<Product> GetAll(); 
    }
}