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
        public async Task<ActionResult<RespModel<List<User>>>>GetAll()
        {
            var users = await _userRepository.GetUsers();
            return users.Success ? Ok(users) : NotFound(users);
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<RespModel<User>>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            return user.Success ? Ok(user) : NotFound(user);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<RespModel<User>>> AddUser(User user)
        {
            var newUser = await _userRepository.AddUser(user);
            return newUser.Success ? Ok(newUser) : BadRequest(newUser);
        }
        [HttpDelete("userdeletado/{id}")]
        public async Task<ActionResult<RespModel<User>>> DeleteUser(int id)
        {
            var userdeletado = await _userRepository.DeleteUser(id);
            return userdeletado.Success ? Ok(userdeletado) : NotFound(userdeletado);
        }
        [HttpGet("getbynome")]
        public async Task<ActionResult<RespModel<User>>> GetUser(string username)
        {
            var user = await _userRepository.GetUser(username);
            return user.Success ? Ok(user) : NotFound(user);
        }
    }
}
