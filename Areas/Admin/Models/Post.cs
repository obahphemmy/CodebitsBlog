﻿namespace CodebitsBlog.Areas.Admin.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public DateTime Date { get; set; }
    }
}
