namespace WebApi.Models
{
    public class CaseUpdateModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public int StatusId { get; set; }
    }
}
