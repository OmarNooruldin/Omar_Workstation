using MyFinalProject.Models;
using MyFinalProject.Repositories.Employees;
using MyFinalProject.Repositories.Products;
using MyFinalProject.Repositories.Roles;
using MyFinalProject.Repositories.Users;

namespace MyFinalProject.Repositories.Base
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
