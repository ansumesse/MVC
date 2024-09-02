using MVC_Project.Models;

namespace MVC_Project.Reposetory
{
    public interface ICourseRepo : IRepo
    {
        List<Department> GetAllDepartments();
    }
}
