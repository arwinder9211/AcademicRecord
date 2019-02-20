
using AcademicRecord.DAL;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.Services
{
    public interface IAcademicRecordService
    {
        List<AcademicRecords> Get();
        List<AcademicRecords> SortByCourse();
        List<AcademicRecords> SortByStudents();
        void Edit(List<AcademicRecords> model);
        AcademicRecords GetByCourseCodeAndStudentID(int courseCode, int studentId);
        void Add(AcademicRecords model);
    }
    public class AcademicRecordService: IAcademicRecordService
    {
        private IAcademicRecordDAL db;
        public AcademicRecordService(IAcademicRecordDAL _db)
        {
            db = _db;
        }

        /// <summary>
        /// Edit AcademicRecords
        /// </summary>
        public void Edit(List<AcademicRecords> model)
        {
            foreach (var item in model)
            {
                db.Edit(item.ID,item);
            }
        }

        /// <summary>
        /// Get List of AcademicRecords
        /// </summary>
        public List<AcademicRecords> Get()
        {
            return db.Get();
        }

        // sort in ascending order according to Course Title
        public List<AcademicRecords> SortByCourse()
        {
            return db.Get().OrderBy(a => a.Course.Title).ToList();
        }

        // sort in ascending order according to student Name
        public List<AcademicRecords> SortByStudents()
        {
            return db.Get().OrderBy(a => a.Student.Name).ToList();
        }

        /// <summary>
        /// Get List of AcademicRecords by CourseCode and StudentID
        /// </summary>
        public AcademicRecords GetByCourseCodeAndStudentID(int courseCode, int studentId)
        {
            return db.GetByCourseCodeAndStudentID(courseCode, studentId);
        }

        /// <summary>
        ///Save AcademicRecords
        /// </summary>
        public void Add(AcademicRecords model)
        {
            db.Add(model);
        }
    }
}
