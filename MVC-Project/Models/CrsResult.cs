namespace MVC_Project.Models
{
	public class CrsResult
	{
		public int ID { get; set; }
		public int Degree { get; set; }
		public int? Trainee_ID { get; set; }
        public virtual Trainee? Trainee { get; set; }
        public int? Crs_ID { get; set; }
        public virtual Course? Course { get; set; }
    }
}
