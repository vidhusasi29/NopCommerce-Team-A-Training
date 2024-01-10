using System.ComponentModel.DataAnnotations;

namespace Authentication.API.AuthenticationModel
{
    public class Registration
    {

        


        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }



        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

    }
}
