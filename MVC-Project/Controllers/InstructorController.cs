using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
	public class InstructorController : Controller
	{
		TrainingAppDbContext context = new TrainingAppDbContext();
		public IActionResult Index()
		{
			List<Instructor> instructors = context.Instructors.ToList();
			return View(instructors);
		}
		public IActionResult Details(int id)
		{
			Instructor instructor = context.Instructors.FirstOrDefault(x => x.ID == id);
			return View(instructor);
		}
	}
}
