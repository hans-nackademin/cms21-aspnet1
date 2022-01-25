using System.ComponentModel.DataAnnotations;

namespace Exercise_4.Models.Entities
{
    public class CaseStatusEntity
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<CaseEntity> Cases { get; set; }
    }
}
