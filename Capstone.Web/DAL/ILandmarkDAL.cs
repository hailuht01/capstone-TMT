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
        int CreateLandmark(Landmark landmark);
        Landmark GetLandmark(int id);
        Landmark GetLandmark(string Placeid);
        List<Landmark> GetAllLandmarks();
        List<Landmark> GetAllLandmarks(int itinId);
        List<Landmark> GetPopularLandmarks();
        bool UpdateLandmark(Landmark landmark);
        bool DeleteLandmark(string id);
        List<Landmark> GetEveryLandmark();
        List<Landmark> SearchLandmarkType(string searchTerm);
    }
}
