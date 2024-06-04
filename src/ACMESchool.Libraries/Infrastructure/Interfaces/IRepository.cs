using System.Linq.Expressions;

namespace ACMESchool.Libraries.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(dynamic id);
        Task<T> FindAsync(dynamic pk);
        Task<T> FirstOrDefaultAsync(Func<T, bool> filter);
        Task<IEnumerable<T>> GetListAsync();
        Task<List<T>> WhereAsync(Func<T, bool> filter);
    }
}