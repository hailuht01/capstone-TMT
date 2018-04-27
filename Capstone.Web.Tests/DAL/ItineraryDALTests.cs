using System;
using System.Transactions;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class ItineraryDALTests
    {
        IItineraryDAL itinDAL;
        private TransactionScope tran;
        int rowsAffected = 0;

        [TestInitialize]
        public void Initialize(IItineraryDAL _itinDAL)
        {
            itinDAL = _itinDAL;

            Itinerary newItin = new Itinerary()
            {
                Title = "Test",
                User_Email = "Test@CityTour.com",
                CreationDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(1),
                Description = "This is a test, only a test."

            };
            itinDAL.CreateItinerary(newItin);

        }

        [TestMethod]
        public void CreateItinerary()
        {
        }

        [TestCleanup]
        public void CleanUp()
        {
            tran.Dispose();
        }
    }
}
