using System;
using System.Collections.Generic;
using System.Transactions;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class LandmarkDALTests
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=citytour;Integrated Security = True";
        LandmarkDAL testLandmarkDAL = new LandmarkDAL(connectionString);
        private TransactionScope tran;
        int lastIdCreated = 0;
        string testPlaceId = "00001";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            Landmark testLandmark = new Landmark()
            {
                PlaceId = testPlaceId,
                Name = "Cincinnati Zoo",
                Address = "3400 Vine St, Cincinnati, OH 45220",
                Description = "The second oldest Zoo in the United States. Wide variety of animal collection.The Zoo was founded on 65 acres in the middle of the city, and since then has acquired some of the surrounding blocks and several reserves in Cincinnati’s suburbs.",
                Latitude = 39.144573,
                Longitude = -84.508617,
                Type = "Attraction",
                ThumbsUp = true
            };
            lastIdCreated = testLandmarkDAL.CreateLandmark(testLandmark);
        }

        [TestMethod]
        public void CreateLandmarkTest()
        {
            Assert.AreNotEqual(0, lastIdCreated);
        }

        [TestMethod]
        public void GetLandmarkTest()
        {
            Landmark landmark = testLandmarkDAL.GetLandmark(lastIdCreated);
            string placeId = landmark.PlaceId;
            bool? thumbsUp = landmark.ThumbsUp;
            double lat = landmark.Latitude;

            Assert.AreEqual("00001", placeId);
        }

        [TestMethod]
        public void UpdateLandmarkTest()
        {
            Landmark landmark = testLandmarkDAL.GetLandmark(lastIdCreated);
            landmark.Name = "Niagra Falls";
            bool wasSuccessful = testLandmarkDAL.UpdateLandmark(landmark);
            string name = testLandmarkDAL.GetLandmark(lastIdCreated).Name;

            Assert.IsTrue(wasSuccessful);
            Assert.AreEqual("Niagra Falls", name);
        }

        [TestMethod]
        public void DeleteLandmarkTest()
        {
            bool wasSuccessful = testLandmarkDAL.DeleteLandmark(testPlaceId);
            Landmark landmark = testLandmarkDAL.GetLandmark(testPlaceId);

            Assert.IsNull(landmark);
            Assert.IsTrue(wasSuccessful);
        }

        /// <summary>
        /// Checks GetAllLandmarks() as well as AddLandmarksToItinerary()
        /// </summary>
        ///
        [TestMethod]
        public void GetAllLandmarks()
        {
            //Create itinerary & Save To DB
            int itnID = new ItineraryDAL(connectionString).CreateItinerary(new Itinerary("Sample Itinerary", DateTime.Now.AddDays(1), "This is a test description", "Admin@CityTour.com"));
            //Create Landmarks
            Landmark fSquare = new Landmark("00002", "Fountain Square", " 520 Vine St, Cincinnati, OH 45202", "Fountain Square is the city square; features many shops, restaurants, hotels, and offices.", 39.101789, -84.512794, true, "Attraction");
            Landmark newport = new Landmark("00003", "Newport On the Levee", "1 Levee Way, Newport, KY 41071", "Newport on the Levee is a premier dining and attraction destination!", 39.094690, -84.496364, true, "Attraction");
            //Add Landmarks to DB
            int fSquareId = testLandmarkDAL.CreateLandmark(fSquare);
            int newportID = testLandmarkDAL.CreateLandmark(newport);
            //Add Landmark to Itinerary
            bool wasSuccesful =  new ItineraryDAL(connectionString).AddLandmarkToItinerary(fSquareId, itnID);
            //Test
            Assert.IsTrue(wasSuccesful);
            //Add 2nd Landmark 
            wasSuccesful = new ItineraryDAL(connectionString).AddLandmarkToItinerary(newportID, itnID);
            //Test
            Assert.IsTrue(wasSuccesful);
            //Get All Landmarks for an Itinerary
            List<Landmark> landmarks = testLandmarkDAL.GetAllLandmarks(itnID);

            //Should contain 2 Landmarks
            Assert.AreEqual(2, landmarks.Count);
        }

        [TestMethod]
        public void RemoveLandmarkFromItnTest()
        {
            //Create itinerary & Save To DB
            int itnID = new ItineraryDAL(connectionString).CreateItinerary(new Itinerary("Sample Itinerary", DateTime.Now.AddDays(1), "This is a test description", "Admin@CityTour.com"));
            //Create Landmarks
            Landmark fSquare = new Landmark("00002", "Fountain Square", " 520 Vine St, Cincinnati, OH 45202", "Fountain Square is the city square; features many shops, restaurants, hotels, and offices.", 39.101789, -84.512794, true, "Attraction");
            //Add Landmarks to DB
            int fSquareId = testLandmarkDAL.CreateLandmark(fSquare);
            //Add Landmark to Itinerary
            new ItineraryDAL(connectionString).AddLandmarkToItinerary(fSquareId, itnID);
            bool wasSuccessful = new ItineraryDAL(connectionString).RemoveLandmarkFromItinerary(fSquareId, itnID);

            //Test
            Assert.IsTrue(wasSuccessful);
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }
    }
}
