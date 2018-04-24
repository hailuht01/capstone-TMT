using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    interface IItineraryDAL
    {
        bool SaveItinerary(Itinerary itinerary);
        Itinerary GetItenerary(int id);
        bool UpdateItinerary(Itinerary itinerary);
        bool DeleteItinerary(int id);

    }
}
