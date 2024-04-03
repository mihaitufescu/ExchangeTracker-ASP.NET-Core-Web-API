using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.DAL.DBO;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExchangeTracker.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        public List<User> GetUsers()
        {
            return context.User.OrderBy(p => p.Id).ToList();
        }
        public User GetUserById(int id)
        {
            return context.User.Find(id);
        }

        public User GetUserByName(string name)
        {
            return context.User.FirstOrDefault(p => p.Name.Trim().ToUpper() == name.Trim().ToUpper());
        }
        public bool CreateUser(User user)
        {
            context.User.Add(user);
            return Save();
        }

        public bool UpdateUserPassword(int id, string password)
        {
            var user = context.User.Find(id);
            if (user == null)
            {
                return false;
            }
            user.Password = password;
            return Save();
        }
        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
