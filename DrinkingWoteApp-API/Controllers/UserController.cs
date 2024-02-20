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
            //var users = _userRepository.GetUsers();

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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto createUser)
        {
            if (createUser == null)
                return BadRequest(ModelState);

            var user = _userRepository.GetUsers()
                .Where(u => u.Email == createUser.Email) 
                .FirstOrDefault();

            if(user != null)
            {
                ModelState.AddModelError("", "User already register!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Newuser = _mapper.Map<User>(createUser);

            if(!_userRepository.CreateUser(Newuser))
            {
                ModelState.AddModelError("", "Can't Add new User!");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Create new User");
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int Id, [FromBody] UserDto updateUser)
        {
            if(updateUser == null)
                return BadRequest(ModelState);

            if(Id != updateUser.Id)
                return BadRequest(ModelState);

            if (!_userRepository.UserExist(Id))
                return NotFound($"User Id {Id} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<User>(updateUser);

            if(!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Update user data error!");
                return StatusCode(500, ModelState);
            }

            return Ok("Update Successfully");
        }

        //Delete user
        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int Id)
        {
            if (!_userRepository.UserExist(Id))
                return NotFound();

            var userToDelete = _userRepository.GetById(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return Ok("Delete User Successfully!");
        }
    }
}
