namespace _00_AspNetMVC.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string name, string description, decimal price, string subCategory, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            SubCategory = subCategory;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public string SubCategory { get; set; }
        public string Category { get; set; }

    }
}
