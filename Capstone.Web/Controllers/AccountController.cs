using Capstone.Web.DAL;
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
        IAccountDAL accountDAL;
        public AccountController(IAccountDAL _accountDAL)
        {
            this.accountDAL = _accountDAL;
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login(string email, string password)
        {
      accountDAL.GetUser("jake@neels.io", "Password1");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationForm user)
        {
            accountDAL.CreateUser(user);
            return RedirectToAction(Request.UrlReferrer.ToString());
        }
    }
}