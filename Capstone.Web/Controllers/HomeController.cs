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
            //Default session if User isn't logged in
            UserSession userSession = GetActiveUser();
            FullUserModel fullUser = new FullUserModel();

            if (userSession.Email == "user@citytour.com")
            {
                fullUser.User = acctDAL.GetUser(userSession.Email, "Password");
                fullUser.Itineraries = Itinerary.GetSamples();
            }
            else
            {
                fullUser.User = acctDAL.GetUser(userSession.Email, "Password");
                fullUser.Itineraries = itinDAL.GetAllItineraries(userSession.Email);
            }
            
            return View(fullUser);
        }
    }
}