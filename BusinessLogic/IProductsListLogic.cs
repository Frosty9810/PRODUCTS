
using System.Collections.Generic;
using PRODUCTS.DTOModels;

namespace PRODUCTS.BusinessLogic
{
    public interface IProductsListLogic
    {
        public List<ProductDTO> GetListProducts();
    }
}
