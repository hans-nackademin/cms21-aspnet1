namespace Exercise_3.Models.Forms
{
    public class ProductUpdateForm
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
