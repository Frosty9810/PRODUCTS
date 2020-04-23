
using System.Collections.Generic;

using PRODUCTS.DTOModels;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.BusinessLogic
{
    public interface IProductLogic
    {
        public List<ProductDTO> GetAll();
        public void CreateProduct(ProductDTO product);
        public void deleteProduct(string code);
        public void updateProduct(ProductDTO upProduct, string code);
    }
}
