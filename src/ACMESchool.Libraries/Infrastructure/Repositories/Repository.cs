using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ACMESchool.Libraries.Infrastructure.Interfaces;

namespace ACMESchool.Libraries.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static List<T> _listEntities = [];

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                _listEntities.Add(entity);
            }
            catch
            {
                throw;
            }
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(dynamic id)
        {
            try
            {
                _listEntities.Remove(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<T> FindAsync(dynamic pk)
        {
            try
            {
                return _listEntities.Find(pk);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<T> FirstOrDefaultAsync(Func<T, bool> filter)
        {
            try
            {
                return _listEntities.FirstOrDefault(filter);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            try
            {
                return _listEntities.ToList();
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<List<T>> WhereAsync(Func<T, bool> filter)
        {
            try
            {
                return _listEntities.Where(filter).ToList();
            }
            catch
            {
                throw;
            }
        }

    }
}
