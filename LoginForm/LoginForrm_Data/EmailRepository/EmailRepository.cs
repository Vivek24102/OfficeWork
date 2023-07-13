using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;

namespace LoginForm_Data.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _config;
        public EmailRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void sendEmail(string To, string body, string subject)
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
