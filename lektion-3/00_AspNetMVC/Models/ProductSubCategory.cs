namespace _00_AspNetMVC.Models
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
