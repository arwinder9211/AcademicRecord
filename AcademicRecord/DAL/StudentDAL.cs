using AcademicRecord.Data;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.DAL
{
    public interface IStudentDAL
    {
        List<Student> Get();
        Student Get(int id);
        Student GetByStudentID(int id);
        void Add(Student model);
        void Edit(int id, Student model);
        void Delete(int id);

    }
    public class StudentDAL : IStudentDAL
    {
        private ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext _db)
        {
            db = _db;
        }
        /// <summary>
        /// Get List of Students
        /// </summary>
        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        /// <summary>
        /// Get Details of selected Student
        /// </summary>
        public Student Get(int id)
        {
            return db.Students.FirstOrDefault(s => s.ID == id);
        }

        /// <summary>
        /// Get Student By StudentID
        /// </summary>
        public Student GetByStudentID(int id)
        {
            return db.Students.FirstOrDefault(e => e.StudentID == id);
        }

        /// <summary>
        /// Save student
        /// </summary>
        public void Add(Student model)
        {
            //save to database
            db.Students.Add(model);
            db.SaveChanges();
        }

        /// <summary>
        /// Edit student
        /// </summary>
        public void Edit(int id,Student model)
        {
            //get the selected Student
            var student = db.Students.FirstOrDefault(e => e.ID == id);
            student.Age = model.Age;
            student.Email = model.Email;
            student.Name = model.Name;
            student.StudentID = model.StudentID;
            student.Sex = model.Sex;
            //save the updated Student
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = db.Students.FirstOrDefault(e => e.ID == id);
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
