namespace BlazorApp.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public Status Status { get; set; }
        public Customer Customer { get; set; }
        public Handler Handler { get; set; }
    }

}
