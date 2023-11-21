namespace CodebitsBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
       IEnumerable<Poste> Posts { get; set; } = Enumerable.Empty<Poste>();
    }
}
