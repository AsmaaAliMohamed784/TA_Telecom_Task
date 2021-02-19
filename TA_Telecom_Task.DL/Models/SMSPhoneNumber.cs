using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Telecom_Task.DL.Models
{
    public class SMSPhoneNumber
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public int PhoneNumId { get; set; }
        [ForeignKey("PhoneNumId")]
        public virtual PhoneNumber PhoneNumber { get; set; }

        public DateTime SendedDate { get; set; }
    }
}
