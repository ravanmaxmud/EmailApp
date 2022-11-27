using EmailApp.Controllers.Models;

namespace EmailApp.ViewModels
{
    public class AddViewModel
    {
        public bool IsBulk { get; set; }
        public string FromEmail { get; set; }
        public TargetEmail Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
