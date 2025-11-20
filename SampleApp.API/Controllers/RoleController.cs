using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using SampleApp.API.Validations;

namespace SampleApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;
        public RoleController(IRoleRepository role) 
        {
            _repo = role;
        }

        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            var createdRole = _repo.CreateRole(role);

            return Created(
                $"/users/{createdRole.Id}",  // ссылка на новый ресурс
                createdRole                  // тело ответа
            );
        }

    }
}
