
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndUppClassModels
{
    public class Appointment
    {

        public int AppointmentID { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        //public Appointment(int appointmentID, DateTime date, DateTime startTime, int customerID, Customer customer)
        //{
        //    AppointmentID = appointmentID;
        //    Date = date.Date; // Store only the date part
        //    StartTime = startTime;
        //    EndTime = startTime.AddHours(1); // EndTime is always one hour after StartTime
        //    CustomerID = customerID;
        //    Customer = customer;
        //}
    }

}
