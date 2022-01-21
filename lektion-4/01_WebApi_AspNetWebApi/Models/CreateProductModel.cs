namespace _01_WebApi_AspNetWebApi.Models
{
    public class CreateProductModel
    {
        public string EAN { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
