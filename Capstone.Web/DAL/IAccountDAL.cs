using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
<<<<<<< HEAD

    public interface IAccountDAL
    {
        User GetUser(String emailPK);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string emailPK);
           

    }
}
=======
    public interface IAccountDAL
    {
        bool CreateUser(User user);
        bool DeleteUser(string emailPK);
        User GetUser(string emailPK);
        bool UpdateUser(User user);

    }
}
>>>>>>> 8a969eba3e6b97cb8b494017ca51a1c61e02f828
