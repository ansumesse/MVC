using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using System.Net;

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
		[HttpGet]
		public IActionResult New()
		{
			var InstructorDeprtCrs = new InstructorAndDepartmentNamesInDbViewModel()
			{
				DepIdNames = context.Departments.Select(x => new {x.ID, x.Name}).ToDictionary(x => x.ID, x => x.Name),
                CrsIdNames = context.Courses.Select(x => new {x.ID, x.Name}).ToDictionary(x => x.ID, x => x.Name),
			};
			return View(InstructorDeprtCrs);
		}
		[HttpPost]
		public IActionResult SaveNew(Instructor newInstr)
		{
			if (newInstr.Name != null)
			{
				context.Instructors.Add(new Instructor()
				{
					Name = newInstr.Name,
					Address = newInstr.Address,
					Crs_ID = newInstr.Crs_ID,
					Dep_ID = newInstr.Dep_ID,
					Image = newInstr.Image,
					Salary = newInstr.Salary
				});
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
				return RedirectToAction("New");

		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Instructor instraEdited = context.Instructors.FirstOrDefault(x => x.ID == id);
			var instrinformation = new InstructorAndDepartmentNamesInDbViewModel()
			{
				ID = instraEdited.ID,
				Name = instraEdited.Name,
				Address = instraEdited.Address,
				Crs_ID = instraEdited.Crs_ID,
				Dep_ID = instraEdited.Dep_ID,
				Image = instraEdited.Image,
				Salary = instraEdited.Salary,
				DepIdNames = context.Departments.Select(x => new { x.ID, x.Name }).ToDictionary(x => x.ID, x => x.Name),
				CrsIdNames = context.Courses.Select(x => new { x.ID, x.Name }).ToDictionary(x => x.ID, x => x.Name)
			};

            return View(instrinformation);
		}
		[HttpPost]
		public IActionResult SaveEdit(int id, Instructor newInstr)
		{
			if (newInstr.Name != null)
			{
				Instructor oldInstr = context.Instructors.FirstOrDefault(x => x.ID == id);
				if (oldInstr != null)
				{
					oldInstr.Name = newInstr.Name;
					oldInstr.Address = newInstr.Address;
					oldInstr.Crs_ID = newInstr.Crs_ID;
					oldInstr.Dep_ID = newInstr.Dep_ID;
					oldInstr.Image = newInstr.Image;
                    oldInstr.Salary = newInstr.Salary;
					context.SaveChanges();
					return RedirectToAction("Index");
                }
			}
			return RedirectToAction("Edit", newInstr);
		}

    }
}
