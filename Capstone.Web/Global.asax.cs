﻿using Ninject;
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
    public class MvcApplication : Ninject.Web.Common.NinjectHttpApplication
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

            string connectionString = ConfigurationManager.ConnectionStrings["SSGEEK"].ConnectionString;


            // Set up the bindings
            //kernel.Bind<IForumPostDAL>().To<ForumPostSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            //kernel.Bind<IProductDAL>().To<ProductSqlDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}