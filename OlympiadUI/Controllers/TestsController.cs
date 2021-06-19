using AutoMapper;
using Newtonsoft.Json;
using OlympiadUI.Helpers;
using OlympiadUI.Models;
using OlympiadUI.Repository;
using OlympiadUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Task = System.Threading.Tasks.Task;
using TaskModel = OlympiadUI.Models.Task;

namespace OlympiadUI.Controllers
{
    public class TestsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            ActionResult Test = HttpNotFound();
            using (OlympiadDb context = new OlympiadDb())
            {
                var pass = context.TestPassings.GetByVisiter(Session.GetVisiter().Id).FilterByStatus(TestStatus.Started).FirstOrDefault();
                var passings = context.TestPassings.ToList();
                if (pass != null)
                {
                    var totalCount = context.Tasks.GetCountOfTest(pass.TestId);
                    var answer = context.TaskAnswers.GetLastTask(pass.Id);
                    var number = 1;
                    if (answer != null) 
                    {
                         number = answer.Number + 1;
                    }

                    if (number > totalCount)
                    {
                        pass.Status = TestStatus.Completed;
                        context.SaveChanges();

                        context.TaskAnswers.Select(x => x.Answer);
                        Test = View("TestFinished");
                    }
                    else
                    {
                        var task = context.Tasks.GetTaskFor(pass.TestId, number);
                        var config = new MapperConfiguration(x => x.CreateMap<TaskModel, TaskInfo>().ForMember(x => x.TestName, x => x.MapFrom(x => x.Test.Name))
                                                                                                    .ForMember(x => x.Total, x => x.MapFrom(x => totalCount)));
                        var taskVm = new Mapper(config).Map<TaskModel, TaskInfo>(task);
                        Test = View(taskVm);
                    }
                }
            }
            return Test;
        }

        [HttpGet]
        public ActionResult StartTest(int TestId)
        {
            ActionResult StartTest = HttpNotFound();
            using (OlympiadDb context = new OlympiadDb())
            {
                if (context.Tests.ExistsWithId(TestId))
                {
                    var test = context.Tests.GetById(TestId);
                    context.TestPassings.Add(new TestPassing(Session.GetVisiter().Id,test.Id));
                    context.SaveChanges();
                    StartTest = RedirectToAction("Test");
                }
            }

            return StartTest;
        }

        [HttpPost]
        public ActionResult Submit(AnswerViewModel answer)
        {
            ActionResult result = HttpNotFound();
            using (OlympiadDb context = new OlympiadDb())
            {
                if (context.TestPassings.IsPassingATest(Session.GetVisiter().Id))
                {
                    result = RedirectToAction("Test");
                    var pass = context.TestPassings.GetCurrentPassing(Session.GetVisiter().Id);
                    var task = context.TaskAnswers.GetLastTask(pass.Id);
                    if (task == null)
                        task = context.Tasks.GetTaskFor(pass.TestId, 1);
                    else
                    {
                        task = context.Tasks.GetTaskFor(pass.TestId, task.Number + 1);
                    }

                    
                    context.TaskAnswers.Add(new TaskAnswer() { Answer = answer.UserAnswer, TaskId = task.Id, TestPassingId = pass.Id });
                    context.SaveChanges();
                }
                
                return result;
            }
        }

        public ActionResult RenderInitialTests()
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var tests = context.Tests.Take(10).ToList();
                return PartialView("TestsPartial", tests);
            }
        }

        private ActionResult RenderTests(TestSearchViewModel testSearch)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var tests = context.Tests.AsQueryable<Test>();
                if (!string.IsNullOrEmpty(testSearch.Search))
                {
                    tests = tests.FilterByName(testSearch.Search);
                }
                if (testSearch.Categories != null)
                {
                    tests = tests.FilterByCategories(testSearch.Categories);
                }
                if (testSearch.Subjects != null)
                {
                    tests = tests.FilterBySubjects(testSearch.Subjects);
                }

                tests = tests.OrderBy(x => x.Id).Skip(testSearch.StartIdx).Take(testSearch.PageIdx);

                if (tests.Count() == 0)
                {
                    return PartialView("ResultNotFoundPartial");
                }
                return PartialView("TestsPartial", tests.ToList());
            }
        }

        public ActionResult RenderTests(string json)
        {
            var searchVM = JsonConvert.DeserializeObject<TestSearchViewModel>(json);
            return RenderTests(searchVM);
        }
    }
}