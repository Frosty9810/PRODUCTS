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
        public static ProductDTO MapProductDTO(Product product) 
        {
            ProductDTO productdto = new ProductDTO();
            productdto.Code = product.Code;
            productdto.Name = product.Name;
            productdto.Stock = product.Stock;
            productdto.Type = product.Type;
            return productdto; 
        }
            
    }
}
