using AcademicRecord.Data;
using AcademicRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicRecord.DAL
{
    public interface IEmployeeDAL
    {
        List<Employee> Get();
        Employee Get(int id);
        Employee GetByEmployeeID(int id);
        void Add(Employee model);
        void Edit(int id, Employee model);
        void Delete(int id);
    }
    public class EmployeeDAL : IEmployeeDAL
    {
        private ApplicationDbContext db;
        public EmployeeDAL(ApplicationDbContext _db)
        {
            db = _db;
        }
        /// <summary>
        /// Get List of Employee
        /// </summary>
        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        /// <summary>
        /// Get Details of selected Employee
        /// </summary>
        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(s => s.ID == id);
        }

        /// <summary>
        /// Get Employee By EmployeeID
        /// </summary>
        public Employee GetByEmployeeID(int id)
        {
            return db.Employees.FirstOrDefault(e => e.EmployeeCode == id);
        }

        /// <summary>
        /// Save Employee
        /// </summary>
        public void Add(Employee model)
        {
            //save to database
            db.Employees.Add(model);
            db.SaveChanges();
        }

        /// <summary>
        /// Edit Employee
        /// </summary>
        public void Edit(int id, Employee model)
        {
            //get the selected Employee
            var employee = db.Employees.FirstOrDefault(e => e.ID == id);
            employee.Age = model.Age;
            employee.Email = model.Email;
            employee.Name = model.Name;
            employee.EmployeeCode = model.EmployeeCode;
            employee.Sex = model.Sex;
            //save the updated Student
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = db.Employees.FirstOrDefault(e => e.ID == id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
