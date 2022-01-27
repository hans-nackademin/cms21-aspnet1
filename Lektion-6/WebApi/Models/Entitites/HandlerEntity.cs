using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    [Index(nameof(Email), IsUnique = true)]
    public class HandlerEntity
    {
        public HandlerEntity()
        {

        }

        public HandlerEntity(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public HandlerEntity(int id, string firstName, string lastName, string email)
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

        public virtual ICollection<CaseHandlerEntity> Cases { get; set; }

    }
}
