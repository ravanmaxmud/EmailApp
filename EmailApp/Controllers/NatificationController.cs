using EmailApp.Controllers.Models;
using EmailApp.Database;
using EmailApp.EmailServices;
using EmailApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Net.Mail;

namespace EmailApp.Controllers
{
    [Route("Email")]
    public class NatificationController : Controller
    {
        private readonly IEmailSender _emailSender;

        private readonly DataContext _dataContext;
        private readonly EmailConfiguration _configuration;

        public NatificationController(DataContext dataContext,IEmailSender emailSender, EmailConfiguration configuration)
        {
            _dataContext = dataContext;
            _emailSender = emailSender;
            _configuration = configuration;
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


        [HttpPost("add", Name = "email-add")]
        public IActionResult Add([FromForm] AddViewModel model)
        {
            var email = new Natification
            {
                FromEmail = _configuration.FromEmail,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content
            };
            List<string> emailAdress = new List<string>();

            if (model.IsBulk == true)
            {
                emailAdress.Add(model.Email.Email);
            }
            else
            {
                var mails = model.Email.Email.Split(',');
          

                foreach (var mail in mails)
                {
                    emailAdress.Add(mail);
                }

            }
            var message = new Message(emailAdress, email.Title, email.Content);

            _dataContext.natifications.Add(email);
            _emailSender.SendEmail(message);
            _dataContext.targetEmails.Add(email.Email);

            _dataContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
