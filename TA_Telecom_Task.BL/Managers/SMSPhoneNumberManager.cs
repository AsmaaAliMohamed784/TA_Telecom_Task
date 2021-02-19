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
    public class SMSPhoneNumberManager
    {
        GenericUnitOfWork _UnitOfWork;
        IGenericRepository<SMSPhoneNumber> _repository;

        public SMSPhoneNumberManager()
        {
            _UnitOfWork = new GenericUnitOfWork();
            _repository = _UnitOfWork.GetRepoInstance<SMSPhoneNumber>();
        }

        public IEnumerable<SMSPhoneNumberDTO> GetSMSPhoneNumbers()
        {
            try
            {
                IEnumerable<SMSPhoneNumberDTO> SMSList = _repository.Get()
                                                 .Select(item => new SMSPhoneNumberDTO()
                                                 {
                                                     Id = item.Id,
                                                     Message = item.Message,
                                                     PhoneNumId = item.PhoneNumId,
                                                     PhoneNumber = new PhoneNumberDTO()
                                                     {
                                                         Id = item.PhoneNumId,
                                                         PhoneNum = item.PhoneNumber.PhoneNum
                                                     },
                                                 });
                return SMSList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(SMSPhoneNumberDTO Msg, int PhoneId)
        {
            try
            {
                SMSPhoneNumber newMsg = new SMSPhoneNumber()
                {
                    PhoneNumId = PhoneId,
                    Message = Msg.Message,
                    SendedDate = DateTime.Now,
                };
                _repository.Add(newMsg);
                return _UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
