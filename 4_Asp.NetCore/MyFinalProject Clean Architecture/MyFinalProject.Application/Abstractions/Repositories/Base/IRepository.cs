
namespace MyFinalProject.Application.Abstractions.Repositories.Base
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
