using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using WebApplication1;

namespace WebApplication1.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    Context context = new Context(); 
        //    String Name = value.ToString();
        //    Course CourseFromRequest = validationContext.ObjectInstance as Course;
        //    if (CourseFromRequest == null)
        //    {
        //        Course CrsFromEditRequest = validationContext.ObjectInstance as Course;

        //        Course courseFromDB = context.courses
        //                              .FirstOrDefault(C => C.Name == Name && C.dept_id == CrsFromEditRequest.dept_id && C.Id != CrsFromEditRequest.Id) ;
        //        if (courseFromDB == null)
        //        {
        //            return ValidationResult.Success;
        //        }
        //        return new ValidationResult("Name Already Found");
        //    }
        //    else
        //    {
        //        Course CrsFromDb = context.courses.FirstOrDefault(c => c.Name == Name && c.dept_id == CourseFromRequest.dept_id);
        //        if (CrsFromDb == null)
        //        {
        //            return ValidationResult.Success;
        //        }
        //        return new ValidationResult("There is Already Course with This Name in The Department");
        //    }
        //}


    }
}

