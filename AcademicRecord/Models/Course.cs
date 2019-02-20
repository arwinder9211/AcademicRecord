using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.Models
{
    /// <summary>
    /// Course class model
    /// </summary>
    public class Course
    {
        //primary key
        public int ID { get; set; }

        [Display(Name = "Course Code")]
        [Required]
        public int CourseCode { get; set; }

        public string Title { get; set; }

        [Required]
        public Decimal Duration { get; set; }
    }
}
