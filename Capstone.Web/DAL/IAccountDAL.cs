using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
<<<<<<< HEAD
  public interface IAccountDAL
  {
    User GetUser(string emailPK);
    bool CreateUser(User user);
    bool UpdateUser(User user);
    bool DeleteUser(string emailPK);
    //bool UpdateAdmin(string emailPK);
  }
}
=======
    public interface IAccountDAL
    {
        User GetUser(String emailPK);

        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string emailPK);
           

    }
}
>>>>>>> 66b84628da5348c135ab3982827bdd718d03057a
