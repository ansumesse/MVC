using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class TraineeController : Controller
    {
        TrainingAppDbContext Context = new TrainingAppDbContext();
        public IActionResult Details(int id)
        {
            //Trainee trainee = Context.Trainees.FirstOrDefault(x => x.ID == id);
            //Course course = Context.Courses.FirstOrDefault(x => x.Name == "C#");
            //CrsResult result = Context.CrsResults.FirstOrDefault(x => x.Trainee_ID == id && x.Crs_ID == course.ID);
            //TraineeNameAndCrsNameAndDegreeViewModel traineeDetails = new TraineeNameAndCrsNameAndDegreeViewModel()
            //{
            //    Id = id,
            //    Name = trainee.Name,
            //    CrsName = course.Name,
            //    Degree = result.Degree,
            //    Color = result.Degree > course.MinDegree ? "green" : "red"
            //};
            var traineeDetails = Context.Trainees.Join(
                Context.CrsResults,
                t => t.ID,
                cr => cr.Trainee_ID,
                (t, cr) => new { t.ID, t.Name, cr.Crs_ID, cr.Degree })
                .Join(
                Context.Courses,
                x => x.Crs_ID,
                cr => cr.ID,
                (x, cr) => new TraineeNameAndCrsNameAndDegreeViewModel
                {
                    Id = x.ID,
                    Name = x.Name,
                    CrsName = cr.Name,
                    Degree = x.Degree,
                    Color = x.Degree > cr.MinDegree ? "green" : "red"
                }
                ).Where(x => x.Id == id).ToList();
            return View(traineeDetails);
        }
        
    }
}
