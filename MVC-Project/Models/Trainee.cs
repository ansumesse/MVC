namespace MVC_Project.Models
{
	public class Trainee
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string? Image { get; set; }
		public string? Address { get; set; }
        public int Degree { get; set; }
		public int? Dep_ID { get; set; }
        public virtual Department? Department { get; set; }
		public virtual List<CrsResult>? CrsResults { get; set; }
	}
}
