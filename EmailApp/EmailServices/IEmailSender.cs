namespace EmailApp.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
