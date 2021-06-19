using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.BLL.Services;
using Olympiads.WEB.Helpers;
using Olympiads.WEB.Models;
using Olympiads.WEB.Utils.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Olympiads.WEB.Controllers
{
    //[UserOnly]
    //public class TestsController : Controller
    //{
    //    private TestTaskService taskService;

    //    ITestService TestService { get; set; }
    //    TestTaskService TaskService => taskService ?? (taskService = new TestTaskService(Session.GetUserInfo().Id));

    //    public TestsController(ITestService service)
    //    {
    //        TestService = service;
    //    }
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    public ActionResult Test(int Number)
    //    {
    //        var mapper = new MapperConfiguration(x => x.CreateMap<TestTaskInfoDTO, TaskInfoViewModel>()).CreateMapper();
    //        var task = mapper.Map<TestTaskInfoDTO, TaskInfoViewModel>(TaskService.GetTask(Number));
    //        ViewBag.Title = "Тест";
    //        return View(task);
    //    }

    //    public ActionResult StartTest(int TestId)
    //    {
    //        TaskService.StartTest(TestId);
    //        return RedirectToAction("Test", new { @Number = 1 });
    //    }

    //    public void Submit(AnswerViewModel answer)
    //    {
    //        TaskService.Answer(answer.TaskNumber, answer.UserAnswer);
    //    }

    //    public ActionResult Result()
    //    {
    //        var res = TaskService.GetResults();
    //        var mapper = new MapperConfiguration(x => x.CreateMap<ActivityResultDTO, ActivityResultVM>()).CreateMapper();
    //        ViewBag.Title = "Результаты";
    //        return View(mapper.Map<ActivityResultDTO, ActivityResultVM>(res));
    //    }

    //    public ActionResult RenderTests(TestSearch testSearch)
    //    {
    //        ActionResult Tests = HttpNotFound();
    //        if (ModelState.IsValid)
    //        {
    //            testSearch.Categories = testSearch.Categories.RemoveZeros();
    //            testSearch.Subjects = testSearch.Subjects.RemoveZeros();
    //            var mapper = new MapperConfiguration(x => x.CreateMap<TestSearch, TestSearchDTO>()).CreateMapper();
    //            var search = mapper.Map<TestSearch, TestSearchDTO>(testSearch);
    //            var tests = TestService.GetTests(search);

    //            if (tests.Count() == 0)
    //            {
    //                Tests = PartialView("ResultNotFoundPartial");
    //            }
    //            else
    //            {
    //                Tests = PartialView("TestsPartial", new MapperConfiguration(u => u.CreateMap<TestDTO, TestVM>()).CreateMapper()
    //                                                                                                               .Map<IEnumerable<TestDTO>, IEnumerable<TestVM>>(tests));
    //            }

    //        }

    //        return Tests;
    //    }
    //}
}