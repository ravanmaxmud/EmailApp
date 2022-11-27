namespace EmailApp.Controllers.Models
{
    public class Natification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FromEmail { get; set; }
        public int TargetEmailId { get; set; }
        public TargetEmail Email { get; set; }

    }
}
