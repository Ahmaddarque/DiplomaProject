using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class SubjectsService : ISubjectService
    {
        public IEnumerable<SubjectDTO> GetAll()
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var subjects = context.Subjects.ToList();
                var mapper = new MapperConfiguration(x => x.CreateMap<Subject, SubjectDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(subjects);
            }
        }
    }
}
