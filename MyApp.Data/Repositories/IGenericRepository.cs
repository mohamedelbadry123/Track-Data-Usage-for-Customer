using System.Linq;
using System.Linq.Expressions;

namespace MyApp.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); // Optional: Custom queries
    }
}
