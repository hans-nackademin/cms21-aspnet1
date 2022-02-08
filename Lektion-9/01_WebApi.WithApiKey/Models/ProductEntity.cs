using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_WebApi.WithApiKey.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
