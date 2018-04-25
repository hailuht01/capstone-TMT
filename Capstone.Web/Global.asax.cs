using Capstone.Web.DAL;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capstone.Web
{
  public class MvcApplication : NinjectHttpApplication
    {
    protected override void OnApplicationStarted()
    {
      base.OnApplicationStarted();

      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }

    // Configure the dependency injection container.
    protected override IKernel CreateKernel()
    {
        var kernel = new StandardKernel();

        string connectionString = ConfigurationManager.ConnectionStrings["citytour"].ConnectionString;

      // Set up the bindings
        kernel.Bind<IAccountDAL>().To<AccountDAL>().WithConstructorArgument("connectionString", connectionString);
        kernel.Bind<IItineraryDAL>().To<ItineraryDAL>().WithConstructorArgument("connectionString", connectionString);
        kernel.Bind<ILandmarkDAL>().To<LandmarkDAL>().WithConstructorArgument("connectionString", connectionString);

        return kernel;
    }
  }
}
