using AutoMapper;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExchangeTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public List<UserModel> GetAllUsers()
        {
            var users = _mapper.Map<List<UserModel>>(_userRepository.GetUsers());

            return users;
        }

        public UserModel GetUserById(int id)
        {
            var user = _mapper.Map<UserModel>(_userRepository.GetUserById(id));
            return user;
        }

        public UserModel GetUserByName(string name)
        {
            var user = _mapper.Map<UserModel>(_userRepository.GetUserByName(name));
            return user;
        }
        
    }
}
