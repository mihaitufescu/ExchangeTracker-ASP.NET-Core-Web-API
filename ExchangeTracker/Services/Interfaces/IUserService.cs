using ExchangeTracker.Models;

namespace ExchangeTracker.Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        UserModel GetUserByName(string name);
    }
}
