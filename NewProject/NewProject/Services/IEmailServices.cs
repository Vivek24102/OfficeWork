namespace NewProject.Services;
using NewProject.Model;

public interface IEmailServices
{
    void sendEmail(string To, string body, string subject);
  
}
