using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    interface ILandmarkDAL
    {
        bool CreatLandmark();
        Landmark GetLandmark();
        bool UpdateLandmark();
        bool DeleteLandmark();
    }
}
