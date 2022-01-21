using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_WebApi_AspNetWebApi.Models
{
    [Index(nameof(EAN), IsUnique = true)]
    public class ProductEntity
    {
        public ProductEntity()
        {

        }

        public ProductEntity(string ean, string name, decimal price, int categoryId)
        {
            EAN = ean;
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }


        public ProductEntity(string ean, string name, string? description, decimal price, int categoryId)
        {
            EAN = ean;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(13)]
        [Unicode(false)]
        public string EAN { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }
    }
}
