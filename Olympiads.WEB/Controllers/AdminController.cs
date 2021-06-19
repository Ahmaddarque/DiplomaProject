using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Models.Admin;
using Olympiads.WEB.Utils.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{
    
    public class AdminController : Controller
    {
        readonly IAdminService adminService;
        readonly IStatsService statsService;


        public AdminController(IAdminService adminService,IStatsService statsService)
        {
            this.adminService = adminService;
            this.statsService = statsService;
        }
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminAuthViewModel auth)
        {
            ActionResult result = new EmptyResult();
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<AdminAuthViewModel, AuthAdminDTO>()).CreateMapper();
                var info = adminService.Login(mapper.Map<AdminAuthViewModel, AuthAdminDTO>(auth));

                if (info.IsLogged)
                {
                    Session.SetUserInfo(new Roles.UserInfo() { Id = info.Id, Role = Roles.Role.Admin });
                    result = RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Error = "Пользователь не найден";
                    result = View();
                }
            }
            else
            {
                result = View(auth);
            }

            return result;
        }
        #endregion
        [AdminOnly]
        public ActionResult Security()
        {
            return View(new SecurityCredentials());
        }
        [AdminOnly]
        [HttpPost]
        public ActionResult Security(SecurityCredentials credentials)
        {
            ActionResult Security = new EmptyResult();
            if (ModelState.IsValid)
            {
                
                var mapper = new MapperConfiguration(x => x.CreateMap<SecurityCredentials, ChangeCredentialsDTO>()).CreateMapper();
                var changeCredentials = mapper.Map<SecurityCredentials, ChangeCredentialsDTO>(credentials);
                changeCredentials.OldLogin = adminService.GetAdminInfo(Session.GetUserInfo().Id).Login;

                adminService.ChangeCredentials(changeCredentials);
                ViewBag.Success = "Данные успешно обновлены";
                Security = View();
            }
            else
            {
                Security = View(credentials);
            }

            return Security;
        }

        public ActionResult Dashboard()
        {
            var date = DateTime.Now;
            var stats = new DashboardViewModel()
            {
                VisitersLastDay = statsService.VisitsCount(date),
                ParticipantsLastDay = statsService.RegistrationsCount(date),
                OlympiadsLastDay = statsService.OlympiadPassCount(date),
                TestsLastDay = statsService.TestPassCount(date)
            };
            return View(stats);
        }

        public ActionResult About()
        {
            return View();
        }
        [AdminOnly]
        public ActionResult Logout()
        {
            Session.SetUserInfo(null);
            return RedirectToAction("Login");
        }
        
    }
}