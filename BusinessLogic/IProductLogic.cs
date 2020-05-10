using System.Collections.Generic;
using PRODUCTS.DTOModels;

namespace PRODUCTS.BusinessLogic
{
    public interface IProductLogic
    {
        public List<ProductDTO> GetAll();
        public void CreateProduct(ProductDTO product);
        public bool deleteProduct(string code);
        public void updateProduct(ProductDTO upProduct, string code);
    }
}
