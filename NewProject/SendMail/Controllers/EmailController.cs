using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SendMail.Model;
using SendMail.Services;

namespace SendMail.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServices emailServices;

        public EmailController(IEmailServices emailServices) 
        {
            this.emailServices = emailServices;
        }
        [HttpPost]
        public IActionResult SendEmail(string To, string body, string subject)
        {
            emailServices.sendEmail(To,body,subject);
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("bart.hettinger@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("vivekvarde09@gmail.com"));
            //email.Subject = "test email Subject";
            //email.Body = new TextPart(TextFormat.Html)
            //{
            //    Text = body
            //};
            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);
            //smtp.Authenticate("bart.hettinger@ethereal.email", "tD27gw33qHWbUn3Cm64");
            //smtp.Send(email);
            //smtp.Disconnect(true);

            return Ok();
        }
    }
}
