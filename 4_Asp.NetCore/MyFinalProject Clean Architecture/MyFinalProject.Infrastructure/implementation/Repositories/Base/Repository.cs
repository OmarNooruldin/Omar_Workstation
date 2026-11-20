using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Infrastructure.Data;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
            //SaveChanges();
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
            //SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
            //SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
