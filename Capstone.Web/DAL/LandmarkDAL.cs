using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class LandmarkDAL : ILandmarkDAL
    {
        private string connectionString;
        string LastIdCreatedSQL = "SELECT CAST( SCOPE_IDENTITY() as int );";

        public LandmarkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Create landmark and persist to Database
        /// </summary>
        /// <param name="landmark">Poplated landmark object</param>
        /// <returns>Id of Created Landmark</returns>
        public int CreateLandmark(Landmark landmark)
        {
            int lastIdCreated = 0;
            string AddLandmarkDAL = "INSERT INTO Landmark (PlaceId, Latitude, Longitude, Name, Description, Address, Type) " +
                "VALUES (@PlaceId, @Lat, @Lng, @Name, @Description, @Address, @Type);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(AddLandmarkDAL + LastIdCreatedSQL, conn);
                    cmd.Parameters.AddWithValue("@PlaceId", landmark.PlaceId);
                    cmd.Parameters.AddWithValue("@Lat", landmark.Latitude);
                    cmd.Parameters.AddWithValue("@Lng", landmark.Longitude);
                    cmd.Parameters.AddWithValue("@Name", landmark.Name);
                    cmd.Parameters.AddWithValue("@Description", landmark.Description);
                    cmd.Parameters.AddWithValue("@Address", landmark.Address);
                    cmd.Parameters.AddWithValue("@Type", landmark.Type);
                    lastIdCreated = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Landmark wasn't added" + e.Message);
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something Went Wrong> Try again later." + e.Message);
                throw new Exception(e.Message);
            }

            return lastIdCreated;
        }

    public List<Landmark> GetEveryLandmark()
    {
      List<Landmark> landmarks = new List<Landmark>();
      string getAllLandmarksSQL = "SELECT Landmark.* FROM Landmark";

      try
      {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(getAllLandmarksSQL, conn);
          SqlDataReader reader = cmd.ExecuteReader();

          while (reader.Read())
          {
            landmarks.Add(MapLandmarkFromReader(reader));
          }
        }
      }
      catch (SqlException e)
      {
        Console.WriteLine("Couldn't retrieve landmark." + e.Message);
      }
      catch (Exception e)
      {

        Console.WriteLine("Something Went Wrong Try again later." + e.Message);
      }
      return landmarks;
    }

    /// <summary>
    /// Retrieves Landmark from DB
    /// </summary>
    /// <param name="id">ID of Landmark</param>
    /// <returns>Returns a Landmark</returns>
    public Landmark GetLandmark(int id)
        {
            Landmark landmark = null;
            string getLandMarkDAL = "SELECT * FROM Landmark WHERE Id = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getLandMarkDAL, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        landmark = MapLandmarkFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Couldn't retrieve landmark" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong> Try again later." + e.Message);
            }
            return landmark;
        }

        /// <summary>
        /// Retrieves a Landmark from the DB
        /// </summary>
        /// <param name="PlaceId">Uniquee PlaceId from Google</param>
        /// <returns>Populated landmark Object</returns>
        public Landmark GetLandmark(string PlaceId)
        {
            Landmark landmark = null;
            string getLandMarkDAL = "SELECT * FROM [dbo].[Landmark] WHERE PlaceId = @PlaceId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getLandMarkDAL, conn);
                    cmd.Parameters.AddWithValue("@PlaceId", PlaceId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        landmark = MapLandmarkFromReader(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Couldn't retrieve landmark" + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something Went Wrong> Try again later." + e.Message);
            }
            return landmark;
        }

        /// <summary>
        /// Get's a landmarks associated with a certain Itinerary
        /// </summary>
        /// <param name="itinId">Itienrary's ID</param>
        /// <returns>Returns a list of Landmarks</returns>
        public List<Landmark> GetAllLandmarks()
        {
            List<Landmark> landmarks = new List<Landmark>();
            string getAllLandmarksSQL = "SELECT Landmark.* FROM Landmark ORDER BY Landmark.Name ASC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getAllLandmarksSQL, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        landmarks.Add(MapLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Couldn't retrieve landmark." + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something Went Wrong Try again later." + e.Message);
            }
            return landmarks;
        }

        /// <summary>
        /// Get's a landmarks associated with a certain Itinerary
        /// </summary>
        /// <param name="itinId">Itienrary's ID</param>
        /// <returns>Returns a list of Landmarks</returns>
        public List<Landmark> GetAllLandmarks(int itineraryId)
        {
            List<Landmark> landmarks = new List<Landmark>();
            string getAllLandmarksSQL = "SELECT Landmark.* FROM Landmark " +
                "JOIN Itinerary_Landmark ON Itinerary_Landmark.Landmark_Id = Landmark.Id " +
                "JOIN Itinerary ON Itinerary.Id = Itinerary_Landmark.Itinerary_Id " +
                "WHERE Itinerary.Id = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getAllLandmarksSQL, conn);
                    cmd.Parameters.AddWithValue("@Id", itineraryId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        landmarks.Add(MapLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Couldn't retrieve landmark." + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something Went Wrong Try again later." + e.Message);
            }
            return landmarks;
        }

        /// <summary>
        /// Updates a landmark already in the Databse
        /// </summary>
        /// <param name="landmark">A Populated landmark object with IDs</param>
        /// <returns>Returns a boolean specifying if the operation was successful</returns>
        public bool UpdateLandmark(Landmark landmark)
        {
            bool wasSuccessful = false;
            string UpdateLandmarkSQL = "UPDATE Landmark SET [Latitude] = @Lat, [Longitude] = @Lng, [Name] = @Name," +
                "[Description] = @Description, [address] = @address, [ThumbsUp] = @ThumbsUp, [Type] = @Type WHERE PlaceId = @PlaceId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(UpdateLandmarkSQL, conn);
                    cmd.Parameters.AddWithValue("@Lat", landmark.Latitude);
                    cmd.Parameters.AddWithValue("@Lng", landmark.Longitude);
                    cmd.Parameters.AddWithValue("@Name", landmark.Name);
                    cmd.Parameters.AddWithValue("@Description", landmark.Description);
                    cmd.Parameters.AddWithValue("@address", landmark.Address);
                    cmd.Parameters.AddWithValue("@ThumbsUp", landmark.ThumbsUp);
                    cmd.Parameters.AddWithValue("@Type", landmark.Type);
                    cmd.Parameters.AddWithValue("@PlaceId", landmark.PlaceId);

                    wasSuccessful = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Update was Unsuccessful." + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong Try again later." + e.Message);
            }
            return wasSuccessful;
        }

        /// <summary>
        /// Removes a landmark from the DB
        /// </summary>
        /// <param name="PlaceId">Unique PlaceId from Google</param>
        /// <returns>Boolean specifying if the operation was succesful</returns>
        public bool DeleteLandmark(string PlaceId)
        {
            string DeleteLandmarkDAL = "DELETE FROM [Landmark] WHERE PlaceId = @PlaceId";
            bool wasSuccessful = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(DeleteLandmarkDAL, conn);
                    cmd.Parameters.AddWithValue("@PlaceId", PlaceId);
                    wasSuccessful = cmd.ExecuteNonQuery() == 1;
                }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine("Deletion failed" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong> Try again later." + e.Message);
            }
            return wasSuccessful;
        }

        /// <summary>
        /// Get's all Landmarks ordered by ThumbsUp
        /// </summary>
        /// <returns>Returns a list of Landmarks</returns>
        public List<Landmark> GetPopularLandmarks()
        {
            List<Landmark> landmarks = new List<Landmark>();
            string getPopularLandmarksSQL = "SELECT * FROM Landmark ORDER BY ThumbsUp DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getPopularLandmarksSQL, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        landmarks.Add(MapLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Couldn't retrieve landmark." + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something Went Wrong Try again later." + e.Message);
            }
            return landmarks;
        }


        /// <summary>
        /// Search Landmark Category
        /// </summary>
        /// <param name="searchTerm">Type/Category</param>
        /// <returns>List Of Landmarks that match the search term</returns>
        public List<Landmark> SearchLandmarkType(string searchTerm)
        {
            string SearchLandmarkSQL = "Select * From Landmark Where Type == @Term";
            List<Landmark> landmarks = new List<Landmark>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SearchLandmarkSQL, conn);
                    cmd.Parameters.AddWithValue("@Term", "%" + searchTerm + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        landmarks.Add(MapLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Ran into problem searching for landmarks in DB. Problem code: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Experiencing Technical Difficulty. Problem code: " + e.Message);
                throw;
            }
            return landmarks;
        }

        /// <summary>
        /// Maps properties from DB to a landmark object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Landmark MapLandmarkFromReader(SqlDataReader reader)
        {
            Landmark landmark = new Landmark()
            {
                Id = Convert.ToInt32(reader["Id"]),
                PlaceId = Convert.ToString(reader["PlaceId"]),
                Type = Convert.ToString(reader["Type"]),
                Latitude = Convert.ToDouble(reader["Latitude"]),
                Longitude = Convert.ToDouble(reader["Longitude"]),
                Name = Convert.ToString(reader["Name"]),
                Description = Convert.ToString(reader["Description"]),
                Address = Convert.ToString(reader["Address"]),
                ThumbsUp = Convert.ToString(reader["ThumbsUp"]) == "1" ? true : false,
            };
            return landmark;
        }

    }
}