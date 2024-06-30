using IndUppClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IndProjModels
{
    public class AppointmentChanges
    {
        public int AppointmentChangeID { get; set; }
        public int AppointmentID { get; set; }
        [JsonIgnore]
        public Appointment Appointment { get; set; }
        public DateTime Timestamp { get; set; }
        public string ChangeType { get; set; }
        public string Field { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
    }
}
