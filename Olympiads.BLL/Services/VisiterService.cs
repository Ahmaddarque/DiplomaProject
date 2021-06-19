using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class VisiterService : IVisiterService
    {
        public VisiterDTO GetVisiter(string ip)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<Visiter, VisiterDTO>()).CreateMapper();
                var visiter = context.Visiters.FirstOrDefault(x => x.IP == ip);
                return mapper.Map<Visiter, VisiterDTO>(visiter);
            }
        }
        public void Register(string ip)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var visiter = context.Visiters.FirstOrDefault(x => x.IP == ip);
                
                if (visiter == null)
                {
                    var newVisiter = new Visiter() { IP = ip };
                    context.Visiters.Add(newVisiter);
                    context.SaveChanges();
                    context.Visits.Add(new Visit() { VisiterId = newVisiter.Id,VisitTime = DateTime.Now});
                    context.SaveChanges();
                }
                else
                {
                    var visit = context.Visits.FirstOrDefault(x => x.Visiter.IP == visiter.IP && DbFunctions.DiffDays(x.VisitTime, DateTime.Today) < 1);
                    if (visit == null)
                    {
                        context.Visits.Add(new Visit() { VisiterId = visiter.Id, VisitTime = DateTime.Now });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
