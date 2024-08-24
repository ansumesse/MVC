using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using System.Text.Json;
namespace MVC_Project.Controllers
{
    public class TraineeController : Controller
    {
        TrainingAppDbContext Context = new TrainingAppDbContext();
        public IActionResult Courses(int id)
        {
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

            // Create TempData
            //TempData.Add("trainee subject", "traineeDetails");

            // Create Cookies
            string str = JsonSerializer.Serialize(traineeDetails);
            Response.Cookies.Append("trainee", str);

            // Create Session
            HttpContext.Session.SetString("key", "my name is Mohamed");

            return View(traineeDetails);
        }
        public IActionResult Details(int id , string crsName)
        {
            var traineeDetails = JsonSerializer.Deserialize<List<TraineeNameAndCrsNameAndDegreeViewModel>>( Request.Cookies["trainee"])
                .FirstOrDefault(x => x.Id == id && x.CrsName == crsName);
            return View(traineeDetails);
        }
        
        public IActionResult NewCourse()
        {
            return View();
        }
        
    }
}
