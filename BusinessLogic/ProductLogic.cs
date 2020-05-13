using System.Collections.Generic;
using System.Linq;
using PRODUCTS.DataBase.Models;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase;
using System;

namespace PRODUCTS.BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductListDBManager _productTableDB;

        public ProductLogic(IProductListDBManager productTableDB) 
        {
            _productTableDB = productTableDB;
        }

        public List<ProductDTO> GetAll() 
        {

            return DTOUtil.MapProductDTOList(_productTableDB.GetAll());
           
        }
        private string generateId(string type)
        {
            List<Product> allProducts = _productTableDB.GetAll();
            int maxNum = 0;
            foreach (Product product in allProducts) {
                int currentNum = Int16.Parse(product.Code.Remove(0, 7));
                if (maxNum< currentNum && product.Code.Contains(type)){
                    maxNum = currentNum;
                }
            }
            switch (type){
                case "SOCCER":
                    return "SOCCER-" + (maxNum+1);
                    
                case "BASKET":
                    return "BASKET-" + (maxNum + 1);
                default:
                    throw new Exception("Invalid type");
            }
        }
        public ProductDTO CreateProduct(ProductDTO newProduct)
        {
            
            Product productDB = new Product();
            productDB.Code = generateId(newProduct.Type);
            productDB.Name = newProduct.Name;
            productDB.Type = newProduct.Type;
            productDB.Stock = newProduct.Stock;
            Product product = _productTableDB.AddNew(productDB);
           
            return DTOUtil.MapProductDTO(product);



            /*
            bool flag = false;

            List<Product> allProducts = _productTableDB.GetAll();

            Product productDB = new Product();

            foreach(Product product in allProducts)
            {
                if(product.Code == newProduct.Code)
                {
                    product.Name = newProduct.Name;
                    product.Type = newProduct.Type;
                    product.Stock = newProduct.Stock + product.Stock;
                    productDB.Code = product.Code;
                    flag = true;
                }
            }

            if(flag)
            {
                updateProduct(newProduct, productDB.Code);
            }
            else
            {
                ProductDTO productCode = generateCode(allProducts, newProduct);

                productDB.Name = productCode.Name;
                productDB.Type = productCode.Type;
                productDB.Code = productCode.Code;
                productDB.Stock = productCode.Stock;

                _productTableDB.AddNew(productDB);
            }*/

        }
       
        public ProductDTO updateProduct(ProductDTO upProduct, string code)
        {
            
            if (upProduct.Code == null) 
            {
                throw new Exception("Invalid data, code is misssing"); // StudentLogicInvalidDataException()

            }

            foreach (ProductDTO product in GetAll())
            {
                if (product.Code.Equals(code))
                {
                    if (product.Name != null && product.Name != "")
                    {
                        product.Name = upProduct.Name;
                    }
                    if (product.Type != null && product.Type != "")
                    {
                        product.Type = upProduct.Type;
                    }
                    if (product.Code != null && product.Code != "")
                    {
                        product.Code = code;
                    }
                    if (product.Stock != 0)
                    {
                        product.Stock = upProduct.Stock;
                    }
                    break;
                }
            }

           
            Product productDB = new Product(upProduct.Name, upProduct.Type, code, upProduct.Stock);
             //  _productTableDB.Update(productDB, code);
            return DTOUtil.MapProductDTO(_productTableDB.Update(productDB, code));
        }

        public bool deleteProduct(string code)
        {
            
            return _productTableDB.Delete(code);
        }

        private ProductDTO generateCode(List<Product> listToAdd, ProductDTO product){
            IEnumerable<Product> soccerList = listToAdd.Where(product => product.Type == "SOCCER");
            IEnumerable<Product> basketList = listToAdd.Where(product => product.Type == "BASKET");
            if(product.Type == "SOCCER"){
                int id = soccerList.Count()+1;
                string code = "SOCCER-"+id;
                foreach(Product sl in soccerList){
                    if(code == sl.Code){
                        id +=1;
                        code = "SOCCER-"+id;
                    }
                }
                product.Code = code;
            }
            if(product.Type == "BASKET"){
                int id = basketList.Count() + 1;
                string code = "BASKET-"+id;
                foreach(Product sl in soccerList){
                    if(code == sl.Code){
                        id +=1;
                        code = "BASKET-"+id;
                    }
                }
                product.Code = code;
            }
            return product;
        }
    }
}
