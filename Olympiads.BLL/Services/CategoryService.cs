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
    public class CategoryService : ICategoryService
    {
        public IEnumerable<CategoryDTO> GetAll()
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<ParticipantCategory,CategoryDTO>()).CreateMapper();
                var categories = context.Categories.ToList();

                return mapper.Map<IEnumerable<ParticipantCategory>, IEnumerable<CategoryDTO>>(categories);
            }
        }
    }
}
