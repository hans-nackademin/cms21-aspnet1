namespace WebApi.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {

        }

        public CustomerModel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public CustomerModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
