namespace _01_AspNetMVC.Services
{
    public interface IUserService
    {
        void Add(string data);
        string Get();
    }

    public class UserService : IUserService
    {
        public void Add(string data)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            throw new NotImplementedException();
        }
    }
}
