using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Itinerary
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; } // private set?
        public DateTime? DepartureDate { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }

        //public int Route { get; set; }

        public static List<Itinerary> GetSamples()
        {
            return new List<Itinerary>()
            {
                new Itinerary("Sample Itinerary", DateTime.Now.AddDays(1), "This is a test description", "Jake@CityTour.io")
            };
        }

        public Itinerary() { }

        public Itinerary(string Title, DateTime? DepartureDate, string description, string userEmail)
        {
            this.Title = Title;
            this.DepartureDate = DepartureDate;
            this.CreationDate = DateTime.Now;
            this.Description = description;
            this.UserEmail = userEmail;

        }
    }
}