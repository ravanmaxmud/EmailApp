using EmailApp.Controllers.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailApp.ViewModels
{
    public class AddViewModel
    {
        public bool IsBulk { get; set; }
        public string FromEmail { get; set; }
        [Required]
        public TargetEmail Email { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
