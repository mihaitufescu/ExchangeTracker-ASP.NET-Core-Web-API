using ExchangeTracker.DAL.DBO;
using ExchangeTracker.Models;

namespace ExchangeTracker.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User GetUserByName(string name);
        bool CreateUser(User user);
        bool UpdateUserPassword(int id, string password);
        bool Save();
    }
}
