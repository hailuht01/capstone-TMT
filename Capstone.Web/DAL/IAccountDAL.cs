using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
  public interface IAccountDAL
  {
    User GetUser(string emailPK);
    bool CreateUser(User user);
    bool UpdateUser(User user);
    bool DeleteUser(string emailPK);
    //bool UpdateAdmin(string emailPK);
  }
}