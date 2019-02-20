using AcademicRecord.DAL;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.Services
{
    public interface ICourseService
    {
        List<Course> Get();
        Course Get(int id);
        Course GetByCourseCode(int id);
        void Add(Course model);
        void Edit(int id, Course model);
        void Delete(int id);

    }
    public class CourseService : ICourseService
    {
        private ICourseDAL db;
        public CourseService(ICourseDAL _db)
        {
            db = _db;
        }

        //save to database
        public void Add(Course model)
        {
            db.Add(model);
        }

        //delete course from database
        public void Delete(int id)
        {
            db.Delete(id);
        }

        /// <summary>
        /// Edit student
        /// </summary>
        public void Edit(int id, Course model)
        {
            db.Edit(id,model);
        }

        /// <summary>
        /// Get List of Students
        /// </summary>
        public List<Course> Get()
        {
            return db.Get();
        }

        /// <summary>
        /// Get Details of selected Course
        /// </summary>
        public Course Get(int id)
        {
            return db.Get(id);
        }

        /// <summary>
        /// Get Course by  CourseCode
        /// </summary>
        public Course GetByCourseCode(int id)
        {
            return db.GetByCourseCode(id);
        }
    }
}
