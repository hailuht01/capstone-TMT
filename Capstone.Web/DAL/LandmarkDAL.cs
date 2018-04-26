using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class LandmarkDAL : ILandmarkDAL
    {
        private string connectionString;

        public LandmarkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

       
        public bool CreatLandmark()
        {
            //bool IsAdmin = true;
            //if (IsAdmin)
            throw new NotImplementedException();
        }

        public bool DeleteLandmark()
        {
            throw new NotImplementedException();
        }

        public Landmark GetLandmark()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLandmark()
        {
            throw new NotImplementedException();
        }
    }
}