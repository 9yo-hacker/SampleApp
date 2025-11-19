using SampleApp.API.Interfaces;
using SampleApp.API.Entities;

namespace SampleApp.API.Repositories
{
    public class RoleMemoryRepository : IRoleRepository
    {
        private readonly List<Role> _roles = new();
        public Role CreateRole(Role role)
        {
            role.Id = _roles.Count + 1;
            role.Name = role.Name;
            return role;
        }
        public IEnumerable<Role> GetRoles()
        {
            return _roles;
        }
    }
}
