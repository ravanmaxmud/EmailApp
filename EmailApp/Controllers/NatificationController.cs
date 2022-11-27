using EmailApp.Controllers.Models;
using EmailApp.Database;
using EmailApp.EmailServices;
using EmailApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailApp.Controllers
{
    [Route("Email")]
    public class NatificationController : Controller
    {
        private readonly IEmailSender _emailSender;

        private readonly DataContext _dataContext;

        public NatificationController(DataContext dataContext,IEmailSender emailSender)
        {
            _dataContext = dataContext;
            _emailSender = emailSender;
        }

        [HttpGet("~/")]
        [HttpGet("list",Name ="email-list")]
        public IActionResult List()
        {
            var model = _dataContext.natifications
                .Select
                (e => new ListViewModel(e.Id, e.Title, e.FromEmail,$"{e.Email.Email}"))
                .ToList();
            return View("~/Views/Email/List.cshtml",model);
        }


        [HttpGet("add",Name = "email-add")]
        public IActionResult Add()
        {
            return View("~/Views/Email/add.cshtml");
        }


        [HttpPost("add",Name = "email-add")]
        public IActionResult Add([FromForm]AddViewModel model)
        {
            var email = new Natification
            {
                FromEmail = model.FromEmail,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content
            };

            var message = new Message(new string[] {email.Email.Email},email.Title,email.Content);

            _dataContext.natifications.Add(email);
            _emailSender.SendEmail(message);
            _dataContext.targetEmails.Add(email.Email);
            _dataContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
