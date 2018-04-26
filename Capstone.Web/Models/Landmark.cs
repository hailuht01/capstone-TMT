using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
  public class Landmark
  {

    public int ID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longtiude { get; set; }
    public string PicName { get; set; }
    public string QueryString => Name.Trim().Replace(' ', '+');

    public DateTime LastUpdated { get; set; }

    public Landmark() { }

    public Landmark(int ID, string Name, string Address, string Description, double Latitude, double Longitude, string PicName)
    {
      this.ID = ID;
      this.Name = Name;
      this.Address = Address;
      this.Description = Description;
      this.Latitude = Latitude;
      this.Longtiude = Longitude;
      this.PicName = PicName;
    }

    public static List<Landmark> GetSamples() => new List<Landmark>()
    {
      new Landmark(999997, "Cincinnati Zoo", "3400 Vine St, Cincinnati, OH 45220", "Family Friendly Zoo! You are really going to love this place its awesome!", 39.144573, -84.508617, "Cincinnati-Zoo.jpg"),
      new Landmark(999998, "Cincinnati Museum Center", "1301 Western Ave, Cincinnati, OH 45203", "Family Friendly Museum! This place its awesome! You are really going to love it.", 39.110019, -84.537781, "Cincinnati-Museum.jpg"),
      new Landmark(999999, "Krohn Conservatory", "1501 Eden Park Dr, Cincinnati, OH 45202", "Blooming Conservatory! Because plants are super cool! Don't miss out.", 39.115235, -84.489999, "Krohn-Conservatory.jpg")
    };
  }
}