namespace WebApiIdentityDemo.Services.EmailRepository
{
    public interface IEmailRepository
    {
        void sendEmail(string To, string body, string subject);
    }
}
