using PRODUCTS.DataBase.Models;
using System.Collections.Generic;

namespace DataBase.Models
{
    public class DBContext
    {
        public List<Product> Products { get; set; }
    }
}
