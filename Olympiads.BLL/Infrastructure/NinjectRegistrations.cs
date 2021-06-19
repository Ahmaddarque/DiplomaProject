using Ninject.Modules;
using Olympiads.BLL.Interfaces;
using Olympiads.BLL.Services;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IParticipantService>().To<ParticipantService>();
            Bind<IVisiterService>().To<VisiterService>();
            Bind<ICryptoService>().To<PBKDF2>();;
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ISubjectService>().To<SubjectsService>();
            Bind<ITestService>().To<TestService>();
            Bind<IAdminService>().To<AdminService>();
            Bind<IStatsService>().To<StatsService>();
            Bind<ICRUDParticipantService>().To<CRUDParticipantService>();
            Bind<ICRUDTestService>().To<CRUDTestService>();
            Bind<ICRUDOlympiadService>().To<CRUDOlympiadService>();
            Bind<ITaskService>().To<TaskService>();
        }
    }
}
