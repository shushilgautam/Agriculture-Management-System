namespace Agriculture_Management_System.Models
{
    using Microsoft.AspNetCore.Identity;
    public class Users : IdentityUser
    {
        public string FullName {get;set;}
        public string Address { get; set; } 
        public string ProfilePicturePath { get; set; }
    }
}
