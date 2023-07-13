namespace SendMail.Services;
using SendMail.Model;

public interface IEmailServices
{
    void sendEmail(string To, string body, string subject);
  
}
