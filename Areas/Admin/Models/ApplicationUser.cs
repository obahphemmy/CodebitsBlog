using Microsoft.AspNetCore.Identity;

namespace CodebitsBlog.Areas.Admin.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public IdentityRole<string> UserRole { get; set; }
        public string UserRoleId { get; set; }
    }
}
