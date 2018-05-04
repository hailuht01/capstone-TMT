using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ItineraryLandmarks
    {
        public Itinerary Itinerary { get; set; }
        public List<Landmark> Landmarks { get; set; }
        public List<Landmark> ItnLandmarks { get; set; }
    }
}