using CodebitsBlog.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace CodebitsBlog.Areas.Admin.ViewModels
{
    public class AdminPostViewModel
    {
        [Required(ErrorMessage = "Please enter a post title")]
        [MinLength(3, ErrorMessage = "Post title must be at least 3 characters long")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter a post body")]
        [MinLength(20, ErrorMessage = "Post body must be at least 20 characters long")]
        public string? Body { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public IFormFile? CoverImage { get; set; }
        public IEnumerable<Post> Posts { get; set; } = new List<Post>();
    }
}
