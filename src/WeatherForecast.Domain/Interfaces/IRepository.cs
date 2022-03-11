using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> All();
        Task<T> Find(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
