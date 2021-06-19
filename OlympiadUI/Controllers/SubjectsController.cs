using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympiadUI.Controllers
{
    public class SubjectsController : Controller
    {
        public ActionResult RenderSubjectBadges(int TestId)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var testSubjects =  context.KnowledgeFields.Where(x => x.TestId == TestId).Select(u => u.Subject).ToList();
                return PartialView("SubjectBadgesPartial", testSubjects);
            }
        }
        public ActionResult RenderSubjectFilters()
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                return PartialView("SubjectFiltersPartial", context.Subjects.ToList());
            }
                
        }
    }
}