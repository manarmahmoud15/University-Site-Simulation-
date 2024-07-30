using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [ForeignKey("course")]
        public int crs_id { get; set; }
        public Course course  { get; set; }
        [ForeignKey("Trainee")]
        public int Trainee_id { get; set; }
        public Trainee Trainee { get; set; }


    }
}
