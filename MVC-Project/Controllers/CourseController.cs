using Microsoft.AspNetCore.Mvc;
using MVC_Project.Migrations;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using MVC_Project.Reposetory;

namespace MVC_Project.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepo context;
        
        public CourseController(ICourseRepo courseRepo)
        {
            context = courseRepo;
        }
        public IActionResult Index()
        {
            var courses = context.GetAll();
            context.GetAllDepartments();
            return View(courses);
        }
        public IActionResult Edit(int id)
        {
            Course course = context.GetById(id);
            CourseWithDepNamesViewModel courseEdited = new CourseWithDepNamesViewModel()
            {
                Crs_ID = course.ID,
                Crs_Name = course.Crs_Name,
                MinDegree = course.MinDegree,
                Degree = course.Degree,
                Dep_ID = course.Dep_ID,
                Departments = context.GetAllDepartments()
            };
            return View(courseEdited);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Course editedCourse)
        {
            if(ModelState.IsValid)
            {
                context.Edit(id, editedCourse);
                return RedirectToAction("Index");
            }
            CourseWithDepNamesViewModel courseVM = new CourseWithDepNamesViewModel()
            {
                Crs_ID = editedCourse.ID,
                Crs_Name = editedCourse.Crs_Name,
                MinDegree = editedCourse.MinDegree,
                Degree = editedCourse.Degree,
                Dep_ID = editedCourse.Dep_ID,
                Departments = context.GetAllDepartments()
            };
            return View("Edit", courseVM);

        }
        public IActionResult New()
        {
            CourseWithDepNamesViewModel courseVM = new CourseWithDepNamesViewModel()
            {
                Departments = context.GetAllDepartments()
            };
            return View(courseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course course)
        {
            if(ModelState.IsValid)
            {
                context.Add(course);
                return RedirectToAction("Index");
            }
            CourseWithDepNamesViewModel courseVM = new CourseWithDepNamesViewModel()
            {
                Crs_Name = course.Crs_Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                Dep_ID = course.Dep_ID,
                Departments = context.GetAllDepartments()
            };
            return View("New", courseVM);
        }
        public IActionResult CheckMinDegLessThanDegree(int MinDegree, int Degree)
        {
            if (MinDegree < Degree)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Delete(int id)
        {
            context.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
