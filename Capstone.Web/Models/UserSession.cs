using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
  public class UserSession
  {
    public User User { get; set; }
    public List<Itinerary> Itinerarys { get; set; }

    public UserSession(User user, List<Itinerary> itinerarys)
    {
      User = user;
      Itinerarys = itinerarys;
    }
  }
}