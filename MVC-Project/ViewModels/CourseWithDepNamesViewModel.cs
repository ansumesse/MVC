using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class CourseWithDepNamesViewModel
    {
        public int Crs_ID { get; set; }
        [Display(Name = "Course Name")]
        [Required]
        [UniqueCrsNameByDepartment]
        [MinLength(3, ErrorMessage = "Name must be at least 3 character")]
        [MaxLength(10, ErrorMessage = "Name must be at most 10 character")]
        public string Crs_Name { get; set; }
        [Range(50, 100)]
        public int Degree { get; set; }
        [Remote("CheckMinDegLessThanDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "Min Degree must be less than Degree")]
        public int MinDegree { get; set; }
        [Display(Name = "Department")]
        public int? Dep_ID { get; set; }
        public List<Department> Departments { get; set; }
    }
}
