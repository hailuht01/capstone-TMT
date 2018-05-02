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
        IItineraryDAL itineraryDAL;
        ILandmarkDAL landmarkDAL;
        IAccountDAL accountDAL;

        public ItineraryController(IItineraryDAL dal, IAccountDAL _accountDAL, ILandmarkDAL _landmarkDAL)
        {
            this.itineraryDAL = dal;
            this.landmarkDAL = _landmarkDAL;
            this.accountDAL = _accountDAL;
        }


    // GET: Itinerary
    public ActionResult Index()
    {
      //Default session if User isn't logged in
      UserSession userSession = GetActiveUser();
      FullUserModel fullUser = new FullUserModel();

      if (userSession.Email != "user@citytour.com")
      {
        fullUser.User = accountDAL.GetUser(userSession.Email);
        fullUser.Itineraries = itineraryDAL.GetAllItineraries(userSession.Email);
        fullUser.Landmarks.AddRange(landmarkDAL.GetEveryLandmark());

        foreach (var itin in fullUser.Itineraries)
        {
          var itinLandmarks = landmarkDAL.GetAllLandmarks(itin.Id);

          // this needs to be all possible landmarks

          foreach (var land in itinLandmarks)
          {
            itin.LandmarkIds.Add(land.PlaceId);
          }
        }
      }
      else
      {
        fullUser.User = accountDAL.GetUser(userSession.Email);
        fullUser.Itineraries = Itinerary.GetSamples();
        fullUser.Landmarks = Landmark.GetSamples();
      }

      return View(fullUser);
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
            if(itineraryDAL.CreateItinerary(itin) > 0)
            {
                return RedirectToAction("Index", "Itinerary");
            }
            else
            {
                return RedirectToAction("Index", "Itinerary");
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

    // POST: Itinerary/Delete/5
    [HttpPost]
    public ActionResult Delete(int id)
    {
      var userSession = GetActiveUser();
      try
      {
        // TODO: Add delete logic here
        itineraryDAL.DeleteItinerary(id);
        return RedirectToAction("Index", "Itinerary");
      }
      catch
      {
        return View("Index", "Itinerary");
      }
    }
  }
}
