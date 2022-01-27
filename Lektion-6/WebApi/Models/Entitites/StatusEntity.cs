using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    [Index(nameof(Name), IsUnique = true)]
    public class StatusEntity
    {
        public StatusEntity()
        {

        }

        public StatusEntity(string name)
        {
            Name = name;
        }

        public StatusEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; } 
        
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<CaseEntity> Cases { get; set; }
    }
}
