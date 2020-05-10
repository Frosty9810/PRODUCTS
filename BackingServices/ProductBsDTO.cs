namespace Services
{
    public class ProductBsDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public int Stock { get; set; }

        public ProductBsDTO(string name, string type, string code, int stock)
        {
            Name = name;
            Type = type;
            Code = code;
            Stock = stock;
        }
    }
}