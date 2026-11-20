using MyFinalProject.Data;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Employees;
using MyFinalProject.Repositories.Products;
using MyFinalProject.Repositories.Roles;
using MyFinalProject.Repositories.Users;

namespace MyFinalProject.Repositories.Base
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
