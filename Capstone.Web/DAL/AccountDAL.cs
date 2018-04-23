using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
  public class AccountDAL : IAccountDAL
  {
    private string connectionString;
    public AccountDAL(string connectionString)
    {
      connectionString = this.connectionString;
    }

    public bool CreateUser(User user)
    {
      throw new NotImplementedException();
    }

    public bool DeleteUser(string emailPK)
    {
      throw new NotImplementedException();
    }

    public User GetUser(string emailPK)
    {
      throw new NotImplementedException();
    }

    public bool UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
  }
}