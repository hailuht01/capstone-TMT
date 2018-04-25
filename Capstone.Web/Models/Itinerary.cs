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

    public static Itinerary GetSample()
    {
      return new Itinerary("Sample Itinerary", 999999, DateTime.Now, DateTime.Now.AddDays(1), 4.4, "jake@neels.io", "itsJake", Landmark.GetSamples());
    }

    //ctor for testing and first time users
    public Itinerary() { }

    public Itinerary(string Title, int Id, DateTime CreationDate, DateTime? DepartureDate, double Rating, string User_Email, string UserName, List<Landmark> Landmarks)
    {
      this.Title = Title;
      this.Id = Id;
      this.CreationDate = CreationDate;
      this.DepartureDate = DepartureDate;
      this.Rating = Rating;
      this.User_Email = User_Email;
      this.UserName = UserName;
      this.Landmarks = Landmarks;

    }
  }
}