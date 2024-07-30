using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class TraineeCourseResultViewModel
    {
        public string Color { get; set; }
        public string Message { get; set; }
        public CrsResult? Result { get; set; }
        public int CourseID { get; set; }
        public int TraineeID { get; set; }
        public int Degree { get; set; }
        public string TraineeName { get; set; }
        public string CourseName { get; set; }
        public string TraineeImage { get; set; }
    }
}
