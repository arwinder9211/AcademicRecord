using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcademicRecord.Models
{
    /// <summary>
    /// Employee model
    /// </summary>
    public class Employee
    {
        //primary key
        public int ID { get; set; }
        [Display(Name = "Employee Number")]
        [Required]
        public int EmployeeCode { get; set; }

        [Required]
        public string  Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}