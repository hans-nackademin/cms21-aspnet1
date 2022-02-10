using Microsoft.AspNetCore.Identity;

namespace _01_ShoppingCart.AspNetMVC.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
