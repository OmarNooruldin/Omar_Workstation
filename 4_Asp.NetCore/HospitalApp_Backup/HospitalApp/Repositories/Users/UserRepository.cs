using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Users
{
    public class UserRepository : Repository<User> ,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public IEnumerable<Role> GetRoleByIds(List<int> Id)
        {
            return _context.Roles.Where(r => Id.Contains(r.Id)).ToList();
        }

        public User GetUserWithRoles(int Id)
        {
            return _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == Id);
        }
    }
}
