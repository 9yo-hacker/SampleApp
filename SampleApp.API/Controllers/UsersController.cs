using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Dto;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using SampleApp.API.Validations;

namespace SampleApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly HMACSHA256 _hmac = new HMACSHA256();
        public UsersController(IUserRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDto userDto)
        {
            try
            {
                var user = _repo.GetUsers()
                    .FirstOrDefault(u => u.Login.ToLower() == userDto.Login.ToLower());

                if (user == null)
                    return Unauthorized("Неверный логин");

                user.Token = _tokenService.CreateToken(user.Login);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<User> Create([FromBody] UserDto userDto)
        {
            var user = new User
        {
            Login = userDto.Login,
            PasswordHash = _hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
            PasswordSalt = _hmac.Key,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Token = _tokenService.CreateToken(userDto.Login)
        };

            var validator = new FluentValidator();
            var result = validator.Validate(user);
            var createdUser = _repo.CreateUser(user);

            if (!result.IsValid)
            {
                return BadRequest($"{result.Errors.First().ErrorMessage}");
            }

            return Created($"/users/{createdUser.Id}", // ссылка на новый объект
                createdUser                                // тело ответа
                );
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_repo.GetUsers());
        }
        [HttpPut("{id}")]
        public IActionResult EditUser(User user, int id)
        {
            return Ok(_repo.EditUser(user, id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_repo.DeleteUser(id));
        }
        [HttpGet("{id}")]
        public IActionResult FindUserById(int id)
        {
            return Ok(_repo.FindUserById(id));
        }
    }
}
