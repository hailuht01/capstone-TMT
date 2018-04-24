using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public DateTime Time { get; set; } // private set? 
        public IList<Landmark> Landmark { get; set; } = new List<Landmark>();
        //public int Route { get; set; }
    }
}