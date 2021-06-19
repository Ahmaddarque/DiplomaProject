using Olympiads.WEB.Helpers;
using Olympiads.WEB.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Utils.Filters
{
    public class UserOnly : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.Session.GetUserInfo();
            if (user != null && user.Role == Role.Admin)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}