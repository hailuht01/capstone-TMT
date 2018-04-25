using Capstone.Web.DAL;
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
        public ActionResult Index()
        {
            UserSession userSession = GetActiveUser();

            if (userSession == null)
            {
                UserSession tempSession = new UserSession()
                {
                    User = acctDAL.GetUser("admin", "Password"),
                    Itinerary = Itinerary.GetSample()
                };
                return View(tempSession);
            }
            return View(userSession);
        }
    }
}