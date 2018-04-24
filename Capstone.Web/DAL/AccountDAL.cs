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
        "Users(Email, Username, FirstName, LastName, Password) " +
        "Values(@Email, @Username, @FirstName,@LastName, @Password)";
      bool isSuccess = false;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(createUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@Username", user.UserName);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.LastName);
        cmd.Parameters.AddWithValue("@Password", user.Password);

        isSuccess = (cmd.ExecuteNonQuery() > 0);
      }

      return isSuccess;
    }

    public bool DeleteUser(string emailPK)
    {
      const string deleteUserQuery = "delete from Users where Email = @Email";
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

    public User GetUser(string emailPK, string password)
    {
      var user = new User();
      const string getUserQuery = "select * from Users where Email = @Email and Password = @Password";
      const string getUserItineraryQuery = "select * from Itenerary where User_Email = @Email";

      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        var cmd = new SqlCommand(getUserQuery, conn);
        cmd.Parameters.AddWithValue("@Email", emailPK);
        cmd.Parameters.AddWithValue("@Password", password);

        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
          user = PopulateUser(reader);
          cmd = new SqlCommand(getUserItineraryQuery, conn);
          cmd.Parameters.AddWithValue("@Email", emailPK);
          reader.Close();

          // pop user itinerarys 
          reader = cmd.ExecuteReader();
          user.Itinerarys = PopulateUserItinerarys(reader);
        }
        else
        {

          //user.Itinerarys = sampleitinerary
        }
      }
      return user;
    }



  private List<Itinerary> PopulateUserItinerarys(SqlDataReader reader)
  {
    var itinerarys = new List<Itinerary>();
    while (reader.Read())
    {
      var itinerary = new Itinerary();
      itinerary.Id = int.Parse(reader["Id"].ToString());
      itinerary.Title = reader["Title"].ToString();
        itinerary.

      itinerarys.Add(itinerary);
    }

    return itinerarys;
  }

  private User PopulateUser(SqlDataReader reader)
  {
    var user = new User();

    user.Email = reader["Email"].ToString();
    user.UserName = reader["Username"].ToString();
    user.FirstName = reader["FirstName"].ToString();
    user.LastName = reader["LastName"].ToString();
    //user.IsAdmin = int.Parse(reader["isAdmin"].ToString()) == 1 ? true : false;

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