using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise_2.Models.Entitites
{
    public class ProductEntity
    {
        public ProductEntity()
        {

        }

        public ProductEntity(string barCode, string name, string description, decimal price, int categoryId)
        {
            BarCode = barCode;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public ProductEntity(int id, string barCode, string name, string description, decimal price, int categoryId)
        {
            Id = id;
            BarCode = barCode;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        [Key]
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
