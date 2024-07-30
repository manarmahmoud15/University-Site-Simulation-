using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CourseDeptIntstructorCrsResultViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        [Display(Name = "Department")]
        public int dept_id { get; set; }

        public List<CrsResult> Crs { get; set; }

        public List<Instructor> Instructors { get; set; }
    }
}
