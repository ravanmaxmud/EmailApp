using EmailApp.Controllers.Models;

namespace EmailApp.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FromEmail { get; set; } 
        public string TargetEmail { get; set; }

        public ListViewModel(int id, string title,string fromEmail, string targetEmail)
        {
            Id = id;
            Title = title;
            FromEmail = fromEmail;
            TargetEmail = targetEmail;
        }
    }
}
