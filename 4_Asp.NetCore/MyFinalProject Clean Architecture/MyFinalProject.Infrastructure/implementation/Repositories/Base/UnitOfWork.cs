using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Application.Abstractions.Repositories.Employees;
using MyFinalProject.Application.Abstractions.Repositories.Products;
using MyFinalProject.Application.Abstractions.Repositories.Roles;
using MyFinalProject.Application.Abstractions.Repositories.Users;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Infrastructure.implementation.Repositories.Employees;
using MyFinalProject.Infrastructure.implementation.Repositories.Products;
using MyFinalProject.Infrastructure.implementation.Repositories.Roles;
using MyFinalProject.Infrastructure.implementation.Repositories.Users;


namespace MyFinalProject.Infrastructure.implementation.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        public IRepository<Category> Categories { get; }

        public IRepository<Department> Departments { get; }

        public IEmployeeRepository Employees { get; }

        public IRepository<Permission> Permissions { get; }

        public IProductRepository Products { get; }
        public IRoleRepository Roles { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Categories = new Repository<Category>(_context);
            Departments = new Repository<Department>(_context);
            Employees = new EmployeeRepository(_context);
            Permissions = new Repository<Permission>(_context);
            Products = new ProductRepository(_context);
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);
        }

        public int Save()
        {
           return _context.SaveChanges();
        }
    }
}
