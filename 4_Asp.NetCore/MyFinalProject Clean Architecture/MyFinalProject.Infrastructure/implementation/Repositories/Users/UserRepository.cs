using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Repositories.Users;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Infrastructure.implementation.Repositories.Base;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Users
{
    public class UserRepository : Repository<User> ,IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context) { }
    


        public User GetUserWithRoles(int Id)
        {
            return _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == Id);
        }

    }
}
