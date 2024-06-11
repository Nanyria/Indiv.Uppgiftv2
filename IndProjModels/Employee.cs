using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndUppClassModels
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string EFirstName { get; set; }
        [Required]
        public string ELastName { get; set; }
        [Required]
        public string EPassWord {  get; set; }
    }
}
