namespace MVC_Project.Models
{
	public class Course
	{
		public int ID { get; set; }
		public string Crs_Name { get; set; }
		public int Degree { get; set; }
        public int MinDegree { get; set; }
		public int? Dep_ID { get; set; }
        public virtual Department? Department { get; set; }
		public virtual List<CrsResult>? CrsResults { get; set; }
        public virtual List<Instructor> Instructors { get; set; }

    }
}
