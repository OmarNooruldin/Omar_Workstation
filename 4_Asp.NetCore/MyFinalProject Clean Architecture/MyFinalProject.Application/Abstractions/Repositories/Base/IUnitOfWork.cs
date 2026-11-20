using MyFinalProject.Application.Abstractions.Repositories.Users;
using MyFinalProject.Application.Abstractions.Repositories.Employees;
using MyFinalProject.Application.Abstractions.Repositories.Products;
using MyFinalProject.Application.Abstractions.Repositories.Roles;
using MyFinalProject.Domain;

namespace MyFinalProject.Application.Abstractions.Repositories.Base
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Department> Departments { get; }
        IEmployeeRepository Employees { get; }
        IRepository<Permission> Permissions { get; }
        IProductRepository Products { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        
        int Save();
    }
}
