using Microsoft.AspNetCore.Identity;

namespace Agriculture_Management_System.Models
{
    public class RolePermissions
    {
        public int Id { get; set; }
        public String RoleId { get; set; }
        public IdentityRole Role { get; set; }

        public int PermissionID { get; set; }
        public Permissions Permission { get; set; }
    }
}
