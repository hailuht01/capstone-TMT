//using System;
//using Capstone.Web.DAL;
//using Capstone.Web.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Capstone.Web.Tests.DAL
//{
//    [TestClass]
//    public class PopulateMockDB
//    {
//        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=citytour;Integrated Security = True";
//        LandmarkDAL landmarkDAL = new LandmarkDAL(connectionString);
//        ItineraryDAL itineraryDAL = new ItineraryDAL(connectionString);
//        AccountDAL accountDAL = new AccountDAL(connectionString);


//        [TestMethod]
//        public void CreatLandmarks()
//        {
//            int lastIdCreated = 0;
//            int currentIdCreated = 0;

//            CreateItinerary
//            int mockItnId = itineraryDAL.CreateItinerary(new Itinerary()
//            {
//                Title = "Mock Itinerary",
//                CreationDate = DateTime.Now,
//                DepartureDate = DateTime.Now.AddDays(3),
//                Description = "This is a mock (admin) Itinerary!",
//                UserEmail = "admin@citytour.com"
//            });

//            Test Itinerary Creation
//            Assert.IsNotNull(mockItnId);

//            Create New Landmark
//            Test Create
//            Add Landmark To Itineary & Test
//            Repeat
//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("ChIJ7Qfv_ZqzQYgRSV2kwAcCB4s", "Cincinnati Zoo", "3400 Vine St, Cincinnati, OH 45220", " The second oldest Zoo in the United States. Wide variety of animal collection.The Zoo was founded on 65 acres in the middle of the city, and since then has acquired some of the surrounding blocks and several reserves in Cincinnati’s suburbs.", 39.144573, -84.508617, "Cincinnati-Zoo.jpg", false, "zoo"));
//            Assert.AreNotEqual(0, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;

//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("ChIJuZQ4_x20QYgR2QLQxS_400g", "Cincinnati Museum Center", "1301 Western Ave, Cincinnati, OH 45203", "Family Friendly Museum! This place its awesome! You are really going to love it.", 39.110019, -84.537781, "Cincinnati-Museum.jpg", true, "Museum"));
//            Assert.AreNotEqual(lastIdCreated, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;

//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("ChIJi77WfdCzQYgRGbJHVBDHy-g", "Krohn Conservatory", "1501 Eden Park Dr, Cincinnati, OH 45202", "Blooming Conservatory! Because plants are super cool! Don't miss out.", 39.115235, -84.489999, "Krohn-Conservatory.jpg", true, "Conservatory"));
//            Assert.AreNotEqual(lastIdCreated, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;

//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("ChIJT-TnLv6zQYgRElWrTagIgJ4", "Music Hall", "1241 Elm Street, Cincinnati, Ohio", " A classical music performance hall Don't miss out.", 39.109395, -84.519231, "Music-Hall.jpg", false, "Hall"));
//            Assert.AreNotEqual(lastIdCreated, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;

//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("ChIJfVEQdNSzQYgRGubreDvtpcY", "Fountain Square", " 520 Vine St, Cincinnati, OH 45202", "Fountain Square is the city square; features many shops, restaurants, hotels, and offices.", 39.101789, -84.512794, "Fountain-Square.jpg", true, "Attraction"));
//            Assert.AreNotEqual(lastIdCreated, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;

//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("ChIJj5FhLG-xQYgRNhr-7ontbKo", "Newport On the Levee", "1 Levee Way, Newport, KY 41071", "Newport on the Levee is a premier dining and attraction destination!", 39.094690, -84.496364, "Newport-On-the-Levee.jpg", true, "attraction"));
//            Assert.AreNotEqual(lastIdCreated, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;

//            currentIdCreated = landmarkDAL.CreateLandmark(new Landmark("EjxKb2huIEEuIFJvZWJsaW5nIFN1c3BlbnNpb24gQnJpZGdlLCBDb3Zpbmd0b24sIEtZIDQxMDExLCBVU0E", "John A. Roebling Suspension Bridge", "1501 Eden Park Dr, Cincinnati, OH 45202", "The John A. Roebling Suspension Bridge, originally known as the Cincinnati-Covington Bridge spans the Ohio River between Cincinnati, Ohio and Covington, Kentucky", 39.092993, -84.509864, "John A. Roebling Suspension Bridge.jpg", true, "Attraction"));
//            Assert.AreNotEqual(lastIdCreated, currentIdCreated);
//            Assert.IsTrue(itineraryDAL.AddLandmarkToItinerary(currentIdCreated, mockItnId));
//            lastIdCreated = currentIdCreated;
//        }
//    }
//}
