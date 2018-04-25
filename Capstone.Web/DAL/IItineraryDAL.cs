using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IItineraryDAL
    {
        bool SaveItinerary(Itinerary itinerary);
        Itinerary GetItinerary(int id);
        List<Itinerary> GetAllItineraries(string userEmail);
        bool UpdateItinerary(Itinerary itinerary);
        bool DeleteItinerary(int id);
    }
}
