using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IAccountDAL
    {
        User GetUser(string emailPK, string password);
        bool CreateUser(RegistrationForm user);
        bool UpdateUser(User user);
        bool DeleteUser(string emailPK);
    }
}