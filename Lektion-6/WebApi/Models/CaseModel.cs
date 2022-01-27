namespace WebApi.Models
{
    public class CaseModel
    {
        public CaseModel()
        {

        }

        public CaseModel(string description, DateTime created, DateTime modified, StatusModel status, CustomerModel customer)
        {
            Description = description;
            Created = created;
            Modified = modified;
            Status = status;
            Customer = customer;
        }

        public CaseModel(int id, string description, DateTime created, DateTime modified, StatusModel status, CustomerModel customer)
        {
            Id = id;
            Description = description;
            Created = created;
            Modified = modified;
            Status = status;
            Customer = customer;
        }

        public CaseModel(int id, string description, DateTime created, DateTime modified, StatusModel status, CustomerModel customer, HandlerModel handler)
        {
            Id = id;
            Description = description;
            Created = created;
            Modified = modified;
            Status = status;
            Customer = customer;
            Handler = handler;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public StatusModel Status { get; set; }
        public CustomerModel Customer { get; set; }
        public HandlerModel Handler { get; set; }
    }
}
