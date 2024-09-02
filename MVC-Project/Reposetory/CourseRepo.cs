using MVC_Project.Models;

namespace MVC_Project.Reposetory
{
    public class CourseRepo: ICourseRepo
    {
        TrainingAppDbContext context = new TrainingAppDbContext();

        public void Add(Course newCourse)
        {
            context.Courses.Add(newCourse);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Courses.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Edit(int id, Course newCourse)
        {
            Course course = GetById(id);
            course.Dep_ID = newCourse.Dep_ID;
            course.Crs_Name = newCourse.Crs_Name;
            course.Degree = newCourse.Degree;
            course.MinDegree = newCourse.MinDegree;
            context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(c => c.ID == id);
            
        }
        public List<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }
    }
}
