
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
namespace Olympiads.WEB.Utils.Filters
{
    public class ParticipantOnly : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.Session.GetUserInfo();
            if (user == null || user.Role != Role.Participant)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller","Home"},{ "action","Login"}
                });
            }
        }
    }
}