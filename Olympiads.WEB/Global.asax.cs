using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure;
using Olympiads.BLL.Interfaces;
using Olympiads.BLL.Services;
using Olympiads.WEB.App_Start;
using Olympiads.WEB.Roles;
using Olympiads.WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Olympiads.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IKernel kernel = new StandardKernel(new NinjectRegistrations());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
