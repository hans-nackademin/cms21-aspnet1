namespace WebApi.Models
{
    public class StatusModel
    {
        public StatusModel()
        {

        }

        public StatusModel(string name)
        {
            Name = name;
        }

        public StatusModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
