using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRODUCTS.DTOModels;

namespace PRODUCTS.BusinessLogic
{
    public interface IProductsListLogic
    {
        public List<ListDTO> GetListProducts();
    }
}