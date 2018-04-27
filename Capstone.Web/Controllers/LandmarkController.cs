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
        private ILandmarkDAL _dal;
        public LandmarkController(ILandmarkDAL landmarkDAL)
        {

            _dal = landmarkDAL;
        }

        public ActionResult Index()
        {
            //Landmark Landmark = _dal.GetLandmark();
            List<Landmark> landmark = Landmark.GetSamples();

            return View(landmark[0]);
        }
        //GET: Landmarks
        //public ActionResult GetAllLandmarks(ILandmarkDAL landmarkDAL)
        //{

        //    return PartialView();
        //}

        // GET: Itinerary/Create
        public ActionResult Create()
        {
            UserSession session = GetActiveUser();
            return View();
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
    }
}
