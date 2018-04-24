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
      var user = accountDAL.GetUser("admin@citytour.com");
      //user.LastName = "JakeIsCool";
      //accountDAL.UpdateUser(user);
      user.Email = "jake@jake.io";
      user.FirstName = "jake";
      user.LastName = "n";
      user.UserName = "jakeeee";
      user.Password = "lulpass";

      accountDAL.CreateUser(user);

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
      accountDAL.CreateUser(user);
      return RedirectToAction(Request.UrlReferrer.ToString());
    }
  }
}