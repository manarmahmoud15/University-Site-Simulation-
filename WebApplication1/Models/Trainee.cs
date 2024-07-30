using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int grade { get; set; }
        public string ImgURL { get; set; }
        public string Address { get; set; }
        [ForeignKey("department")]
        public int dept_id { get; set; }
        public virtual Department department { get; set; }

        public List<CrsResult> Crs { get; set; }

    }
}
