using System.ComponentModel.DataAnnotations;

namespace Agriculture_Management_System.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email field should not be empty")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field should not be empty")]
        [DataType(DataType.Password)]
        public string Password  { get; set; }

        public bool RememberMe { get; set; }
    }
}
