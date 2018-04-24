using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
  public class AccountController : BaseController
  {
    IAccountDAL accountDAL;
    public AccountController(IAccountDAL _accountDAL)
    {
      this.accountDAL = _accountDAL;
    }

    public ActionResult Index()
    {
      accountDAL.GetUser("userrrrr@citytour.com", "Password");
      return View();
    }

    public ActionResult Login(string email, string password)
    {
      accountDAL.GetUser(email, password);
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