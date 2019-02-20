using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicRecord.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AcademicRecord.Models;
using AcademicRecord.Services;

namespace AcademicRecord.Controllers
{
    /// <summary>
    /// The Academic Records Controller
    /// Contains action method for CRUD operations.
    /// </summary>
    public class AcademicRecordsController : Controller
    {
        private IAcademicRecordService academicRecordService;
        private ICourseService courseService;
        private IStudentService studentService;
        public AcademicRecordsController(IAcademicRecordService _academicRecordService, ICourseService _courseService, IStudentService _studentService)
        {
            academicRecordService = _academicRecordService;
            studentService = _studentService;
            courseService = _courseService;
        }


        /// <summary>
        /// Get List of Academic Records and pass it to its view.
        /// And sort the records acc to sort parameter i.e course or students
        /// </summary>
        public IActionResult Index(string sortOrder)
        {
           
            // if sortOrder is empty then get unordered list
            if (String.IsNullOrEmpty(sortOrder))
            {
                return View(academicRecordService.Get());
            }
            else
            {
                // if sortOrder is Course then sort in ascending order according to course
                if (sortOrder=="Course")
                {
                    return View(academicRecordService.SortByCourse());
                }
                else
                {
                    // if sortOrder is Student then sort in ascending order according to student
                    if (sortOrder == "Student")
                    {
                        return View(academicRecordService.SortByStudents());
                    }
                    // for all the other cases get unordered list of records 
                    else
                    {
                        return View(academicRecordService.Get());
                    }
                }
            }
        }

        [HttpPost]
        /// <summary>
        /// Update grades of all acdemic records
        /// </summary>
        public IActionResult Index(List<AcademicRecords> model)
        {
            try
            {
                academicRecordService.Edit(model);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Render view for adding academic records
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            // get students for dropdown
            ViewBag.Students = studentService.Get();
            // get courses for dropdown
            ViewBag.Courses = courseService.Get();
            return View();
        }

        /// <summary>
        /// Save student in database
        /// </summary>
        [HttpPost]
        public IActionResult Create(AcademicRecords model)
        {
            ViewBag.Students = studentService.Get();
            ViewBag.Courses = courseService.Get();
            //check model is valid or not
            if (ModelState.IsValid)
            {
                //if academic record of students for a course exists or not
                var course = academicRecordService.GetByCourseCodeAndStudentID(model.CourseCode,model.StudenID);
                if (course != null)
                {
                    
                    ViewBag.Error = "The academic record of this student for this course already exists";
                    return View();
                }
                else
                {
                    // add record to database
                    academicRecordService.Add(model);
                    ViewBag.Msg = "Academic Record Created successfully";
                    return View();
                }
            }
            return RedirectToAction("Create");
        }
    }
}