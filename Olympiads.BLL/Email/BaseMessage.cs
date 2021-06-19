using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Olympiads.BLL.Email
{
    internal class BaseMessage : MailMessage
    {
        public BaseMessage()
        {
            From = new MailAddress("ddollar78@mail.ru");
        }
    }
}