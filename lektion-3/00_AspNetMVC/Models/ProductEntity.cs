using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_AspNetMVC.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }
        
        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public virtual ProductSubCategoryEntity SubCategory { get; set; }

    }
}
