using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Domain;

namespace MyFinalProject.Application.Abstractions.Repositories.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleWithPermissions(int Id);
    }
}
