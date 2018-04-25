using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class LandmarkController : Controller
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
    }
}
