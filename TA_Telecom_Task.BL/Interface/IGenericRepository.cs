using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TA_Telecom_Task.BL.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(int pageSize, int currentPage, out int count);
        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> where);
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int Id);
        void Delete(int Id);
    }
}
