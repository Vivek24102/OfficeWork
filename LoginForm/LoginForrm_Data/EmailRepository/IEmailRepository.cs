using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm_Data.EmailRepository
{
    public interface IEmailRepository
    {
        void sendEmail(string To, string body, string subject);
    }
}
