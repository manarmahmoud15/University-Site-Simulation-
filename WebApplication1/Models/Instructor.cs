using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImgURL { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        [ForeignKey("department")]
        public int dept_id { get; set; }
        public  Department department { get; set; }
        [ForeignKey("Course")]
        public int Crs_id { get; set; }
        public  Course Course { get; set; }

    }
}
