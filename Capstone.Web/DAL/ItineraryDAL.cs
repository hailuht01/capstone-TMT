using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
  public class ItineraryDAL : IItineraryDAL
  {
    private string connectionString;
    string GetLastIdInserted = "SELECT CAST(SCOPE_IDENTITY() as int);";

    //Constructor
    public ItineraryDAL(string connectionString)
    {
      this.connectionString = connectionString;
    }

    /// <summary>
    /// Create New Itinerary and save to DB
    /// </summary>
    /// <param name="itinerary">Populated Object to save</param>
    /// <returns>Boolean signaling success of failure</returns>
    public int CreateItinerary(Itinerary itinerary)
    {
      string SaveItinSQL = "Insert Into Itinerary(Title, CreationDate, DepartureDate, Description, User_Email) " +
          "Values(@Title, @CreateDate, @Departure, @Description, @UserEmail);";
      int lastIdInserted = 0;
      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(SaveItinSQL + GetLastIdInserted, conn);
          cmd.Parameters.AddWithValue("@Title", itinerary.Title);
          cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
          cmd.Parameters.AddWithValue("@Departure", itinerary.DepartureDate);
          cmd.Parameters.AddWithValue("@Description", itinerary.Description);
          cmd.Parameters.AddWithValue("@UserEmail", itinerary.UserEmail);
          lastIdInserted = (int)cmd.ExecuteScalar();
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Itinerary Create Failed: " + e.Message);
        throw new Exception(e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing Technical Difficulty: " + e.Message);
        throw new Exception(e.Message);
      }
      return lastIdInserted;
    }

    /// <summary>
    /// Remove Itinerary from DB
    /// </summary>
    /// <param name="id">unique itinerary id</param>
    /// <returns>Boolean signaling success of failure</returns>
    public bool DeleteItinerary(int id)
    {
      string deleteItinerarySQL = "DELETE FROM Itinerary WHERE Itinerary.Id = @Id";

      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(deleteItinerarySQL, conn);
          cmd.Parameters.AddWithValue("@id", id);
          return cmd.ExecuteNonQuery() == 1;
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Deletion Failed: " + e.Message);
        return false;
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing Technical Difficulty: " + e.Message);
        return false;
      }
    }

    /// <summary>
    /// Fetch Single Itinerary From DB
    /// </summary>
    /// <param name="id">Unique Itinerary ID</param>
    /// <returns>Poplated Itinerary Object</returns>
    public Itinerary GetItinerary(int id)
    {
      Itinerary itin = null;
      string getItinerarySQL = "SELECT * FROM Itinerary WHERE Itinerary.Id = @id;";
      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(getItinerarySQL, conn);
          cmd.Parameters.AddWithValue("@id", id);
          SqlDataReader reader = cmd.ExecuteReader();

          while (reader.Read())
          {
            itin = MapItineraryFromReader(reader);
          }
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Itinerary Retrieval Failed: " + e.Message);
        return null;
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing Technical Difficulty: " + e.Message);
        return null;
      }
      return itin;
    }

    /// <summary>
    /// Get All Itineraries for a given user
    /// </summary>
    /// <param name="userEmail">User email address</param>
    /// <returns>A List of itineraries</returns>
    public List<Itinerary> GetAllItineraries(string userEmail)
    {
      string getAllItinerariesSQL = "SELECT * From Itinerary Join Users On users.email = itinerary.user_email Where Users.email = @Email";
      List<Itinerary> itineraries = new List<Itinerary>();

      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(getAllItinerariesSQL, conn);
          cmd.Parameters.AddWithValue("@Email", userEmail);
          SqlDataReader reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            itineraries.Add(MapItineraryFromReader(reader));
          }

        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Itinerary retrieval failed: " + e.Message);
        return itineraries;
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing Technical Difficulty: " + e.Message);
        return itineraries;
      }
      return itineraries;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itinerary"></param>
    /// <returns></returns>
    public bool UpdateItinerary(Itinerary itinerary)
    {
      bool wasSuccesful = false;
      string UpdateItinerarySQL = "UPDATE Itinerary SET Title = @Title, CreationDate = @CreateDate, " +
          "DepartureDate = @DepartDate, description = @Description, User_Email = @UserEmail " +
          "WHERE Itinerary.Id = @Id";
      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(UpdateItinerarySQL, conn);
          cmd.Parameters.AddWithValue("@Title", itinerary.Title);
          cmd.Parameters.AddWithValue("@CreateDate", itinerary.CreationDate);
          cmd.Parameters.AddWithValue("@DepartDate", itinerary.DepartureDate);
          cmd.Parameters.AddWithValue("@Description", itinerary.Description);
          cmd.Parameters.AddWithValue("@UserEmail", itinerary.UserEmail);
          cmd.Parameters.AddWithValue("@Id", itinerary.Id);
          wasSuccesful = cmd.ExecuteNonQuery() == 1;
        }
      }
      catch (SqlException e)
      {

        Console.WriteLine($"Database issue. \nItinerary Wasn't Deleted.\nPlease try again. \nProblem Code: " + e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine($"Experiencing technical issues. /nTrouble Code: " + e.Message);
      }
      return wasSuccesful;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="landmarkID"></param>
    /// <param name="itinId"></param>
    /// <returns></returns>
    public bool AddLandmarkToItinerary(int landmarkId, int itinId)
    {
      bool wasSuccessful = false;
      string addLandToItinSQL = "INSERT INTO Itinerary_Landmark (Itinerary_Id, Landmark_Id) VALUES (@ItinId ,@LandmarkId)";
      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(addLandToItinSQL, conn);
          cmd.Parameters.AddWithValue("@ItinId", itinId);
          cmd.Parameters.AddWithValue("@LandmarkId", landmarkId);
          wasSuccessful = cmd.ExecuteNonQuery() == 1;
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Trouble adding landmark to itinerary. Trouble code: " + e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing some technical difficulty. Trouble code: " + e.Message);
      }
      return wasSuccessful;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="landmarkId"></param>
    /// <param name="itinId"></param>
    /// <returns></returns>
    public bool RemoveLandmarkFromItinerary(int landmarkId, int itinId)
    {
      bool wasSuccessful = false;
      string deleteLandFromItinSQL = "DELETE FROM Itinerary_Landmark WHERE Itinerary_Landmark.Itinerary_Id = @itinId AND Itinerary_Landmark.Landmark_Id = @LandmarkId;";
      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(deleteLandFromItinSQL, conn);
          cmd.Parameters.AddWithValue("@ItinId", itinId);
          cmd.Parameters.AddWithValue("@LandmarkId", landmarkId);
          wasSuccessful = cmd.ExecuteNonQuery() == 1;
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Trouble adding landmark to itinerary. Trouble code: " + e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing some technical difficulty. Trouble code: " + e.Message);
      }
      return wasSuccessful;
    }

    public bool ResetLandmark_Itinerary(int itinId)
    {
      bool wasSuccessful = false;
      string deleteLandFromItinSQL = "DELETE FROM Itinerary_Landmark WHERE Itinerary_Landmark.Itinerary_Id = @itinId";
      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(deleteLandFromItinSQL, conn);
          cmd.Parameters.AddWithValue("@ItinId", itinId);

          wasSuccessful = cmd.ExecuteNonQuery() == 1;
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Trouble adding landmark to itinerary. Trouble code: " + e.Message);
      }
      catch (Exception e)
      {
        Console.WriteLine("Experiencing some technical difficulty. Trouble code: " + e.Message);
      }
      return wasSuccessful;
    }

    /// <summary>
    /// Helper Method to read in itinerary columns from DB
    /// </summary>
    /// <param name="reader">Reader Object containing data</param>
    /// <returns>Populated Itinerary Object</returns>
    private Itinerary MapItineraryFromReader(SqlDataReader reader)
    {
      Itinerary itinerary = new Itinerary()
      {
        Title = Convert.ToString(reader["Title"]),
        Id = Convert.ToInt32(reader["Id"]),
        CreationDate = Convert.ToDateTime(reader["CreationDate"]),
        DepartureDate = Convert.ToDateTime(reader["DepartureDate"]),
        Description = Convert.ToString(reader["Description"]),
        UserEmail = Convert.ToString(reader["User_Email"])
      };

      return itinerary;
    }
  }
}