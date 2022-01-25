using System.ComponentModel.DataAnnotations;

namespace Exercise_4.Models.Entities
{
    public class CaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


        public int CaseStatusId { get; set; }
        public CaseStatusEntity CaseStatus { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

    }
}
