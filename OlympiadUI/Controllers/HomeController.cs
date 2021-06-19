using AutoMapper;
using OlympiadUI.Email;
using OlympiadUI.Helpers;
using OlympiadUI.Models;
using OlympiadUI.Repository;
using OlympiadUI.Utils;
using OlympiadUI.ViewModels;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlympiadUI.Controllers
{

    public class HomeController : Controller
    {
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
        public ActionResult Login(AuthParticipant authParticipant)
        {
            ActionResult Login = View(); 
            using (OlympiadDb context = new OlympiadDb())
            {
                var participant = context.Participants.GetByCredentials(authParticipant.Login,authParticipant.Password);
                if (participant != null)
                {
                    Session.SetParticipant(participant);
                    Login = RedirectToAction("Index", "Account");
                }
                else
                    ViewBag.Error = "Неверный логин или пароль";
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
        public ActionResult Register(RegisterParticipant registerParticipant)
        {
            ActionResult Account = View();
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(x => x.CreateMap<RegisterParticipant, Participant>()
                                                           .ForMember(x => x.RegistrationIP,u => u.MapFrom(x => HttpContext.Request.UserHostAddress))
                                                           .ForMember(x => x.RegistrationTime,u => u.MapFrom(x => DateTime.Now)));
                var participant = new Mapper(config).Map<RegisterParticipant,Participant>(registerParticipant);
                using (OlympiadDb context = new OlympiadDb())
                {
                    context.Participants.Add(participant);
                    Session.SetParticipant(participant);
                    context.SaveChanges();
                }
                Account = RedirectToAction("Index", "Account");
            }
            return Account;
        }

        [ParticipantOnly]
        public ActionResult Logout()
        {
            Session.Logout();
            return RedirectToAction("Index","Home");
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

        [HttpGet]
        public ActionResult RestoreByEmail(string code)
        {
            ActionResult Restore = HttpNotFound();
            using (OlympiadDb context = new OlympiadDb())
            {
                if (context.EmailRestores.ExistsWithCode(code))
                {
                    var emailRestore = context.EmailRestores.GetWithCode(code);
                    Restore = View("ChangePassword",new ChangePasswordViewModel() {ParticipantId = emailRestore.ParticipantId.Value });
                }
            }

            return Restore;
        }
        public ActionResult RestoreByEmail(RestoreByEmail restore)
        {
            ActionResult result = View("RestoreEmail", restore);
            using (OlympiadDb context = new OlympiadDb())
            {
                if (context.Participants.ExistsWithEmail(restore.Email))
                {
                    var participant = context.Participants.GetByEmail(restore.Email);
                    var rand = new Random();
                    string code = string.Empty;
                    for (int i = 0; i < 10; i++)
                    {
                        code += rand.Next(0,9);
                    }
                    context.EmailRestores.Add(new EmailRestore() { ParticipantId = participant.Id,Code=code,Time = DateTime.Now});
                    context.SaveChanges();

                    using (EmailAgent emailAgent = new EmailAgent())
                    {
                        MailMessage message = new RestorePasswordMessage(code);
                        message.To.Add(new MailAddress(participant.Email));
                        emailAgent.Send(message);
                    }
                    result = View("ConfirmationEmailSent");
                }
                else
                {
                    ViewBag.Error = "Email не найден в системе";
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