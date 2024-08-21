namespace MVC_Project.Models
{
	public class Department
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<Course>? Courses { get; set; }
        public virtual List<Trainee>? Trainees { get; set; }
    }
}
