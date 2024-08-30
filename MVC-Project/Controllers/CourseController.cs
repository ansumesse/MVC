using Microsoft.AspNetCore.Mvc;
using MVC_Project.Migrations;
using MVC_Project.Models;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class CourseController : Controller
    {
        TrainingAppDbContext context = new TrainingAppDbContext();
        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }
        public IActionResult Edit(int id)
        {
            Course course = context.Courses.FirstOrDefault(x => x.ID == id);
            CourseWithDepNamesViewModel courseEdited = new CourseWithDepNamesViewModel()
            {
                Crs_ID = course.ID,
                Crs_Name = course.Crs_Name,
                MinDegree = course.MinDegree,
                Degree = course.Degree,
                Dep_ID = course.Dep_ID,
                Departments = context.Departments.ToList()
            };
            return View(courseEdited);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Course editedCourse)
        {
            if(editedCourse.Crs_Name != null)
            {
                Course oldCourse = context.Courses.FirstOrDefault(x => x.ID == id);
                oldCourse.Crs_Name = editedCourse.Crs_Name;
                oldCourse.Dep_ID = editedCourse.Dep_ID;
                oldCourse.Degree = editedCourse.Degree;
                oldCourse.MinDegree = editedCourse.MinDegree;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", editedCourse);

        }
        public IActionResult New()
        {
            CourseWithDepNamesViewModel courseVM = new CourseWithDepNamesViewModel()
            {
                Departments = context.Departments.ToList()
            };
            return View(courseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course course)
        {
            if(ModelState.IsValid)
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            CourseWithDepNamesViewModel courseVM = new CourseWithDepNamesViewModel()
            {
                Crs_Name = course.Crs_Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                Dep_ID = course.Dep_ID,
                Departments = context.Departments.ToList()
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
            var course = context.Courses.FirstOrDefault(c => c.ID == id);
            context.Courses.Remove(course);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
