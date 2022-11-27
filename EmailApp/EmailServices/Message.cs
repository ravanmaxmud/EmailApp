﻿using EmailApp.Controllers.Models;
using MimeKit;

namespace EmailApp.EmailServices
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to , string title , string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));

             Title = title;
              Content = content;


        }
    }
}
