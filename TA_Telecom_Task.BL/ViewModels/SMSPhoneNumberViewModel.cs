using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Telecom_Task.BL.ViewModels
{
    public class SMSPhoneNumberDTO
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public int PhoneNumId { get; set; }

        public DateTime SendedDate { get; set; }

        public PhoneNumberDTO PhoneNumber { get; set; }

        public IEnumerable<PhoneNumberDTO> PhoneNumbers { get; set; }    //To fill phoneNumber dropdown

    }
}
