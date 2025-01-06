using Microsoft.EntityFrameworkCore;
using MyApp.Data.Repositories;

namespace MyApp.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;
        DbContext Context { get; }
        Task<int> SaveChangesAsync();
    }
}
