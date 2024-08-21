namespace MVC_Project.Models
{
    public class StudentsSample
    {
        List<Student> std = new List<Student>();
        public List<Student> Students { get => std; set => std = value; }
        public StudentsSample()
        {
            Students.Add(new Student() { Id = 1, Name = "Ahemd", Address = "Cairo", Image = "s1.jpg" });
            Students.Add(new Student() { Id = 2, Name = "Ahemd", Address = "Cairo", Image = "s2.jpg" });
            Students.Add(new Student() { Id = 3, Name = "Ali", Address = "Cairo", Image = "s3.jpg" });
            Students.Add(new Student() { Id = 4, Name = "Ahemd", Address = "Cairo", Image = "s4.jpg" });
            Students.Add(new Student() { Id = 5, Name = "Ahemd", Address = "Cairo", Image = "s5.jpg" });
        }
        
        public Student GetSudentById(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }
    }
}
