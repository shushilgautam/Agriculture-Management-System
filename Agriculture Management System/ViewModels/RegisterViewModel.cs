using System.ComponentModel.DataAnnotations;
namespace Agriculture_Management_System.ViewModels
{
  

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, ErrorMessage = "Password length must be between 8 and 40 characters.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression("^(Admin|Farmer|Buyer)$", ErrorMessage = "Role must be Admin, Farmer, or Buyer.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public IFormFile ProfilePhoto { get; set; }
    }
}
