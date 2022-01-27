namespace WebApi.Models
{
    public class CaseHandlerModel
    {
        public CaseHandlerModel()
        {

        }

        public CaseHandlerModel(int caseId, int handlerId)
        {
            CaseId = caseId;
            HandlerId = handlerId;
        }

        public int CaseId { get; set; }
        public int HandlerId { get; set; }
    }
}
