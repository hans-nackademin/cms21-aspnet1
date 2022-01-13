using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_AspNetMVC.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
