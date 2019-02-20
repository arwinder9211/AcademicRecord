using AcademicRecord.Data;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.DAL
{
    public interface ICourseDAL
    {
        List<Course> Get();
        Course Get(int id);
        Course GetByCourseCode(int id);
        void Add(Course model);
        void Edit(int id, Course model);
        void Delete(int id);

    }
    public class CourseDAL : ICourseDAL
    {
        private ApplicationDbContext db;
        public CourseDAL(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void Add(Course model)
        {
            db.Courses.Add(model);
        }

        //delete course from database
        public void Delete(int id)
        {
            var course = db.Courses.FirstOrDefault(e => e.ID == id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        /// <summary>
        /// Edit Course
        /// </summary>
        public void Edit(int id, Course model)
        {
            //get the selected Course student
            var course = db.Courses.FirstOrDefault(e => e.ID == id);
            course.CourseCode = model.CourseCode;
            course.Duration = model.Duration;
            course.Title = model.Title;
            //save the updated course
            db.SaveChanges();
        }

        /// <summary>
        /// Get List of Students
        /// </summary>
        public List<Course> Get()
        {
            return db.Courses.ToList();
        }

        /// <summary>
        /// Get Details of selected Course
        /// </summary>
        public Course Get(int id)
        {
            return db.Courses.FirstOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// Get Course by  CourseCode
        /// </summary>
        public Course GetByCourseCode(int id)
        {
            return db.Courses.FirstOrDefault(c => c.CourseCode == id);
        }
    }
}
