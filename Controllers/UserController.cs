using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site_EKMTech_API2.Entities;
using Site_EKMTech_API2.Interfaces;

namespace Site_EKMTech_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<List<User>>>GetAll()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            return Ok(user);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var newUser = await _userRepository.AddUser(user);
            return Ok(newUser);
        }
        [HttpDelete("userdeletado/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            return Ok(user);
        }
        [HttpGet("getbynome")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await _userRepository.GetUser(username);
            return Ok(user);
        }
    }
}
