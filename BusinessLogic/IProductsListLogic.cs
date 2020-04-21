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
        public Product CreateProduct(Product product);
        public Product deleteProduct(string code);
        public Product updateProduct(string code, string name, string type, int stock);
    }
}
