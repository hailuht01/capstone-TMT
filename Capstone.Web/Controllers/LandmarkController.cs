using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class LandmarkController : BaseController
    {
        private ILandmarkDAL landmarkDAL;
        public LandmarkController(ILandmarkDAL _landmarkDAL)
        {

            this.landmarkDAL = _landmarkDAL;
        }

        public ActionResult Index()
        {
            //Landmark Landmark = _dal.GetLandmark();
            List<Landmark> landmark = Landmark.GetSamples();

            return View(landmark[0]);
        }

        // GET: Itinerary/Create
        public ActionResult Create()
        {
            UserSession session = GetActiveUser();
            List<Landmark> landmarks = landmarkDAL.GetAllLandmarks();
            return View(landmarks);
        }

        // POST: Itinerary/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PopularLandmarks()
        {
            UserSession session = GetActiveUser();
            List<Landmark> landmarks = landmarkDAL.GetPopularLandmarks();

            return View(landmarks);
        }

        [HttpPost]
        public ActionResult LandmarkDetail(int Id)
        {
            UserSession session = GetActiveUser();
            Landmark landmark = landmarkDAL.GetLandmark(Id);

            return View(landmark);
        }
    }
}
