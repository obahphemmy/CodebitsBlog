using System.ComponentModel.DataAnnotations;

namespace CodebitsBlog.Areas.Admin.Models
{
    public class Comment : BaseEntity
    {
        public string? CommentBody { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public string? PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
