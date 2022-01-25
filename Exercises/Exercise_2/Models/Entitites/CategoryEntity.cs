using System.ComponentModel.DataAnnotations;

namespace Exercise_2.Models.Entitites
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
