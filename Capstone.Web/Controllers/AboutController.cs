using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
   

    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult About()
        {
            GetActiveUser();
            return View();
        }

        public ActionResult Contact()
        {
            GetActiveUser();
            return View();
        }
    }
}