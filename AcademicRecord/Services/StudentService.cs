using AcademicRecord.DAL;
using AcademicRecord.Data;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.Services
{
    public interface IStudentService
    {
        List<Student> Get();
        Student Get(int id);
        Student GetByStudentID(int id);
        void Add(Student model);
        void Edit(int id, Student model);
        void Delete(int id);

    }
    public class StudentService : IStudentService
    {
        private IStudentDAL db;
        public StudentService(IStudentDAL _db)
        {
            db = _db;
        }
        public List<Student> Get()
        {
            return db.Get();
        }

        public Student Get(int id)
        {
            return db.Get(id);
        }

        /// <summary>
        /// Get Student By StudentID
        /// </summary>
        public Student GetByStudentID(int id)
        {
            return db.GetByStudentID(id);
        }

        /// <summary>
        /// Save student
        /// </summary>
        public void Add(Student model)
        {
            //save to database
            db.Add(model);
        }

        /// <summary>
        /// Edit student
        /// </summary>
        public void Edit(int id, Student model)
        {
            db.Edit(id, model);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
