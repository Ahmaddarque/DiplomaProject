using Olympiads.WEB.Helpers;
using Olympiads.WEB.Utils.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OlympiadUI.Controllers
{
    [ParticipantOnly]
    public class AccountController : Controller
    {
        public ActionResult Olympiads()
        {
            return View();
        }
        public ActionResult CheckCertificate()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [ParticipantOnly]
        public ActionResult Logout()
        {
            Session.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}