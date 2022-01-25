using System.ComponentModel.DataAnnotations;

namespace Exercise_4.Models.Entities
{
    public class CaseHandlerEntity
    {
        public Guid CaseId { get; set; }
        
        public int HandlerId { get; set; }


        public CaseEntity Case { get; set; }
        public HandlerEntity Handler { get; set; }
    }
}
