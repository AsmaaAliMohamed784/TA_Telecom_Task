using TA_Telecom_Task.BL.Interface;
using TA_Telecom_Task.DL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TA_Telecom_Task.BL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> _dbSet;
        private TATelecomTaskDbContext _dbContext;

        public GenericRepository(TATelecomTaskDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(int pageSize, int currentPage, out int count)
        {
            IEnumerable<TEntity> query = _dbSet;
            count = query.Count();
            return query.Skip((pageSize * currentPage) - pageSize).Take(pageSize).ToList();
        }

        public IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = _dbSet;
            return query.Where(where);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Get(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Delete(int Id)
        {
            var entity = _dbSet.Find(Id);
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
    }
}
