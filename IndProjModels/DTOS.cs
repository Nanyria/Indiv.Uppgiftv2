using IndUppClassModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndProjModels
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerID { get; set; }
        public List<AppointmentChangeDTO> Changes { get; set; } = new List<AppointmentChangeDTO>();

    }
    public class AppointmentChangeDTO
    {
        public int AppointmentChangeID { get; set; }
        public int AppointmentID { get; set; }
        public string ChangeType { get; set; }
        public DateTime Timestamp { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
    }
}
