namespace MVC_Project.Models
{
	public class Instructor
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public int? Dep_ID { get; set; }
        public virtual Department? Department { get; set; }
        public int? Crs_ID { get; set; }
        public virtual Course? Course { get; set; }
    }
}
