using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DBContext _context;

        
        internal DbSet<T> _database;

        protected readonly ILogger _logger;

        public Repository(DBContext context, ILogger logger)
        {
            _context = context;
            _database = context.Set<T>();
            _logger = logger;

        }

        public virtual Task<IQueryable<T>> All()
        {
             return Task.FromResult(_database.AsNoTracking()); 
        }

        public virtual async Task<T> Find(int id)
        {
            return await _database.FindAsync(id);
        }

        public virtual Task<bool> Add(T entity)
        {
            _database.AddAsync(entity);

            return Task.FromResult(true);
        }

        public virtual Task<bool> Delete(T entity)
        {
            _database.Remove(entity);

            return Task.FromResult(true);
        }

        public virtual Task<bool> Update(T entity)
        {
            _database.Update(entity);

            return Task.FromResult(true);
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _database.Where(predicate).ToListAsync();
        }
    }
}
