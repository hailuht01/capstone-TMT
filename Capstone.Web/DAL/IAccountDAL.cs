using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IAccountDAL
    {
        bool CreateUser(User user);
        bool DeleteUser(string emailPK);
        User GetUser(string emailPK);
        bool UpdateUser(User user);

    }
}