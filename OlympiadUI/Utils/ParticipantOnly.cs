using OlympiadUI.Helpers;
using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
namespace OlympiadUI.Utils
{
    public class ParticipantOnly : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetRole() != Role.Participant)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller","Home"},{ "action","Login"}
                });

                
            }
        }
    }
}