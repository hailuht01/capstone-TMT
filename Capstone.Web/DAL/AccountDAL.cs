using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
      //Insert into survey_result(parkCode, emailAddress, state, activityLevel) Values(@parkCode, @email, @state, @activity)";
      const string createUserQuery = "insert into user(Email, Username, FirstName, LastName, Password, isAdmin) Values(@Email, @Username, @FirstName, @)"; 

      using (SqlConnection conn = new SqlConnection())
      {
        conn.Open();
        var cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.FirstName);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
      }



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