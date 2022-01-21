using System.ComponentModel.DataAnnotations;

namespace _00_AspNetMVC.Models
{
    public class ProductSubCategoryEntity
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual ProductCategoryEntity Category { get; set; }
        public virtual ICollection<ProductEntity> Products { get;}
    }
}