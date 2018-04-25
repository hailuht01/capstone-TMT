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
        public bool SaveItinerary( Itinerary itinerary )
        {
            string SaveItinSQL = "Insert Into Itinerary(Name, User_Email, Rating, CreationDate, DepartureDate) " +
                "Values(@Name, @Email, @CreateDate, @Departure)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SaveItinSQL, conn);
                    cmd.Parameters.AddWithValue("@Name", itinerary.Title);
                    cmd.Parameters.AddWithValue("@Email", itinerary.User_Email);
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Departure", itinerary.DepartureDate);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Itinerary Create Failed: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Experiencing Technical Difficulty: " + e.Message);
                return false;
            }
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
            string GetItinerarySQL = "SELECT * FROM Itinerary Join Itinerary_Landmark ON Itinerary_Landmark.Itinerary_Id = Itinerary.Id " +
                "WHERE Itinerary.id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GetItinerarySQL, conn);
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
            string getAllItinerariesSQL = "SELECT * From Itinerary Join Users On users.email = itinerary.user_email Where User.email = @Email";
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
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Experiencing Technical Difficulty: " + e.Message);
                return null;
            }
            return itineraries;
        }


        public bool UpdateItinerary(Itinerary itinerary)
        {
            throw new NotImplementedException();
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
                Title = Convert.ToString(reader["Name"]),
                Id = Convert.ToInt32(reader["Id"]),
                User_Email = Convert.ToString(reader["User_Email"]),
                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                DepartureDate = Convert.ToDateTime(reader["DepartureDate"])
            };

            return itinerary;
        }
    }
}