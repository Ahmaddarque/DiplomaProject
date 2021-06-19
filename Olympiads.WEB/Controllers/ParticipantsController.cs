using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Models;
using Olympiads.WEB.Models.Admin;
using Olympiads.WEB.Utils.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{
    //[AdminOnly]
    public class ParticipantsController : Controller
    {
        readonly ICRUDParticipantService CRUDParticipantService;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchParticipants(string search)
        {
            ActionResult result = new EmptyResult();
            var participants = CRUDParticipantService.SearchParticipants(search);
            if (participants.Count() > 0)
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<ParticipantDTO, ParticipantViewModel>()).CreateMapper();
                result = PartialView("ParticipantsPartial", mapper.Map<IEnumerable<ParticipantDTO>, IEnumerable<ParticipantViewModel>>(participants));
            }
            else
            {
                result = PartialView("ResultNotFoundPartial");
            }

            return result;
        }
        public PartialViewResult Edit(int id)
        {
            var mapper = new MapperConfiguration(t => t.CreateMap<ParticipantDTO, ParticipantEditViewModel>().ForMember(x => x.IsEdit,i => i.MapFrom(o => true))).CreateMapper();
            var participant = CRUDParticipantService.GetParticipant(id);
            return PartialView("AddEditPartial",mapper.Map<ParticipantDTO, ParticipantEditViewModel>(participant));
        }

        public JsonResult Save(ParticipantEditViewModel editAdd)
        {
            IEnumerable<ErrorInfo> errors = Enumerable.Empty<ErrorInfo>();
            string error = string.Empty;
            if (ModelState.IsValid)
            {
                
                IValidationResult result;
                if (editAdd.Id > 0)
                {
                    var mapper = new MapperConfiguration(x => x.CreateMap<ParticipantEditViewModel, EditParticipantDTO>()).CreateMapper();
                    result = CRUDParticipantService.EditParticipant(mapper.Map<ParticipantEditViewModel, EditParticipantDTO>(editAdd));
                }
                else
                {
                    var mapper = new MapperConfiguration(x => x.CreateMap<ParticipantEditViewModel, AddParticipantDTO>()).CreateMapper();
                    result = CRUDParticipantService.AddParticipant(mapper.Map<ParticipantEditViewModel, AddParticipantDTO>(editAdd));
                }
                if (!result.IsValid)
                {
                    ModelState.AddModelError(result.Property, result.Error);
                    errors = ModelState.GetErrors();
                }
            }
            else
            {
                errors = ModelState.GetErrors();
            }
            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Add()
        {
            return PartialView("AddEditPartial",new ParticipantEditViewModel() { IsEdit = false,Birthdate = DateTime.Today});
        }
        public void Unblock(int id)
        {
            CRUDParticipantService.Unblock(id);
        }
        public void Block(int id)
        {
            CRUDParticipantService.Block(id);
        }

        public ParticipantsController(ICRUDParticipantService participantService)
        {
            CRUDParticipantService = participantService;
        }
    }
}