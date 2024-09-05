using MVC_Project.Models;

namespace MVC_Project.Reposetory
{
    public interface IInstructorRepo
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor newInstructor);
        void Edit(int id, Instructor newInstructor);
        void Delete(int id);
        Dictionary<int, string> GetAllDepartments();
        Dictionary<int, string> GetAllCourses();
    }
}
