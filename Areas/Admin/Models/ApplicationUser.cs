using Microsoft.AspNetCore.Identity;

namespace CodebitsBlog.Areas.Admin.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public IdentityRole? UserRole { get; set; }
        public string? UserRoleId { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
