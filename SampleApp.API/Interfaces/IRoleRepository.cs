using SampleApp.API.Entities;

namespace SampleApp.API.Interfaces
{
    public interface IRoleRepository
    {
        Role CreateRole(Role role);
        IEnumerable<Role> GetRoles();
    }
}
