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

        public ActionResult Index()
        {
            UserSession session = GetActiveUser();
            List<Itinerary> itineraries = new List<Itinerary>();
            if (session.UserName.ToLower() == "anonymous")
            {
                return View(itineraries);
            }
            itineraries = itineraryDAL.GetAllItineraries(session.Email);
            return View(itineraries);
        }

        int? tempId = null;

        // GET: Itinerary
        public ActionResult Detail()
        {
            //Default session if User isn't logged in
            UserSession userSession = GetActiveUser();
            if (userSession.UserName == "Anonymous")
            {
                return RedirectToAction("Login", "Home");
            }
            ItineraryLandmarks model;
            

            if (TempData["Temp.ItnId"] == null)
            {
                tempId = itineraryDAL.CreateItinerary(new Itinerary("Untitled", DateTime.Now.AddDays(1), "Enter Description", userSession.Email));
                TempData["Temp.ItnId"] = tempId;
                model = new ItineraryLandmarks()
                {
                    
                    Landmarks = landmarkDAL.GetAllLandmarks(),
                    ItnLandmarks = landmarkDAL.GetAllLandmarks(tempId.Value),
                    Itinerary = itineraryDAL.GetItinerary(tempId.Value)
                };
            }
            else
            {
                model = new ItineraryLandmarks()
                {
                    Landmarks = landmarkDAL.GetAllLandmarks(),
                    Itinerary = itineraryDAL.GetItinerary(Convert.ToInt32(TempData["Temp.ItnId"])),
                    ItnLandmarks = landmarkDAL.GetAllLandmarks(Convert.ToInt32(TempData["Temp.ItnId"]))
                };
                tempId = model.Itinerary.Id;
                TempData["Temp.ItnId"] = tempId;
            }

            return View(model);
        }

        public ActionResult Detail2(int id)
        {
            ItineraryLandmarks model = null;
            //Default session if User isn't logged in
            UserSession userSession = GetActiveUser();
            if (userSession.UserName == "Anonymous")
            {
                return RedirectToAction("Login", "Home");
            }
            Itinerary itinerary = itineraryDAL.GetItinerary(id);
            if (itinerary == null)
            {
                SetAlertMessage("Could't retrieve itinerary. Try again soon.", AlertType.Danger, AlertDisplay.Block);
                return View("Index");
            }
            else
            {
                model = new ItineraryLandmarks()
                {
                    Landmarks = landmarkDAL.GetAllLandmarks(),
                    Itinerary = itinerary,
                    ItnLandmarks = landmarkDAL.GetAllLandmarks(id)
                };
                tempId = id;
                TempData["Temp.ItnId"] = id;
            }

            return View(model);
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
            UserSession userSession = GetActiveUser();
            itin.UserEmail = userSession.Email;
            if (itineraryDAL.CreateItinerary(itin) > 0)
            {
                return RedirectToAction("Index", "Itinerary");
            }
            else
            {
                return RedirectToAction("Index", "Itinerary");
            }
        }

        // GET: Itinerary/Edit/5
        [HttpPost]
        public ActionResult Update(Itinerary itn)
        {
            if (itineraryDAL.UpdateItinerary(itn))
            {
                SetAlertMessage("Itinerary Updated.", AlertType.Success, AlertDisplay.Block);
            }
            else
            {
                SetAlertMessage("There was an error updating the itinerary. Please try agin.", AlertType.Danger, AlertDisplay.Block);
            }

            TempData["Temp.ItnId"] = itn.Id;
            var model = new ItineraryLandmarks()
            {
                Landmarks = landmarkDAL.GetAllLandmarks(),
                ItnLandmarks = landmarkDAL.GetAllLandmarks(itn.Id.Value),
                Itinerary = itineraryDAL.GetItinerary(itn.Id.Value)
            };
            return RedirectToAction("Index", model);
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

        [HttpPost]
        public ActionResult AddLandmarkToItinerary(int landmarkId, int itnId)
        {
            if (itineraryDAL.AddLandmarkToItinerary(landmarkId, itnId))
            {
                SetAlertMessage("Landmark Added!.", AlertType.Success, AlertDisplay.Block);
            }
            else
            {
                SetAlertMessage("Wasn't able to add landmark. Try agin.", AlertType.Danger, AlertDisplay.Block);
            }

            var model = new ItineraryLandmarks()
            {
                Landmarks = landmarkDAL.GetAllLandmarks(),
                ItnLandmarks = landmarkDAL.GetAllLandmarks(Convert.ToInt32(TempData["Temp.ItnId"])),
                Itinerary = itineraryDAL.GetItinerary(itnId)
            };
            return RedirectToAction("Detail", "Itinerary", model);
        }
    }
}
