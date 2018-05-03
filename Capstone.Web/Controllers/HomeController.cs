﻿using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IAccountDAL acctDAL;
        private ILandmarkDAL landDAL;
        private IItineraryDAL itinDAL;

        public HomeController(IAccountDAL _acctDAL, ILandmarkDAL _landDAL, IItineraryDAL _itinDAL)
        {
            this.acctDAL = _acctDAL;
            this.landDAL = _landDAL;
            this.itinDAL = _itinDAL;
        }

        // GET: Home
        public ActionResult Home()
        {
            UserSession userSession = GetActiveUser();
            return View();
        }

        public ActionResult Index()
        {
            //Default session if User isn't logged in
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
            User user = acctDAL.AuthUser(email, password);

            Session["User.Session"] = new UserSession(user.Email, user.UserName, user.IsAdmin);
            UserSession userSession = GetActiveUser();
            return RedirectToAction("Index", "Itinerary");
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
            if (userSession.Email == "user@citytour.com")
            {
                try
                {
                    acctDAL.CreateUser(user);
                    Session["User.Session"] = new UserSession(user.Email, user.UserName, false);
                    userSession = GetActiveUser();
                    return RedirectToAction("Index", "Itinerary");
                }
                catch
                {
                    return RedirectToAction("Register", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Itinerary");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserProfile()
        {
            UserSession userSession = GetActiveUser();
            var user = acctDAL.GetUser(userSession.Email);
            return View(user);
        }

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