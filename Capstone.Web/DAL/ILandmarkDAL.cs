using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ILandmarkDAL
    {
        bool AddLandmark(Landmark landmark);
        Landmark GetLandmark(string id);
        List<Landmark> GetAllLandmark(string itinId);
        bool UpdateLandmark(Landmark landmark);
        bool DeleteLandmark(string id);
    }
}
