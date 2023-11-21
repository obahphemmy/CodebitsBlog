namespace CodebitsBlog.Areas.Admin.Models
{
    public class Poste
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public IEnumerable<Commente> Comments { get; set; }
        public DateTime Date { get; set; }
    }
}
