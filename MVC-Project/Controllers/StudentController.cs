using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        StudentsSample studentsSample = new StudentsSample();
        public IActionResult Details(int id)
        {
            var student = studentsSample.GetSudentById(id);
            return View("SudentView", student);
        }
        public IActionResult Index()
        {
            var students = studentsSample.Students;
            return View("AllSudentsView", students);
        }
    }
}
