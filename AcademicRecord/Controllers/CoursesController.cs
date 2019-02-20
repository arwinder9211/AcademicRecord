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
    /// The Course Controller
    /// Contains action method for CRUD operations.
    /// </summary>
    public class CoursesController : Controller
    {
        private ICourseService courseService;
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        /// <summary>
        /// Get List of Courses
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View(courseService.Get());
        }

        /// <summary>
        /// Get Details of selected Course
        /// </summary>
        [HttpGet]
        public IActionResult Details(int id)
        {
            //find by id
            return View(courseService.Get(id));
        }

        /// <summary>
        /// Render view for Adding course
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Save Course to database
        /// </summary>
        [HttpPost]
        public IActionResult Create(Course model)
        {
            //check model is valid or not
            if (ModelState.IsValid)
            {
                //check course exists or not
                var course = courseService.GetByCourseCode(model.CourseCode);
                if (course != null)
                {
                    ViewBag.Error = "Course with this code already exists";
                }
                else
                {
                    //save to database
                    courseService.Add(model);
                    ViewBag.Msg = "Student Created successfully";
                }
            }
            return View();
        }


        /// <summary>
        /// Get selected course for edit
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = courseService.Get(id);
            if (course == null)
            {
                ViewBag.Msg = "Employee with selected ID not found";
            }
            return View(course);
        }

        /// <summary>
        /// Save the updated data 
        /// </summary>
        [HttpPost]
        public IActionResult Edit(int id, Course model)
        {
            try
            {
                var course = courseService.Get(id);
                //get the selected course
                courseService.Edit(id, model);
                ViewBag.Msg = "Edit Successfull";
                return View(course);
            }
            catch
            {
                ViewBag.Error = "Something went wrong please try again..";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            courseService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}