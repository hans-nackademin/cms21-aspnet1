using System.ComponentModel.DataAnnotations;

namespace _00_WebApi.AspNetMVC.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [EmailAddress(ErrorMessage = "Du måste ange en giltig e-postadress")]
        [Display(Name = "E-postadress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [Display(Name = "Lösnord")]
        public string Password { get; set; }
    }
}
