using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class UserSession
    {
        public User User { get; set; }
        public Itinerary Itinerary { get; set; }
    }
}