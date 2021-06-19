using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{
    public class StatisticsController : Controller
    {
        readonly IStatsService statsService;
        public JsonResult MonthVisits(int month)
        {
            var start = DateTime.Now.AddDays(-month*30);
            var stats = statsService.VisitSeries(start,DateTime.Now).Select(x => new DateStat()
            {
                Count = x.Count,
                Date = x.Time.ToString("dd")
            });
            return Json(stats, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WeeklyVisits()
        {
            var start = DateTime.Now.AddDays(-7);
            var stats = statsService.VisitSeries(start, DateTime.Now)
                                    .Select(x => new DateStat()
                                     {
                                         Count = x.Count,
                                         Date = x.Time.ToString("dd")
                                     });
            return Json(stats, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MonthRegistrations(int month)
        {
            var start = DateTime.Now.AddDays(-30 * month);
            var stats = statsService.RegistrationSeries(start,DateTime.Now).Select(x => new DateStat()
            {
                Count = x.Count,
                Date = x.Time.ToString("dd")
            });
            return Json(stats, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WeeklyRegistrations()
        {
            var start = DateTime.Now.AddDays(-7);
            var stats = statsService.RegistrationSeries(start,DateTime.Now).Select(x => new DateStat()
            {
                Count = x.Count,
                Date = x.Time.ToString("dd")
            });
            return Json(stats, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MonthParticipantVisiterRatio(int month)
        {
            var start = DateTime.Now.AddMonths(-month);
            var stat = statsService.RegistrationToVisits(start,DateTime.Now);
            return Json(stat, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WeeklyParticipantVisiterRatio()
        {
            var start = DateTime.Now.AddDays(-7);
            var stat = statsService.RegistrationToVisits(start,DateTime.Now);
            return Json(stat,JsonRequestBehavior.AllowGet);
        }
        public JsonResult WeeklyTests()
        {
            var start = DateTime.Now.AddDays(-7);
            var stats = statsService.OlympiadPassSeries(start, DateTime.Now)
                                    .Select(x => new DateStat()
                                    {
                                        Count = x.Count,
                                        Date = x.Time.ToString("dd")
                                    });
            return Json(stats, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult Activities()
        {
            return View();
        }


        
        public StatisticsController(IStatsService statsService)
        {
            this.statsService = statsService;
        }
    }
}