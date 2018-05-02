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
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=citytour;Integrated Security = True";
        ItineraryDAL testItnDAL = new ItineraryDAL(connectionString);
        private TransactionScope tran;
        int lastIdCreated = 0;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            Itinerary newItin = new Itinerary()
            {
                Title = "Test",
                CreationDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(1),
                Description = "This is a test, only a test.",
                UserEmail = "Admin@CityTour.com"
            };

            lastIdCreated = testItnDAL.CreateItinerary(newItin);

        }

        [TestMethod]
        public void CreateItineraryTest()
        {
            Assert.AreNotEqual(0, lastIdCreated);
        }

        [TestMethod]
        public void GetItineraryTest()
        {
            Itinerary myItn = testItnDAL.GetItinerary(lastIdCreated);
            int? id = myItn.Id;
            string title = myItn.Title;
            DateTime createDate = myItn.CreationDate.Date;
            bool hasDepartureDate = myItn.DepartureDate.HasValue;

            Assert.AreEqual(lastIdCreated, id, "Input: Dynamic");
            Assert.AreEqual("Test", title);
            Assert.AreEqual(DateTime.Now.Date, createDate);
            Assert.AreEqual(true, hasDepartureDate);
        }

        [TestMethod]

        public void UpdateItineraryTest()
        {
            //Get Itininerary From DB
            Itinerary myItn = testItnDAL.GetItinerary(lastIdCreated);
            //Set new Info
            myItn.Title = "New Test Title";
            myItn.Description = "New Description";
            //Update Itn in DB
            bool wasSuccesful = testItnDAL.UpdateItinerary(myItn);
            //Get Itinerary Again to test
            myItn = testItnDAL.GetItinerary(lastIdCreated);

            Assert.AreEqual(true, wasSuccesful);
            Assert.AreEqual("New Test Title", myItn.Title);
            Assert.AreEqual("New Description", myItn.Description);

        }

        [TestMethod]
        public void AddLandmarkToItineraryTest()
        {
            Landmark landmark = new Landmark("ChIJ7Qfv_ZqzQYgRSV2kwAcCB4s",
                "Cincinnati Zoo", "3400 Vine St, Cincinnati, OH 45220",
                "The second oldest Zoo in the United States. Wide variety of animal collection. " +
                "The Zoo was founded on 65 acres in the middle of the city, and since then has acquired " +
                "some of the surrounding blocks and several reserves in Cincinnati’s suburbs.",
                39.144573, -84.508617, true, "Zoo");

        }

        [TestMethod]
        public void DeleteLandmarkFromItinerary()
        {

        }

        [TestMethod]
        public void DeleteItineraryTest()
        {
            //Execute Command
            bool wasSuccessful = testItnDAL.DeleteItinerary(lastIdCreated);
            Itinerary myItn = testItnDAL.GetItinerary(lastIdCreated);

            //Test
            Assert.IsTrue(wasSuccessful);
            Assert.IsNull(myItn);
        }
        
        [TestCleanup]
        public void CleanUp()
        {
            tran.Dispose();
        }
    }
}
