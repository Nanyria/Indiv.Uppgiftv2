using System.ComponentModel.DataAnnotations;

namespace IndUppClassModels
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(25)]
        public string PassWord { get; set; }

        public string Role { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        
        
    }
}
