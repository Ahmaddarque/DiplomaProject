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
    public class NotAuthorized : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var role = filterContext.HttpContext.Session.GetRole();

            switch (role)
            {
                case Role.Visiter:
                    {

                        break;
                    }

                case Role.Admin:
                    {
                        filterContext.Result = new HttpNotFoundResult();
                        break;
                    }

                case Role.Participant:
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                        {
                            { "controller","Account"},{"action","Index"}
                        });
                        break;
                    }

                default:
                    break;
            }
        }

    }
}