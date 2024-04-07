using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.DAL.DBO;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExchangeTracker.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            return _context.User.OrderBy(p => p.Id).ToList();
        }
        public User GetUserById(int id)
        {
            return _context.User.Find(id);
        }

        public User GetUserByName(string name)
        {
            return _context.User.FirstOrDefault(p => p.Name.Trim().ToUpper() == name.Trim().ToUpper());
        }
        public bool CreateUser(User user)
        {
            _context.User.Add(user);
            return Save();
        }

        public bool UpdateUserPassword(int id, string password)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return false;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
