using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OlympiadUI.Email
{
    public class EmailAgent : SmtpClient
    {
        public EmailAgent() : base("smtp.mail.ru", 2525)
        {
            Credentials = new NetworkCredential("ddollar78@mail.ru", "JeSuisContent1");
            EnableSsl = true;
        }
    }
}