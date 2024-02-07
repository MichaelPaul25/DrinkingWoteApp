using AutoMapper;
using DrinkingWoteApp_API.Dto;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using DrinkingWoteApp_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingWoteApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [HttpGet("userId")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserId(int userId)
        {
            
            if (!_userRepository.UserExist(userId))
            {
                return NotFound($"Cannot find user {userId}");
            }

            var userDetail = _mapper.Map<UserDto>(_userRepository.GetById(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userDetail);
        }

        [HttpGet("Balance/{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserBalance(int userId)
        {
            if (!_userRepository.UserExist(userId))
                return NotFound($"Cannot find user {userId}");

            var balance = _userRepository.GetUserBalance(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(balance);
        }

        [HttpGet("userName")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetByUsername(string username)
        {
            var getUser = _userRepository.GetByUsername(username);

            if (getUser == null)
                return NotFound($"Cannot Find user {username}");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(getUser);
        }
    }
}
