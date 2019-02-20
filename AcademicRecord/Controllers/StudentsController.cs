using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicRecord.DAL;
using AcademicRecord.Data;
using AcademicRecord.Models;
using AcademicRecord.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademicRecord.Controllers
{
    /// <summary>
    /// The Student Controller
    /// Contains action method for CRUD operations.
    /// </summary>
    public class StudentsController : Controller
    {
        private IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Get List of Students
        /// </summary>
        public IActionResult Index()
        {
            return View(studentService.Get());
        }

        /// <summary>
        /// Get Details of selected Student
        /// </summary>
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(studentService.Get(id));
        }

        /// <summary>
        /// Render view for Adding Student
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Save Student to database
        /// </summary>
        [HttpPost]
        public IActionResult Create(Student model)
        {
            //check model is valid or not
            if (ModelState.IsValid)
            {
                //check employee exists or not
                var student = studentService.GetByStudentID(model.StudentID);
                if (student != null)
                {
                    ViewBag.Error = "Student with this code already exists";
                }
                else
                {
                    //save to database
                    studentService.Add(model);
                    ViewBag.Msg = "Student Created sucessfully";
                }
            }
            return View();
        }

        /// <summary>
        /// Get selected Student for edit
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = studentService.Get(id);
            if (student == null)
            {
                ViewBag.Msg = "Employee with selected ID not found";
            }
            return View(student);
        }

        /// <summary>
        /// Save the updated data 
        /// </summary>
        [HttpPost]
        public IActionResult Edit(int id, Student model)
        {
            try
            {
                studentService.Edit(id, model);
                ViewBag.Msg = "Edit Successfull";
                var student = studentService.Get(id);
                return View(student);
            }
            catch
            {
                //if error show error message
                ViewBag.Error = "Something went wrong please try again..";
                return View();
            }
        }

        /// <summary>
        /// Delete selected Student
        /// </summary
        [HttpGet]
        public IActionResult Delete(int id)
        {
            studentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}