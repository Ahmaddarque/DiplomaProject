using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Email;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Models;
using Olympiads.WEB.Roles;
using Olympiads.WEB.Utils.Filters;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{

    public class HomeController : Controller
    {
        public IParticipantService ParticipantService { get; set; }

        public HomeController(IParticipantService service)
        {
            ParticipantService = service;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [NotAuthorized]
        public ActionResult Login()
        {
            return View();
        }

        [NotAuthorized]
        [HttpPost]
        public ActionResult Login(AuthParticipantViewModel authParticipant)
        {
            ActionResult Login = View(authParticipant);
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<AuthParticipantViewModel, AuthParticipantDTO>()).CreateMapper();
                var participantDTO = mapper.Map<AuthParticipantViewModel, AuthParticipantDTO>(authParticipant);

                var participantLogged = ParticipantService.Login(participantDTO);
                if (participantLogged.Logged)
                {
                    Login = RedirectToAction("Index", "Account");
                    Session.SetUserInfo(new UserInfo() { Role = Role.Participant,Id = participantLogged.Id});
                }
                else
                {
                    Login = View();
                    ViewBag.Error = "Неверный логин или пароль";
                }
            }

            return Login;
        }
        [NotAuthorized]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [NotAuthorized]
        public ActionResult Register(RegisterParticipantViewModel registerParticipant)
        {
            ActionResult Account = View();
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<RegisterParticipantViewModel, RegisterParticipantDTO>()
                                                           .ForMember(y => y.IP, u => u.MapFrom(z => HttpContext.Request.UserHostAddress))).CreateMapper();
                var registerParticipantDTO = mapper.Map<RegisterParticipantViewModel, RegisterParticipantDTO>(registerParticipant);
                ParticipantService.Register(registerParticipantDTO);
                Account = RedirectToAction("Login", "Home");
            }
            return Account;
        }



        [NotAuthorized]
        public ActionResult Restore()
        {
            return View("RestorePassword");
        }

        [NotAuthorized]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Restore(RestoreMethod method)
        {
            ActionResult result = HttpNotFound();
            switch (method)
            {
                case RestoreMethod.Phone:
                    {
                        result = View("RestorePhone");
                        break;
                    }

                case RestoreMethod.Email:
                    {
                        result = View("RestoreEmail");
                        break;
                    }
            }

            return result;
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {
            ActionResult result = View();
            if (ModelState.IsValid)
            {
                ParticipantService.SubmitRestore(changePassword.Code,changePassword.NewPassword);
                result = RedirectToAction("Login");
            }
            
            return result;
        }

        [HttpGet]
        public ActionResult RestoreByEmail(string code)
        {
            ActionResult result = HttpNotFound();
            if (ParticipantService.VerifyEmailCode(code))
            {
                result = View("ChangePassword",new ChangePasswordViewModel() {Code = code });
            }

            return result;
        }

        public ActionResult RestoreByEmail(RestoreByEmailViewModel restore)
        {
            ActionResult result = View("RestoreEmail");
            if (ModelState.IsValid)
            {
                if (!ParticipantService.BeginRestore(restore.Email))
                {
                    ViewBag.Error = "Email не найден в системе";
                }
                else
                {
                    result = View("ConfirmationEmailSent");
                }
            }

            return result;
        }


        public ActionResult About()
        {
            return View();
        }
    }
}