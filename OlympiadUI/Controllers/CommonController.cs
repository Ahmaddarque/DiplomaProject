using OlympiadUI.Helpers;
using OlympiadUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympiadUI.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult RenderHeading()
        {
            ActionResult Heading = PartialView("LoginRegisterPartial");
            if (Session.GetRole() == Models.Role.Participant)
            {
                Heading = PartialView("ProfilePartial",Session.GetParticipant());
            }
            return Heading;
        }
    }
}