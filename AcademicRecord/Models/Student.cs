using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcademicRecord.Models
{
    /// <summary>
    /// Student model
    /// </summary>
    public class Student
    {
        //primary key
        public int ID { get; set; }

        [Display(Name = "StudentID")]
        [Required]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }
}