using Capstone.Web.DAL;
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
        /// <summary>
        /// Return User Session Data
        /// </summary>
        /// <returns></returns>
        protected UserSession GetActiveUser()
        {
            UserSession userSession = Session["User.Session"] as UserSession;

            if (userSession == null)
            {
                userSession = new UserSession()
                {
                    Email = "user@citytour.com",
                    isAdmin = false,
                    UserName = "Anonymous"
                };
            }
            return userSession;
        }
    }
}