using TA_Telecom_Task.BL.Interface;
using TA_Telecom_Task.DL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Telecom_Task.BL.Repository
{
    public class GenericUnitOfWork
    {
        private TATelecomTaskDbContext _dbContext;

        public GenericUnitOfWork()
        {
            _dbContext = new TATelecomTaskDbContext();
        }

        public Type TheType { get; set; }

        public IGenericRepository<TEntityType> GetRepoInstance<TEntityType>() where TEntityType : class
        {
            return new GenericRepository<TEntityType>(_dbContext);
        }

        public bool SaveChanges()
        {
            try
            {
                if (_dbContext.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
