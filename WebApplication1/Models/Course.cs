using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [
            Required ,
            MaxLength (20 , ErrorMessage = "Msut Be Less Than 20 Letters") ,
            MinLength (2 , ErrorMessage = "Must Be More Than 2 Letters") ,
            ]
      //  [Required , StringLength (20 , MinimumLength =2 ) ]
        public string Name { get; set; }
        [Required , Range (50 , 100 , ErrorMessage = "Must Be between 50 && 100")]
        public int Degree { get; set; }
        [Required]
        [Remote ("CheckMinDegree" , "Course" ,AdditionalFields ="Degree", ErrorMessage = "Must Be Less Than Degree")]
        public int MinDegree { get; set; }
        [Remote("CheckHours", "Course" , ErrorMessage = "Must Be % 3 ")]
        public int Hours { get; set; }
        [ForeignKey("department")]
      //  [Display (Name ="Department")]
        public int dept_id { get; set; }
        public  Department? department { get; set; }

        public List<CrsResult>? Crs { get; set; }

        public List<Instructor>? Instructors { get; set; }


    }
}
