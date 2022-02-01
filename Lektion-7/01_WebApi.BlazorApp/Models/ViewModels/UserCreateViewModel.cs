using System.ComponentModel.DataAnnotations;

namespace _01_WebApi.BlazorApp.Models.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password did not match")]
        public string ConfirmPassword { get; set; }
    }
}
