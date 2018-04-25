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

        public ItineraryDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Creat New Itinerary
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
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteItinerary(int id)
        {
            throw new NotImplementedException();
        }

        public Itinerary GetItenerary(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItinerary(Itinerary itinerary)
        {
            throw new NotImplementedException();
        }
    }
}