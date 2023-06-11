using GraduateAppProject.Entities;

namespace GraduateAppProject.WebMVC.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(int id);
        T Get(int id);
        Task<IList<T>> GetAllAsync();
        IList<T> GetAll();
        Task<int> CreateAsync(T entity);
        int Create(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        void Delete(int id);
    }
}
