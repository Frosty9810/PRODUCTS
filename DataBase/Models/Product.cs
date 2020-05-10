
namespace PRODUCTS.DataBase.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public int Stock { get; set;}

        public Product() { }

        public Product(string name, string type, string code, int stock)
        {
            Name = name;
            Type = type;
            Code = code;
            Stock = stock;
        }
    }
}