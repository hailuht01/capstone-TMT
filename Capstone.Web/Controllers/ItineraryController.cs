using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ItineraryController : BaseController
    {
        IItineraryDAL itinDAL;
        ILandmarkDAL landmarkDAL;
        IAccountDAL acctDAL;

        public ItineraryController(IItineraryDAL dal, IAccountDAL _accountDAL, ILandmarkDAL _landmarkDAL)
        {
            this.itinDAL = dal;
            this.landmarkDAL = _landmarkDAL;
            this.acctDAL = _accountDAL;
        }


        // GET: Itinerary
        public ActionResult Index()
        { 
            return View();
        }

        // GET: Itinerary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Itinerary/Create
        public ActionResult Create()
        {
            UserSession userSession = GetActiveUser();
            return View();
        }

        // POST: Itinerary/Create
        [HttpPost]
        public ActionResult Create(Itinerary itin)
        {
            itin.CreationDate = DateTime.Now;
            UserSession userSession = GetActiveUser();
            itin.UserEmail = userSession.Email; 
            if(itinDAL.CreateItinerary(itin) > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(Request.UrlReferrer.ToString());
            }
        }

        // GET: Itinerary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Itinerary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Itinerary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Itinerary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult MyItineraries()
        {
            //Default session if User isn't logged in
            UserSession userSession = GetActiveUser();
            FullUserModel fullUser = new FullUserModel();

            if (userSession.Email != "user@citytour.com")
            {
                fullUser.User = acctDAL.GetUser(userSession.Email);
                fullUser.Itineraries = itinDAL.GetAllItineraries(userSession.Email);
                fullUser.Landmarks = Landmark.GetSamples();

            }
            else
            {
                fullUser.User = acctDAL.GetUser(userSession.Email);
                fullUser.Itineraries = Itinerary.GetSamples();
                fullUser.Landmarks = Landmark.GetSamples();
            }

            return View(fullUser);
        }
    }
}
