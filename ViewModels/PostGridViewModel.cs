namespace CodebitsBlog.ViewModels
{
    public class PostGridViewModel
    {
        public PostViewModel? EntryPost { get; set; }
        public IDictionary<string, IEnumerable<PostViewModel>> GridPosts { get; set; } = new Dictionary<string, IEnumerable<PostViewModel>>();
        public string rootPath { get; set; }
    }
}
