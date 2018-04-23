﻿using Capstone.Web.Models;

namespace Capstone.Web.DAL
{


    public interface IAccountDAL
    {
        User GetUser(String emailPK);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string emailPK);
           


    }
}