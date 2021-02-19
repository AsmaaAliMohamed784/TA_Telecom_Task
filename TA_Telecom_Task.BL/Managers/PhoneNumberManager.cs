using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Telecom_Task.BL.Interface;
using TA_Telecom_Task.BL.Repository;
using TA_Telecom_Task.BL.ViewModels;
using TA_Telecom_Task.DL.Models;

namespace TA_Telecom_Task.BL.Managers
{
    public class PhoneNumberManager
    {
        GenericUnitOfWork _UnitOfWork;
        IGenericRepository<PhoneNumber> _repository;

        public PhoneNumberManager()
        {
            _UnitOfWork = new GenericUnitOfWork();
            _repository = _UnitOfWork.GetRepoInstance<PhoneNumber>();
        }

        public IEnumerable<PhoneNumberDTO> GetPhoneNumbers()
        {
            try
            {
                IEnumerable<PhoneNumberDTO> NumberList = _repository.Get()
                                                 .Select(item => new PhoneNumberDTO()
                                                 {
                                                     Id = item.Id,
                                                     PhoneNum = item.PhoneNum 
                                                 });

                return NumberList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
