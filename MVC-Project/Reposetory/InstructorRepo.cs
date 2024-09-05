using MVC_Project.Models;

namespace MVC_Project.Reposetory
{
    public class InstructorRepo : IInstructorRepo
    {
        TrainingAppDbContext context;
        public InstructorRepo(TrainingAppDbContext db)
        {
            context = db;
        }
        public void Add(Instructor newInstructor)
        {
            context.Instructors.Add(newInstructor);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Edit(int id, Instructor newInstructor)
        {
            var oldInstr = context.Instructors.FirstOrDefault(i => i.ID == id);
            oldInstr.Name = newInstructor.Name;
            oldInstr.Address = newInstructor.Address;
            oldInstr.Crs_ID = newInstructor.Crs_ID;
            oldInstr.Dep_ID = newInstructor.Dep_ID;
            oldInstr.Image = newInstructor.Image;
            oldInstr.Salary = newInstructor.Salary;
            context.SaveChanges();
        }

        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }

        public Dictionary<int, string> GetAllCourses()
        {
            return context.Courses.Select(x => new { x.ID, x.Crs_Name }).ToDictionary(x => x.ID, x => x.Crs_Name);
        }

        public Dictionary<int, string> GetAllDepartments()
        {
            return context.Departments.Select(x => new { x.ID, x.Name }).ToDictionary(x => x.ID, x => x.Name);
        }

        public Instructor GetById(int id)
        {
            return context.Instructors.FirstOrDefault(i => i.ID == id);
        }
    }
}
