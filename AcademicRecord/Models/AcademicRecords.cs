using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcademicRecord.Models
{
    /// <summary>
    /// AcademicRecords model class 
    /// </summary>
    public class AcademicRecords
    {
        //primary key
        public int ID { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Display(Name = "Course")]
        public int CourseCode { get; set; }
        public Course Course { get; set; }

        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudenID { get; set; }
        public Student Student { get; set; }

        [Required]
        [Display(Name = "Percentage")]
        public Decimal Grade { get; set; }
    }
}