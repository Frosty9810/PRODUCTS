using System.Collections.Generic;
using PRODUCTS.DTOModels;

namespace PRODUCTS.BusinessLogic
{
    public interface IProductLogic
    {
        public List<ProductDTO> GetAll();
        public ProductDTO CreateProduct(ProductDTO product);
        public bool deleteProduct(string code);
        public ProductDTO updateProduct(ProductDTO upProduct, string code);
    }
}
