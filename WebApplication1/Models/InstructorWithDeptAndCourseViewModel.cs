using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class InstructorWithDeptAndCourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImgURL { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int dept_id { get; set; }
        public int Crs_id { get; set; }
        [Display(Name = "Choose Profile Photo")]
        [Required]
        public IFormFile UploadPhoto { get; set; }
        public List<DeptVm> Departments { get; set; }
        public List<CrsVm> Courses { get; set; }
    }
    public class DeptVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CrsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
