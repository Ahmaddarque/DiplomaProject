
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Olympiads.BLL.Email
{
    internal sealed class RestorePasswordMessage : BaseMessage
    {
        public RestorePasswordMessage(string code)
        {
            Subject = "Восстановление пароля от Olimpiada.ru";
            Body = $"<a href=\"localhost://45566{code}\"></a>";
        }
    }
}