namespace CodebitsBlog.Areas.Admin.Models
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Comments = new List<Comment>();
        }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
