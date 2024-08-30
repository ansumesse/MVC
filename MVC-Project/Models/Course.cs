using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
	public class Course
	{
		public int ID { get; set; }
		[Required]
		[UniqueCrsNameByDepartment]
		[MinLength(3, ErrorMessage ="Name must be at least 3 character")]
		[MaxLength(10, ErrorMessage ="Name must be at most 10 character")]
		public string Crs_Name { get; set; }
		[Range(50, 100)]
		public int Degree { get; set; }
		[Remote("CheckMinDegLessThanDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "Min Degree must be less than Degree")]
        public int MinDegree { get; set; }
		public int? Dep_ID { get; set; }
        public virtual Department? Department { get; set; }
		public virtual List<CrsResult>? CrsResults { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }

    }
}
