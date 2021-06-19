using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Olympiads.BLL.Services
{
    public class TestService : ITestService
    {

        public int UserId { get; }
        public IEnumerable<TestDTO> GetTests(TestSearchDTO testQuery)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                IQueryable<Test> tests = context.Tests.Where(x => x.IsActive);
                if (!string.IsNullOrEmpty(testQuery.Search))
                {
                    tests = tests.Where(x => x.Name.Contains(testQuery.Search) || x.Description.Contains(testQuery.Search));
                }
                if (testQuery.Categories != null && testQuery.Categories.Length > 0)
                {
                    tests = tests.Where(x => testQuery.Categories.Contains(x.Id));
                }
                if (testQuery.Subjects != null && testQuery.Subjects.Length > 0)
                {
                    tests = tests.Where(x => testQuery.Subjects.Contains(x.SubjectId.Value));
                }
                
                var mapper = new MapperConfiguration(x => x.CreateMap<Test, TestDTO>()
                                                            .ForMember(t => t.Subject,c => c.MapFrom(t => t.Subject.Name)))
                                                            .CreateMapper();

                var mappedTests = tests.OrderByDescending(x => x.CreationTime).Skip(testQuery.StartIdx).Take(testQuery.PageIdx).ToList();
            
                return mapper.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(mappedTests);
            }
        }

    }
}
