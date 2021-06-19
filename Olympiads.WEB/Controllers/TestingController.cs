using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Models;
using Olympiads.WEB.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{
    public class TestingController : Controller
    {
        readonly ICRUDTestService testService;
        readonly ISubjectService subjectService;
        readonly ICategoryService categoryService;
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SearchTests(ActivitySearch testSearchInfo)
        {
            PartialViewResult result;
            var mapper = new MapperConfiguration(x => x.CreateMap<ActivitySearch, TestInfoDTO>()).CreateMapper();
            var tests = testService.GetTests(mapper.Map<ActivitySearch, TestInfoDTO>(testSearchInfo));
            if (tests.Count() > 0)
            {
                mapper = new MapperConfiguration(x => x.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                result = PartialView("TestingPartial", mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(tests));
            }
            else
            {
                result = PartialView("ResultNotFoundPartial");
            }

            return result;
        }
        public PartialViewResult GetTest(int TestId)
        {
            var test = testService.GetTest(TestId);
            if (test != null)
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<TestSaveDTO, EditTestViewModel>()).CreateMapper();
                var editTestVm = mapper.Map<TestSaveDTO, EditTestViewModel>(test);
                var subjects =  subjectService.GetAll().Select(u => u.Name);
                editTestVm.AvailableSubjects = new SelectList(subjects);
                editTestVm.AvailableCategories = new SelectList(categoryService.GetAll().Select(u => u.Name));
                //editTestVm.AvailableCategories.FirstOrDefault(x => x.Text == editTestVm.Category).Selected = true;
                //editTestVm.AvailableSubjects.FirstOrDefault(x => x.Text == editTestVm.Subject).Selected = true;
                editTestVm.IsEdit = true;

                return PartialView("AddEditPartial",editTestVm);
            }
            else
            {
                return PartialView("ResultNotFound");
            }
        }
        public PartialViewResult Add()
        {
            var editTestVm = new EditTestViewModel
            {
                AvailableSubjects = new SelectList(subjectService.GetAll().Select(u => u.Name)),
                AvailableCategories = new SelectList(categoryService.GetAll().Select(u => u.Name)),
                IsEdit = false
            };
            return PartialView("AddEditPartial",editTestVm);
        }
        public JsonResult Save(EditTestViewModel edit)
        {
            IEnumerable<ErrorInfo> errors = Enumerable.Empty<ErrorInfo>();
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(t => t.CreateMap<EditTestViewModel, TestSaveDTO>()).CreateMapper();
                testService.Save(mapper.Map<EditTestViewModel, TestSaveDTO>(edit));
            }
            else
            {
                errors = ModelState.GetErrors();
            }

            return Json(errors,JsonRequestBehavior.AllowGet);
            
        }
        public void Activate(int TestId)
        {
            testService.Activate(TestId);
        }
        public void Deactivate(int TestId)
        {
            testService.Deactivate(TestId);
        }

        public TestingController(ICRUDTestService testService,ISubjectService subjectService, ICategoryService categoryService)
        {
            this.testService = testService;
            this.subjectService = subjectService;
            this.categoryService = categoryService;
        }
    }
}