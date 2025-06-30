namespace Agriculture_Management_System.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Field should not be empty.")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

 
        [Required(ErrorMessage = "Field should not be empty.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field should not be empty.")]
        [StringLength(40,ErrorMessage ="Password length must be between 8 to 40 characters",MinimumLength =8)]
        [DataType (DataType.Password)]
        public string Password { get; set; }

  
        [Required(ErrorMessage = "Field should not be empty.")]
        [Compare("Password",ErrorMessage ="Password did not match.")]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Field should not be empty.")]
        [Phone]
        public string PhoneNumber { get; set; }

 
        [Required(ErrorMessage = "Field should not be empty.")]
        public string Role { get; set; }

     
        [Required(ErrorMessage = "Field should not be empty.")]
        public string Address { get; set; }
    }
}
