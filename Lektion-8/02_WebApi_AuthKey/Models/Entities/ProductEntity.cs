using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_WebApi_AuthKey.Models.Entitites
{
    public class ProductEntity
    {
        public ProductEntity(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }       
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
