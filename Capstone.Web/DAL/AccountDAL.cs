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

    public bool CreateUser(User user)
    {
      const string createUserQuery = "insert into " +
        "users(Email, Username, FirstName, LastName, Password, isAdmin) " +
        "Values(@Email, @Username, @FirstName,@LastName, @Password, @isAdmin)";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        try
        {
          conn.Open();
          var cmd = new SqlCommand(createUserQuery, conn);
          cmd.Parameters.AddWithValue("@Email", user.Email);
          cmd.Parameters.AddWithValue("@Username", user.UserName);
          cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
          cmd.Parameters.AddWithValue("@LastName", user.LastName);
          cmd.Parameters.AddWithValue("@Password", user.Password);
          cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

          isSuccess = (cmd.ExecuteNonQuery() > 0);
        }
        catch (Exception e)
        {

          throw;
        }

      }

      return isSuccess;
    }

    public bool DeleteUser(string emailPK)
    {
      const string deleteUserQuery = "delete from Users where Email = @Email";
      bool isSuccess = false;
      //using (SqlConnection conn = new SqlConnection(connectionString))
      //{
      //  conn.Open();
      //  var cmd = new SqlCommand(deleteUserQuery, conn);
      //  cmd.Parameters.AddWithValue("@Email", emailPK);

      //  isSuccess = (cmd.ExecuteNonQuery() > 0);
      //}

      return isSuccess;
    }

    public bool UpdateUser(User user)  // needs work still
    {
      const string updateUserQuery = @"update users 
                                      set UserName = @UserName, 
                                      FirstName = @FirstName,
                                      LastName = @LastName,
                                      Password = @Password
                                      where Email = @Email";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        user.Password = "test";

        conn.Open();
        var cmd = new SqlCommand(updateUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@Username", user.UserName);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.FirstName);
        cmd.Parameters.AddWithValue("@Password", user.Password);

        cmd.ExecuteNonQuery();

      }

      return isSuccess;
    }

    public User GetUser(string emailPK)
    {
      var user = new User();
      const string getUserQuery = "select Username, FirstName, LastName, isAdmin from Users where email = @Email";

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(getUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", emailPK);
        var read = cmd.ExecuteReader();
        if (read.Read())
        {
          user = PopulateUser(read);
        }
        user.Email = emailPK;
      }

      return user;
    }

    private User PopulateUser(SqlDataReader reader)
    {
      var user = new User();
      try
      {
        if (reader.HasRows)
        {
          user.UserName = reader["Username"].ToString();
          user.FirstName = reader["FirstName"].ToString();
          user.LastName = reader["LastName"].ToString();
          user.IsAdmin = bool.Parse(reader["isAdmin"].ToString());
        }
      }
      catch (SqlException e)
      {
        throw;
      }

      return user;

    }
  }
}