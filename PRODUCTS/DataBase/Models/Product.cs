using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRODUCTS.DataBase.Models
{
    public class Product
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Code { get; set; }

        public int Stock { get; set;}
    }
}