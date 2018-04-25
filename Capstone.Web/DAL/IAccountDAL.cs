using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IAccountDAL
    {
        User AuthUser(string emailPK, string password);
        User GetUser(string emailPK);
        bool CreateUser(RegistrationForm user);
        bool UpdateUser(User user);
        bool DeleteUser(string emailPK);
    }
}