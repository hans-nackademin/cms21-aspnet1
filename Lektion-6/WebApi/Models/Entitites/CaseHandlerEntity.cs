using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    public class CaseHandlerEntity
    {
        public CaseHandlerEntity()
        {

        }

        public CaseHandlerEntity(int caseId, int handlerId)
        {
            CaseId = caseId;
            HandlerId = handlerId;
        }

        [Key]
        public int CaseId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int HandlerId { get; set; }

        public CaseEntity Case { get; set; }
        public HandlerEntity Handler { get; set; }
    }
}
