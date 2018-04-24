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
        bool CreatItinerary();
        Itinerary GetItenerary();
        bool UpdateItinerary();
        bool DeleteItinerary();

    }
}
