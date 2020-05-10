using System.Collections.Generic;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase.Models;

namespace PRODUCTS.BusinessLogic
{
    public class DTOUtil
    {
        public static List<ProductDTO> MapProductDTOList(List<Product> productList)
        {
            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach (Product product in productList)
            {
                productDTOList.Add
                (
                    new ProductDTO()
                    {
                        Name = product.Name,
                        Code = product.Code,
                        Stock = product.Stock,
                        Type = product.Type
                    }
                );
            }
            return productDTOList;
        }
    }
}
