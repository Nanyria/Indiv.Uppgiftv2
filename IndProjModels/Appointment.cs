
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndUppClassModels
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

    }

}
