using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    public class CaseEntity
    {
        public CaseEntity()
        {

        }

        public CaseEntity(string description, DateTime created, DateTime modified, int statusId, int customerId)
        {
            Description = description;
            Created = created;
            Modified = modified;
            StatusId = statusId;
            CustomerId = customerId;
        }

        public CaseEntity(int id, string description, DateTime created, DateTime modified, int statusId, int customerId)
        {
            Id = id;
            Description = description;
            Created = created;
            Modified = modified;
            StatusId = statusId;
            CustomerId = customerId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int StatusId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int CustomerId { get; set; }


        public StatusEntity Status { get; set; }
        public CustomerEntity Customer { get; set; }
        public CaseHandlerEntity CaseHandler { get; set; }
    }
}
