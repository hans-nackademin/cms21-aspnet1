namespace _01_AspNetMVC.Models
{
    public class ProductsIndexViewModel
    {
        public List<ProductModel> Products { get; set; }
        public List<ProductModel> Latest { get; set; }
        public List<ProductModel> Highlights { get; set; }

    }
}
