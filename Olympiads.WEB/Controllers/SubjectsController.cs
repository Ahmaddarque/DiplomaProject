using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympiadUI.Controllers
{
    public class SubjectsController : Controller
    {
        ISubjectService SubjectService { get; set; }
        public SubjectsController(ISubjectService service)
        {
            SubjectService = service;
        }
        public ActionResult RenderSubjectFilters()
        {
            var subjects = SubjectService.GetAll();
            var mapper = new MapperConfiguration(x => x.CreateMap<SubjectDTO, SubjectVM>()).CreateMapper();
            return PartialView("SubjectFiltersPartial", mapper.Map < IEnumerable<SubjectDTO>, IEnumerable<SubjectVM> >(subjects));
        }
    }
}