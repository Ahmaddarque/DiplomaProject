using AutoMapper;
using Olympiads.BLL.DTO;
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
    [AdminOnly]
    public class OlympiadsController : Controller
    {
        readonly ICRUDOlympiadService olympiadService;
        readonly ISubjectService subjectService;
        readonly ICategoryService categoryService;
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetOlympiads(ActivitySearch olympiadSearchInfo)
        {
            var mapper = new MapperConfiguration(t => t.CreateMap<ActivitySearch, OlympiadInfoDTO>()).CreateMapper();
            var olymps = olympiadService.GetOlympiads(mapper.Map<ActivitySearch, OlympiadInfoDTO>(olympiadSearchInfo));
            mapper = new MapperConfiguration(d => d.CreateMap<OlympiadDTO, Olympiad>()).CreateMapper();
            var olympiads = mapper.Map<IEnumerable<OlympiadDTO>, IEnumerable<Olympiad>>(olymps);
            if (olympiads.Any())
            {
                return PartialView("OlympiadsPartial", olympiads);
            }
            else
            {
                return PartialView("ResultNotFoundPartial");
            }
            
        }
        public PartialViewResult GetOlympiad(int OlympiadId)
        {
            PartialViewResult result;
            var mapper = new MapperConfiguration(d => d.CreateMap<SaveOlympiadDTO, SaveOlympiad>()
                                                   .ForMember(x => x.Hours, t => t.MapFrom(r => r.Minutes / 60))
                                                   .ForMember(r => r.Minutes,e => e.MapFrom(w => w.Minutes % 60))).CreateMapper();
            var olympiad = olympiadService.GetOlympiad(OlympiadId);
            if (olympiad != null)
            {
                var olymp = mapper.Map<SaveOlympiadDTO, SaveOlympiad>(olympiad);
                olymp.Subjects = new SelectList(subjectService.GetAll().Select(u => u.Name));
                olymp.Categories = new SelectList(categoryService.GetAll().Select(u => u.Name));
                olymp.IsEdit = true;
                result = PartialView("AddEditPartial",olymp);
            }
            else
            {
                result = PartialView("ResultNotFound");
            }

            return result;
        }
        public PartialViewResult Add()
        {
            var olympiad = new SaveOlympiad() { IsEdit = false };
            olympiad.Subjects = new SelectList(subjectService.GetAll().Select(u => u.Name));
            olympiad.Categories = new SelectList(categoryService.GetAll().Select(u => u.Name));
            return PartialView("AddEditPartial",olympiad);
        }

        public JsonResult Save(SaveOlympiad olympiad)
        {
            IEnumerable<ErrorInfo> errors = Enumerable.Empty<ErrorInfo>();
            if (ModelState.IsValid)
            {
                if ((olympiad.End - olympiad.Start).Days < 2)
                {
                    ModelState.AddModelError("Start", "На проведение олимпиады должно быть отведено минимум 2 дня");
                }
                else
                {
                    var mapper = new MapperConfiguration(x => x.CreateMap<SaveOlympiad, SaveOlympiadDTO>()
                                                                               .ForMember(y => y.Minutes, m => m.MapFrom(z => z.Hours * 60 + z.Minutes))).CreateMapper();
                    var validationResult = olympiadService.Save(mapper.Map<SaveOlympiad, SaveOlympiadDTO>(olympiad));
                    if (!validationResult.IsValid)
                    {
                        ModelState.AddModelError(validationResult.Property, validationResult.Error);
                    }
                }
                
            }

            errors = ModelState.GetErrors();

            return Json(errors,JsonRequestBehavior.AllowGet);
        }
        public void Activate(int OlympiadId)
        {
            olympiadService.Activate(OlympiadId);
        }
        public void Deactivate(int OlympiadId)
        {
            olympiadService.Activate(OlympiadId);
        }

        public OlympiadsController(ICRUDOlympiadService olympiadService, ICategoryService categoryService, ISubjectService subjectService)
        {
            this.olympiadService = olympiadService;
            this.categoryService = categoryService;
            this.subjectService = subjectService;
        }
    }
}