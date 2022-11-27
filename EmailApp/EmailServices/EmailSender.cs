using MailKit.Net.Smtp;
using MimeKit;

namespace EmailApp.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _configuration;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _configuration = emailConfig;
        }

        public void SendEmail(Message message) 
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }


        private MimeMessage CreateEmailMessage(Message message) 
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(String.Empty,_configuration.FromEmail));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Title;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage) 
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_configuration.Email, _configuration.Password);
                    client.Send(mailMessage);
                }
                catch
                {

                    throw;
                }
                finally 
                {
                    client.Disconnect(true);
                   client.Dispose();
                }
            }
        }
    }
}
