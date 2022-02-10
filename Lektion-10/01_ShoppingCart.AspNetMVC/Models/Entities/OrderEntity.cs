namespace _01_ShoppingCart.AspNetMVC.Models.Entities
{
    public class InvoiceEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
    }


    public class OrderRowEntity
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }


    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
    }

    public class AddressEntity
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
