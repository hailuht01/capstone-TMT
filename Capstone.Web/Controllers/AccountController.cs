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
      UserSession userSession = GetActiveUser();
      return View();
    }

    public ActionResult Login()
    {
      UserSession userSession = GetActiveUser();
      return View();
    }

    [HttpPost]
    public ActionResult Login(string email, string password)
    {
      User user = accountDAL.AuthUser(email, password);

      Session["User.Session"] = new UserSession(user.Email, user.UserName, user.IsAdmin);
      UserSession userSession = GetActiveUser();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult UserProfile()
    {
      UserSession userSession = GetActiveUser();
      var user = accountDAL.GetUser(userSession.Email);
      return View(user);
    }

    public ActionResult Register()
    {
      UserSession userSession = GetActiveUser();

      return View();
    }

    [HttpPost]
    public ActionResult Register(RegistrationForm user)
    {
      UserSession userSession = GetActiveUser();
      accountDAL.CreateUser(user);
      return RedirectToAction("Index", "Home");
    }

    //private void UserSessionTransfer()
    //{
    //  UserSession userSession = GetActiveUser();
    //  ViewBag.Username = userSession.UserName;
    //  ViewBag.IsAdmin = userSession.isAdmin;
    //}

    //private UserSession UserSessionTransferReturn()
    //{
    //  UserSession userSession = GetActiveUser();
    //  ViewBag.Username = userSession.UserName;
    //  ViewBag.IsAdmin = userSession.isAdmin;
    //  return userSession;
    //}
  }
}