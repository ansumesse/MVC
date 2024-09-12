using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.Reposetory;
using MVC_Project.ViewModels;
using System.Net;

namespace MVC_Project.Controllers
{
	[Authorize]
	public class InstructorController : Controller
	{
		IInstructorRepo InstructorRepo;

        public InstructorController(IInstructorRepo instructorRepo)
        {
			this.InstructorRepo = instructorRepo;
        }
        public IActionResult Index()
		{
			List<Instructor> instructors = InstructorRepo.GetAll();
			return View(instructors);
		}
		public IActionResult Details(int id)
		{
			Instructor instructor = InstructorRepo.GetById(id);
			return View(instructor);
		}
		[HttpGet]
		public IActionResult New()
		{
			var InstructorDeprtCrs = new InstructorAndDepartmentNamesInDbViewModel()
			{
				DepIdNames = InstructorRepo.GetAllDepartments(),
                CrsIdNames = InstructorRepo.GetAllCourses()
			};
			return View(InstructorDeprtCrs);
		}
		[HttpPost]
		public IActionResult SaveNew(Instructor newInstr)
		{
			if (newInstr.Name != null)
			{
				InstructorRepo.Add(newInstr);
				return RedirectToAction("Index");
			}
			else
				return RedirectToAction("New");

		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Instructor instraEdited = InstructorRepo.GetById(id);
			var instrinformation = new InstructorAndDepartmentNamesInDbViewModel()
			{
				ID = instraEdited.ID,
				Name = instraEdited.Name,
				Address = instraEdited.Address,
				Crs_ID = instraEdited.Crs_ID,
				Dep_ID = instraEdited.Dep_ID,
				Image = instraEdited.Image,
				Salary = instraEdited.Salary,
				DepIdNames = InstructorRepo.GetAllDepartments(),
				CrsIdNames = InstructorRepo.GetAllCourses()
			};

            return View(instrinformation);
		}
		[HttpPost]
		public IActionResult SaveEdit(int id, Instructor newInstr)
		{
			if (newInstr.Name != null)
			{
				Instructor oldInstr = InstructorRepo.GetById(id);
				if (oldInstr != null)
				{
					InstructorRepo.Edit(id, newInstr);
					return RedirectToAction("Index");
                }
			}
			return RedirectToAction("Edit", newInstr.ID);
		}

    }
}
