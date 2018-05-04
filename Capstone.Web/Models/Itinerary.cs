using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Itinerary
    {
        DateTime _createDate;
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                _createDate = value;
            }
        } 
        
        // private set?
        public DateTime? DepartureDate { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }

    //public int Route { get; set; }

        public Itinerary() { }

        public Itinerary(string Title, DateTime? DepartureDate, string description, string userEmail)
        {
            this.Title = Title;
            this.DepartureDate = DepartureDate;
            this.CreationDate = DateTime.Now;
            this.Description = description;
            this.UserEmail = userEmail;

        }
    }
}