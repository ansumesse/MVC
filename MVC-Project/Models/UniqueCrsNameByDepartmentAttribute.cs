using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class UniqueCrsNameByDepartmentAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();
            Course newCourse = (Course)validationContext.ObjectInstance;
            using (TrainingAppDbContext context = new TrainingAppDbContext())
            {
                Course course = context.Courses.FirstOrDefault(c => c.Crs_Name == name && c.Dep_ID == newCourse.Dep_ID);
                if (course is null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Course Name is already exists");
            }
            
        }
    }
}
