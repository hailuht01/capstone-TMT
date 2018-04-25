using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
  public class UserSession
  {
    public string Email { get; set; }
    public bool isAdmin { get; set; }

    public UserSession()
    {
        
    }

    public UserSession(string email, bool admin)
    {
      Email = email;
      isAdmin = admin; 
    }
  }
}