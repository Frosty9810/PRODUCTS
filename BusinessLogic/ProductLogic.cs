using System.Collections.Generic;
using System.Linq;
using PRODUCTS.DataBase.Models;
using PRODUCTS.DTOModels;
using PRODUCTS.DataBase;

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
            
            List<Product> allProducts = _productTableDB.GetAll();
            List<ProductDTO> listToAdd = new List<ProductDTO>();

            foreach (Product product in allProducts)
            {
                listToAdd.Add(
                    new ProductDTO() 
                    { 
                        Name = product.Name, 
                        Type = product.Type, 
                        Code = product.Code, 
                        Stock = product.Stock
                    }
                );
            }

            return listToAdd;
        }
        public void CreateProduct(ProductDTO newProduct)
        {
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
            }

        }
        public void readProduct(List<Product> listProducts , Product productR)
        {
            Product showProduct = null;
            foreach(Product product in listProducts)
            {
                if (product.Equals(productR))
                {
                    showProduct = product;
                }
            }
        }

        public void updateProduct(ProductDTO upProduct, string code)
        {
            foreach(ProductDTO product in GetAll())
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
            _productTableDB.Update(productDB, code);
        }

        public void deleteProduct(string code)
        {
            int count = 0;

            foreach(ProductDTO product in GetAll())
            {
                if (product.Code.Equals(code))
                {   
                    GetAll().RemoveAt(count);
                }
                else
                {
                    count += 1;
                }
            }
            _productTableDB.Delete(code);
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
