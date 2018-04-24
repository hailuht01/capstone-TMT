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
      this.connectionString = connectionString;
    }

    public bool CreateUser(RegistrationForm user)
    {
      const string createUserQuery = "insert into " +
        "users(Email, Username, FirstName, LastName, Password) " +
        "Values(@Email, @Username, @FirstName,@LastName, @Password)";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(createUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@Username", user.UserName);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.FirstName);
        cmd.Parameters.AddWithValue("@Password", user.Password);

        isSuccess = (cmd.ExecuteNonQuery() > 0);
      }

      return isSuccess;
    }

    public bool DeleteUser(string emailPK)
    {
      const string deleteUserQuery = "delete * where Email = @Email";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(deleteUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", emailPK);

        isSuccess = (cmd.ExecuteNonQuery() > 0);
      }

      return isSuccess;
    }

    public User GetUser(string emailPK)
    {
      var user = new User();
      const string getUserQuery = "select * where Email = @Email";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(getUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", emailPK);

        isSuccess = (cmd.ExecuteNonQuery() > 0);
      }
      return user;
    }

    public bool UpdateUser(User user)
    {
      const string updateUserQuery = @"update users 
                                      set UserName = @UserName 
                                      set FirstName = @FirstName
                                      set LastName = @LastName
                                      set Password = @Password
                                      where Email = @Email)";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(updateUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@Username", user.UserName);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.FirstName);
        cmd.Parameters.AddWithValue("@Password", user.Password);

        isSuccess = (cmd.ExecuteNonQuery() > 0);
      }

      return isSuccess;
    }
  }
}