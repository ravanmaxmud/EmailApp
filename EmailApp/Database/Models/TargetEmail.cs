namespace EmailApp.Controllers.Models
{
    public class TargetEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<Natification> Natifications { get; set; }
    }
}
