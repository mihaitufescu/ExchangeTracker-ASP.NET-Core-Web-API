using AutoMapper;
using BCrypt.Net;
using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Text.RegularExpressions;

namespace ExchangeTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper,IUserService userService, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUserById(int id) {
            var user = _userService.GetUserById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUserByName(string name)
        {
            var user = _userService.GetUserByName(name);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest(ModelState);
            }
            var user = _userRepository.GetUsers()
                .Where(c => c.Name.Trim().ToUpper() == userCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
            if(user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422,ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userCreate.Password = BCrypt.Net.BCrypt.HashPassword(userCreate.Password);
            userCreate.Created_At = DateTime.UtcNow;
            var userMap = _mapper.Map<User>(userCreate);
            if (!_userRepository.CreateUser(userMap)){
                ModelState.AddModelError("", "Something went wrong while adding the user");
                return StatusCode(500,ModelState);
            }
            return Ok("Succesful!");
        }
        [HttpPut("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUserPassword(int id, string password)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (id == null)
            {
                return BadRequest(ModelState);
            }
            if(password.Length < 8)
            {
                ModelState.AddModelError("", "Password is too short");
                return StatusCode(422, ModelState);
            }
            if (!r.IsMatch(password))
            {
                ModelState.AddModelError("", "Password doesn't match the requirements");
                return StatusCode(422, ModelState);
            }
            var user = _userRepository.GetUserById(id);
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            return Ok("Succesful!");
        }

    }
}
