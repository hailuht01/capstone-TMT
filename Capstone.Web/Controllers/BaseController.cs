using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string GetActiveSession()
        {
            string user = null;

            if (Session["User"] != null)
            {
                user = Session["User"] as string;
            }
            return user;
    }
}