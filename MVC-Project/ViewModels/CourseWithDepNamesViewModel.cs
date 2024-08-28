using MVC_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class CourseWithDepNamesViewModel
    {
        public int Crs_ID { get; set; }
        [Display(Name = "Course Name")]
        public string Crs_Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        [Display(Name = "Department")]
        public int? Dep_ID { get; set; }
        public List<Department> Departments { get; set; }
    }
}
