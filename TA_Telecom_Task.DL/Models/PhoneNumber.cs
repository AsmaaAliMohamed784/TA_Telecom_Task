using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Telecom_Task.DL.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNum { get; set; }
    }
}
