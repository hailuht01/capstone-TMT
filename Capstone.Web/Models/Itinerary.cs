using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Time { get; set; } // private set? 
        public IList<Landmarks> Landmark { get; set; } = new List<Landmarks>();
        //public int Route { get; set; }
    }
}