using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace _01_WebApi_AspNetWebApi.Models
{

    [Index(nameof(Name), IsUnique = true)]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get;}
    }
}
