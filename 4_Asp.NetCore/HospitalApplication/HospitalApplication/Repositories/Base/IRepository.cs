using HospitalApplication.Models;

namespace HospitalApplication.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
