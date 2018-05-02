using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class FullUserModel
    {
        public User User { get; set; }
        public List<Itinerary> Itineraries { get; set; }
    public List<Landmark> Landmarks { get; set; } = new List<Landmark>();

        public FullUserModel() { }
        public FullUserModel(User user, List<Itinerary> itineraries)
        {
            User = user;
            Itineraries = itineraries;
        }
    }
}