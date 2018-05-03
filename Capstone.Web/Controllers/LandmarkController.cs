using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ActionResult Create(Landmark landmark)
        {
            List<Landmark> landmarks = null;
            try
            {

                if ( !(landmarkDAL.CreateLandmark(landmark) > 0) )
                {
                    //Set Error MEssage
                    landmarks = landmarkDAL.GetAllLandmarks();
                }
                return RedirectToAction("Create", landmarks);
            }
            catch(SqlException)
            {
                return View("Update", landmark);
            }
            catch
            {
                landmarks = landmarkDAL.GetAllLandmarks();
                return View("Create", landmarks);
            }
        }

        public ActionResult PopularLandmarks()
        {
            UserSession session = GetActiveUser();
            List<Landmark> landmarks = landmarkDAL.GetPopularLandmarks();
 

            return View(landmarks);
        }

        public ActionResult LandmarkDetail(string PlaceId)
        {
            if (PlaceId == null)
            {
                return View("Index", "Home");
            }
            UserSession session = GetActiveUser();
            Landmark landmark = landmarkDAL.GetLandmark(PlaceId);

            return View(landmark);
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            List<Landmark> landmarks = landmarkDAL.GetAllLandmarks();
            try
            {
                if (!landmarkDAL.DeleteLandmark(Id))
                {
                    //Set Failure Notificaton
                    Console.WriteLine("Failure");
                    return View("Create", landmarks);
                }

                //Get Fresh landmarks
                landmarks = landmarkDAL.GetAllLandmarks();
                Console.WriteLine("Success");
            }
            catch (Exception)
            {
                //Set Error Message
            }
            return View("Create", landmarks);
        }

        [HttpPost]
        public ActionResult Update(Landmark landmark)
        {
            try
            {
                landmarkDAL.UpdateLandmark(landmark);
            }
            catch (Exception e)
            {
                //Set Error Message
                Console.WriteLine("Landmark wasn't updated" + e.Message);
            }
            return RedirectToAction("Create", "Landmark");
        }
    }
}
