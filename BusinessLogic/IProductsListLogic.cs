using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.BusinessLogic
{
    public interface IProductsListLogic
    {
        public List<ProductDTO> GetListProducts();
    }
}
