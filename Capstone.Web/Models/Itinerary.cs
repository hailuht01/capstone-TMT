using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } // private set?
        public DateTime DepartureDate { get; set; }
        public int Rating { get; set; }
        public string User_Email { get; set; }
        public string UserName { get; set; }
        public IList<Landmark> Landmarks { get; set; } = new List<Landmark>();
        //public int Route { get; set; }
    }
}