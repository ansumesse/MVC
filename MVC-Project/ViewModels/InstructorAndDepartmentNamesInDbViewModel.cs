using MVC_Project.Models;

namespace MVC_Project.ViewModels
{
    public class InstructorAndDepartmentNamesInDbViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public int? Dep_ID { get; set; }
        public int? Crs_ID { get; set; }

        public Dictionary<int, string> DepIdNames { get; set; }
        public Dictionary<int, string> CrsIdNames { get; set; }
    }
}
