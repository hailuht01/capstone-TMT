using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class LandmarksController : Controller
    {
        // GET: Landmarks
        public ActionResult GetLandmarksAction()
        {
            return PartialView();
        }
    }
}