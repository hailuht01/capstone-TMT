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
    public string UserName { get; set; }

    public UserSession()
    {
        
    }

    public UserSession(string email, string userName, bool admin)
    {
      Email = email;
      UserName = userName;
      isAdmin = admin; 
    }
  }//@HttpContext.Current.Session["User.Session"].ToString()
}