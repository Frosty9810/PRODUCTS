using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRODUCTS.DTOModels
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Code { get; set; }

        public int Stock { get; set;}
    }
}
