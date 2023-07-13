using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;

using MailKit.Net.Smtp;

namespace NewProject.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _config;
        public EmailServices(IConfiguration configuration) 
        {
            _config = configuration;
        }
        public void sendEmail(string To,string body,string subject)
        {
           
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("funishere97@gmail.coml"));
                email.To.Add(MailboxAddress.Parse(To));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = body
                };
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("funishere97@gmail.com", "fziaplzrgmvkzslf");
                smtp.Send(email);
                smtp.Disconnect(true);

              
          
        }
    }
}
