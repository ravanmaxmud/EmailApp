namespace EmailApp.EmailServices
{
    public class EmailConfiguration
    {
        public string FromEmail { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
