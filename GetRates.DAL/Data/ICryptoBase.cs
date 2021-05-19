using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetRates.DAL.Data
{
    public interface ICryptoBase<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        
        Task<ICollection<T>> GetAsync();
        Task<T> GetAsync(int Id);

        Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<ICollection<T>> GetWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> UpdateAsync(T entity);
        Task<ICollection<T>> UpdateRangeAsync(ICollection<T> entities);
    }
}
