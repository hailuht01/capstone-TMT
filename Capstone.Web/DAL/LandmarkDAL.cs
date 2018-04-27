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

        public LandmarkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="landmark"></param>
        /// <returns></returns>
        public bool AddLandmark(Landmark landmark)
        {
            bool wasSuccessful = false;
            string AddLandmarkDAL = "INSERT INTO Landmark ([Id],[Latitude],[Longitude],[Name],[Description],[address],[PicName],[ThumbsUp],[Type]) " +
                "VALUES(@PlaceId, @Lat, @Lng, @Name, @description, @Address, @PicName , @ThumbsUp)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(AddLandmarkDAL, conn);
                    wasSuccessful = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException e)
            {

                Console.WriteLine("Landmark wasn't added" + e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something Went Wrong> Try again later." + e.Message);
            }

            return wasSuccessful;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteLandmark(string id)
        {
            string DeleteLandmarkDAL = "DELETE FROM [Landmark] WHERE Id = @Id";
            bool wasSuccessful = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(DeleteLandmarkDAL, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
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
        /// 
        /// </summary>
        /// <param name="itinId"></param>
        /// <returns></returns>
        public List<Landmark> GetAllLandmark(string itinId)
        {
            List<Landmark> landmarks = new List<Landmark>();
            string getAllLandmarksSQL = "SELECT Landmark.Id,[Latitude],[Longitude],[Name],[Description],[address],[PicName],[ThumbsUp],[Type] FROM [dbo].[Landmark] " +
                "JOIN Itinerary_Landmark ON Itinerary_Landmark.Landmark_Id = Landmark.Id WHERE Itinerary_Landmark.Id = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getAllLandmarksSQL, conn);
                    cmd.Parameters.AddWithValue("@Id", itinId);
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Landmark GetLandmark(string id)
        {
            Landmark landmark = null;
            string getLandMarkDAL = "SELECT [Id],[Latitude],[Longitude],[Name],[Description],[address],[PicName],[ThumbsUp],[Type] " +
                "FROM [dbo].[Landmark] WHERE Id = @Id";

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
        /// 
        /// </summary>
        /// <param name="landmark"></param>
        /// <returns></returns>
        public bool UpdateLandmark(Landmark landmark)
        {
            bool wasSuccessful = false;
            string UpdateLandmarkSQL = "UPDATE Landmark SET [Latitude] = @Lat, [Longitude] = @Lng, [Name] = @Name," +
                "[Description] = @Description, [address] = @address, [PicName] = @PicName, [ThumbsUp] = @ThumbsUp, [Type] = @Type WHERE Id = @Id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(UpdateLandmarkSQL, conn);
                    cmd.Parameters.AddWithValue("@Lat", landmark.Latitude);
                    cmd.Parameters.AddWithValue("@Lng", landmark.Longtiude);
                    cmd.Parameters.AddWithValue("@Name", landmark.Name);
                    cmd.Parameters.AddWithValue("@Description", landmark.Description);
                    cmd.Parameters.AddWithValue("@address", landmark.Address);
                    cmd.Parameters.AddWithValue("@PicName", landmark.PicName);
                    cmd.Parameters.AddWithValue("@ThumbsUp", landmark.ThumbsUp);
                    cmd.Parameters.AddWithValue("@Type", landmark.Type);
                    cmd.Parameters.AddWithValue("@Id", landmark.PlaceId);

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
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Landmark MapLandmarkFromReader(SqlDataReader reader)
        {
            Landmark landmark = new Landmark()
            {
                PlaceId = Convert.ToString(reader["Id"]),
                Type = Convert.ToString(reader["Type"]),
                Latitude = Convert.ToSingle(reader["Latitude"]),
                Longtiude = Convert.ToSingle(reader["Longitude"]),
                Name = Convert.ToString(reader["Name"]),
                Description = Convert.ToString("Description"),
                Address = Convert.ToString("Address"),
                PicName = Convert.ToString("PicName"),
                ThumbsUp = Convert.ToBoolean("ThumbsUp")
            };
            return landmark;
        }
    }
}