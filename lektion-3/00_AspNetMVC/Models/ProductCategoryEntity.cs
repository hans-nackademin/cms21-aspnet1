using System.ComponentModel.DataAnnotations;

namespace _00_AspNetMVC.Models
{
    public class ProductCategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductSubCategoryEntity> SubCategories { get; set; }
    }
}