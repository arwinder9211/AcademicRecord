using AcademicRecord.DAL;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.Services
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee Get(int id);
        Employee GetByEmployeeID(int id);
        void Add(Employee model);
        void Edit(int id, Employee model);
        void Delete(int id);
    }
    public class EmployeeService: IEmployeeService
    {
        private IEmployeeDAL db;
        public EmployeeService(IEmployeeDAL _db)
        {
            db = _db;
        }

        /// <summary>
        /// Get List Course
        /// </summary>
        public List<Employee> Get()
        {
            return db.Get();
        }

        public Employee Get(int id)
        {
            return db.Get(id);
        }

        /// <summary>
        /// Get Employee By EmployeeCode
        /// </summary>
        public Employee GetByEmployeeID(int id)
        {
            return db.GetByEmployeeID(id);
        }

        /// <summary>
        /// Save Employee
        /// </summary>
        public void Add(Employee model)
        {
            //save to database
            db.Add(model);
        }

        /// <summary>
        /// Edit Employee
        /// </summary>
        public void Edit(int id, Employee model)
        {
            db.Edit(id, model);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

    }
}
