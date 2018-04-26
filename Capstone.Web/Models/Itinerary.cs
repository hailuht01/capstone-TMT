using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
  public class Itinerary
  {

    public string Title { get; set; }
    public int Id { get; set; }
    public DateTime CreationDate { get; set; } // private set?
    public DateTime? DepartureDate { get; set; }
    public double Rating { get; set; }
    public string User_Email { get; set; }
    public string UserName { get; set; }
    public IList<Landmark> Landmarks { get; set; } = new List<Landmark>();
    //public int Route { get; set; }

    public static List<Itinerary> GetSamples()
    {
      return new List<Itinerary>() { new Itinerary("Sample Itinerary", 999999, DateTime.Now.AddDays(1), 4.4, "jake@neels.io", "itsJake", Landmark.GetSamples()) };
    }

    public Itinerary() { }

    public Itinerary(string Title, int Id, DateTime? DepartureDate, double Rating, string User_Email, string UserName, List<Landmark> Landmarks)
    {
      this.Title = Title;
      this.Id = Id;
      this.DepartureDate = DepartureDate;
      this.Rating = Rating;
      this.User_Email = User_Email;
      this.UserName = UserName;
      this.Landmarks = Landmarks;
      this.CreationDate = DateTime.Now;

    }
  }
}