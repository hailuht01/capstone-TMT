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
    public double Rating { get; set; }

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
      new Landmark(999997, "Cincinnati Zoo", "3400 Vine St, Cincinnati, OH 45220", " The second oldest Zoo in the United States. Wide variety of animal collection.The Zoo was founded on 65 acres in the middle of the city, and since then has acquired some of the surrounding blocks and several reserves in Cincinnati’s suburbs.", 39.1446, 84.5086, "Cincinnati-Zoo.jpg"),
      new Landmark(999998, "Cincinnati Museum Center", "1301 Western Ave, Cincinnati, OH 45203", "Family Friendly Museum! This place its awesome! You are really going to love it.", 39.1152, 84.4900, "Cincinnati-Museum.jpg"),
      new Landmark(999999, "Krohn Conservatory", "1501 Eden Park Dr, Cincinnati, OH 45202", "Blooming Conservatory! Because plants are super cool! Don't miss out.", 39.1100, 84.5378, "Krohn-Conservatory.jpg"),
      new Landmark(999910, "Music Hall", "1241 Elm Street, Cincinnati, Ohio", " A classical music performance hall Don't miss out.", 39.1100, 84.5378, "Music-Hall.jpg"),

    new Landmark(999911, "Fountain Square", " 520 Vine St, Cincinnati, OH 45202", "Fountain Square is the city square; features many shops, restaurants, hotels, and offices.", 39.1100, 84.5378, "Fountain-Square.jpg"),

    new Landmark(999912, "Newport On the Levee", "1 Levee Way, Newport, KY 41071", "Newport on the Levee is a premier dining and attraction destination!", 39.1100, 84.5378, "Newport-On-the-Levee.jpg"),

    new Landmark(999913, "John A. Roebling Suspension Bridge","1501 Eden Park Dr, Cincinnati, OH 45202", "The John A. Roebling Suspension Bridge, originally known as the Cincinnati-Covington Bridge spans the Ohio River between Cincinnati, Ohio and Covington, Kentucky", 39.1100, 84.5378, "John A. Roebling Suspension Bridge.jpg"),

    };

  }
}