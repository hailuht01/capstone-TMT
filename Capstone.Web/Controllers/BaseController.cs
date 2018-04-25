using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UserSession GetActiveUser()
        {
            UserSession session = null;

            if (Session["session"] != null)
            {
                session = Session["User"] as UserSession;
            }
            return session;
        }
    }
}