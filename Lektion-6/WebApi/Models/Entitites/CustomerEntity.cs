using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    [Index(nameof(Email), IsUnique = true)]
    public class CustomerEntity
    {
        public CustomerEntity()
        {

        }

        public CustomerEntity(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public CustomerEntity(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        public virtual ICollection<CaseEntity> Cases { get; set; }
    }
}
