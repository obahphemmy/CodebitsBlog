namespace CodebitsBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
       IEnumerable<Post> Posts { get; set; } = Enumerable.Empty<Post>();
    }
}
