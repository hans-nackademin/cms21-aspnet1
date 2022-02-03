namespace _03_ConsumeWebApi.Blazor.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductModel(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
