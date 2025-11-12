using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using SampleApp.API.Validations;

namespace SampleApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
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
