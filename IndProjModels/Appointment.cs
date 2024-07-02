
using IndProjModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IndUppClassModels
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public List<AppointmentChanges> Changes { get; set; } = new List<AppointmentChanges>();

        // Helper method to add a change
        public void AddChange(AppointmentChanges change)
        {
            if (Changes == null)
            {
                Changes = new List<AppointmentChanges>();
            }
            Changes.Add(change);
        }
    }
}

   



