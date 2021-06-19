using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
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
    public class CRUDOlympiadService : ICRUDOlympiadService
    {
        readonly OlympiadDb db = new OlympiadDb();
        public IEnumerable<OlympiadDTO> GetOlympiads(OlympiadInfoDTO info)
        {
            var result = Enumerable.Empty<OlympiadDTO>();
            var mapper = new MapperConfiguration(t => t.CreateMap<Olympiad, OlympiadDTO>()
                                                       .ForMember(x => x.Subject,i => i.MapFrom(r => r.Subject.Name))).CreateMapper();
            if (info != null)
            {
                if (!string.IsNullOrEmpty(info.Search) && int.TryParse(info.Search, out int id))
                {
                    var olymp = db.Olympiads.Find(id);
                    if (olymp != null)
                    {
                        result = result.Append(mapper.Map<Olympiad, OlympiadDTO>(olymp));
                    }
                }
                else
                {
                    var olympiads = db.Olympiads.Where(x => x.Name.Contains(info.Search)     && x.IsActive == info.IsActive).ToList();
                    if (olympiads.Any())
                    {
                        result = mapper.Map<IEnumerable<Olympiad>, IEnumerable<OlympiadDTO>>(olympiads);
                    }
                }
            }
            
            return result;
        }
        public SaveOlympiadDTO GetOlympiad(int OlympiadId)
        {
            SaveOlympiadDTO result = null;
            if (db.Olympiads.Find(OlympiadId) is Olympiad olympiad)
            {
                var mapper = new MapperConfiguration(t => t.CreateMap<Olympiad, SaveOlympiadDTO>()
                                                           .ForMember(x => x.Subject, u => u.MapFrom(y => y.Subject.Name))
                                                           .ForMember(r => r.Category,n => n.MapFrom(e => e.Category.Name))).CreateMapper();
                result = mapper.Map<Olympiad, SaveOlympiadDTO>(olympiad);
            }

            return result;
        }
        public IValidationResult Save(SaveOlympiadDTO olympiad)
        {
            IValidationResult validationResult = new ValidResult();
            if (olympiad.Minutes > 60 * 5)
            {
                validationResult = new FailedResult("Время прохождения не может быть больше 5 часов","Minutes");
            }
            else
            {
                var subject = db.Subjects.FirstOrDefault(x => x.Name == olympiad.Subject);
                var category = db.Categories.FirstOrDefault(x => x.Name == olympiad.Category);

                Olympiad olymp = null;
                if (olympiad.Id > 0)
                {
                    olymp = db.Olympiads.Find(olympiad.Id);
                    
                }
                else
                {
                    olymp = new Olympiad
                    {
                        CreationTime = DateTime.Now
                    };
                    db.Olympiads.Add(olymp);
                }
                olymp.Minutes = olympiad.Minutes;
                olymp.Description = olympiad.Description;
                olymp.Name = olympiad.Name;
                olymp.Category = category;
                olymp.Subject = subject;
                olymp.Start = olympiad.Start;
                olymp.End = olympiad.End;
                olymp.IsActive = false;
                
                db.SaveChanges();
            }

            return validationResult;
            
        }
        public void Activate(int OlympiadId)
        {
            var olymp = db.Olympiads.Find(OlympiadId);
            if (olymp != null)
            {
                olymp.IsActive = true;
                db.SaveChanges();
            }
        }
        public void Deactivate(int OlympiadId)
        {
            var olymp = db.Olympiads.Find(OlympiadId);
            if (olymp != null)
            {
                olymp.IsActive = false;
                db.SaveChanges();
            }
        }
    }
}
