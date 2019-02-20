using AcademicRecord.Data;
using AcademicRecord.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.DAL
{
    public interface IAcademicRecordDAL
    {
        List<AcademicRecords> Get();
        void Edit(int id, AcademicRecords model);
        AcademicRecords GetByCourseCodeAndStudentID(int courseCode, int studentId);
        void Add(AcademicRecords model);
    }
    public class AcademicRecordDAL: IAcademicRecordDAL
    {
        private ApplicationDbContext db;
        public AcademicRecordDAL(ApplicationDbContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Edit AcademicRecords
        /// </summary>
        public void Edit(int id, AcademicRecords model)
        {
            var record = db.AcademicRecords.FirstOrDefault(m => m.ID == id);
            record.Grade = model.Grade;
            db.SaveChanges();
        }

        /// <summary>
        /// Get List of AcademicRecords
        /// </summary>
        public List<AcademicRecords> Get()
        {
            return db.AcademicRecords.Include(a => a.Student).Include(a => a.Course).ToList();
        }

        /// <summary>
        /// Get List of AcademicRecords by CourseCode and StudentID
        /// </summary>
        public AcademicRecords GetByCourseCodeAndStudentID(int courseCode, int studentId)
        {
            return db.AcademicRecords.FirstOrDefault(e => e.CourseCode == courseCode && e.StudenID == studentId);
        }

        /// <summary>
        /// Save AcademicRecords
        /// </summary>
        public void Add(AcademicRecords model)
        {
            db.AcademicRecords.Add(model);
            db.SaveChanges();
        }
    }
}
