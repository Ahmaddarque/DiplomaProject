
using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Models;
using Olympiads.WEB.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympiadUI.Controllers
{
    public class CommonController : Controller
    {
        public IParticipantService ParticipantService { get; set; }
        public CommonController(IParticipantService service)
        {
            ParticipantService = service;
        }
        public ActionResult RenderHeading()
        {
            ActionResult Heading;
            var user = Session.GetUserInfo();
            if (user != null && user.Role == Role.Participant)
            {
                var participantProfile = ParticipantService.GetProfileInfo(user.Id);
                var mapper = new MapperConfiguration(x => x.CreateMap<ParticipantProfileDTO,ParticipantProfileViewModel>()).CreateMapper();
                Heading = PartialView("ProfilePartial",mapper.Map<ParticipantProfileDTO, ParticipantProfileViewModel>(participantProfile));
            }
            else
            {
                Heading = PartialView("LoginRegisterPartial");
            }
            return Heading;
        }
    }
}