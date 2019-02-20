using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicRecord.Data;
using AcademicRecord.Models;
using AcademicRecord.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademicRecord.Controllers
{
    /// <summary>
    /// The Employees Controller
    /// Contains action method for CRUD operations.
    /// </summary>
    public class EmployeesController : Controller
    {
        private IEmployeeService employeeService;
        public EmployeesController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        /// <summary>
        /// Get List of Employees
        /// </summary>
        public IActionResult Index()
        {
            return View(employeeService.Get());
        }

        /// <summary>
        /// Get Details of selected Employee
        /// </summary>
        [HttpGet]
        public IActionResult Details(int id)
        {
            //find by id
            return View(employeeService.Get(id));
        }

        /// <summary>
        /// Render view for Adding Employee
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Save Employee to database
        /// </summary>
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            //check model is valid or not
            if (ModelState.IsValid)
            {
                //check employee exists or not
                var employee = employeeService.GetByEmployeeID(model.EmployeeCode);
                if (employee != null)
                {
                    ViewBag.Error = "Employee with this code already exists";
                }
                else
                {
                    //save to database
                    employeeService.Add(model);
                    ViewBag.Msg = "Employee Create sucessfully";
                }
            }
            return View();
        }

        /// <summary>
        /// Get selected employees for edit
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeService.Get(id);
            if (employee == null)
            {
                ViewBag.Msg = "Employee with selected ID not found";
            }
            return View(employee);
        }

        /// <summary>
        /// Save the updated data 
        /// </summary>
        [HttpPost]
        public IActionResult Edit(int id, Employee model)
        {
            try
            {
                //get the selected Employee
                var employee = employeeService.Get(id);
                employeeService.Edit(id, model);
                ViewBag.Msg = "Edit Successfull";
                return View(employee);
            }
            catch
            {
                ViewBag.Error = "Something went wrong please try again..";
                return View();
            }
        }


        /// <summary>
        /// Delete selected Employee
        /// </summary
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //delete Employee
            employeeService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}