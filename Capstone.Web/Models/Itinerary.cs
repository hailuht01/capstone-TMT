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
                new Itinerary(1,"Sample Itinerary", DateTime.Now.AddDays(1), 4.4, "This is a test description", "user@CityTour.io"),
                new Itinerary(2,"Sample Number two", DateTime.Now.AddDays(1), 4.1, "This is my favorite itinerary", "user@CityTour.io")
            };
        }

        public Itinerary() { }

        public Itinerary(int id, string Title, DateTime? DepartureDate, double Rating, string description, string userEmail)
        {
      this.Id = id;
            this.Title = Title;
            this.DepartureDate = DepartureDate;
            this.CreationDate = DateTime.Now;
            this.Description = description;
            this.UserEmail = userEmail;

        }
    }
}