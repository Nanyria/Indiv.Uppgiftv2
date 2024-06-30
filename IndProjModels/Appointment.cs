
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
        public DateTime Date { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        [JsonIgnore] // Exclude from JSON serialization
        public List<AppointmentChanges> Changes { get; set; }

        // Constructor to ensure Changes is always initialized
        public Appointment()
        {
            Changes = new List<AppointmentChanges>();
        }

        // Helper method to add a change
        public void AddChange(AppointmentChanges change)
        {
            Changes.Add(change);
        }
    }
}

   



