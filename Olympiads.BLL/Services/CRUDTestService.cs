using AutoMapper;
using Olympiads.BLL.BusinessModels;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class CRUDTestService : ICRUDTestService
    {
        private readonly OlympiadDb db = new OlympiadDb();
        public IEnumerable<TestDTO> GetTests(TestInfoDTO testInfo)
        {
            IEnumerable<TestDTO> tests = new List<TestDTO>();
            var mapper = new MapperConfiguration(x => x.CreateMap<Test, TestDTO>()
                                                       .ForMember(t => t.Subject, i => i.MapFrom(r => r.Subject.Name))).CreateMapper();
            if (int.TryParse(testInfo.Search, out int id))
            {
                var test = db.Tests.FirstOrDefault(x => x.Id == id);
                if (test != null)
                    tests = new List<TestDTO>() { (mapper.Map<Test, TestDTO>(test)) };
            }
            else
            {
                tests = mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(db.Tests.Where(x => x.Name.Contains(testInfo.Search)                                                                            && x.IsActive == testInfo.IsActive).ToList());
            }

            return tests;
        }
        public TestSaveDTO GetTest(int TestId)
        {
            var test = db.Tests.FirstOrDefault(x => x.Id == TestId);
            var mapper = new MapperConfiguration(x => x.CreateMap<Test, TestSaveDTO>()
                                                       .ForMember(t => t.Subject, i => i.MapFrom(r => r.Subject.Name))
                                                       .ForMember(q => q.Category,u => u.MapFrom(e => e.Category.Name))).CreateMapper();
            if (test == null)
            {
                return null;
            }
            return mapper.Map<Test, TestSaveDTO>(test);

        }
        public void Activate(int TestId)
        {
            var test = db.Tests.Find(TestId);
            if (test != null)
            {
                test.IsActive = true;
            }

            db.SaveChanges();
        }
        public void Deactivate(int TestId)
        {
            var test = db.Tests.Find(TestId);
            if (test != null)
            {
                test.IsActive = false;
            }

            db.SaveChanges();
        }
        public void Save(TestSaveDTO save)
        {
            Test test = null;
            if (save.Id == 0)
            {
                test = new Test
                {
                    Name = save.Name,
                    Description = save.Description
                };
                db.Tests.Add(test);
            }
            else
            {
                test = db.Tests.First(x => x.Id == save.Id);
                test.Description = save.Description;
                test.Name = save.Name;
                test.CreationTime = DateTime.Now;
            }
            var category = db.Categories.Where(x => x.Name == save.Category).FirstOrDefault();
            if (category == null)
            {
                category = db.Categories.First();
            }
            var subject = db.Subjects.FirstOrDefault(x => save.Subject == x.Name);

            test.Category = category;
            test.Subject = subject;
            test.CreationTime = DateTime.Now;
            test.IsActive = false;
            db.SaveChanges();
        }
    }
}
