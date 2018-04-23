using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            return View();
        }
    }
}