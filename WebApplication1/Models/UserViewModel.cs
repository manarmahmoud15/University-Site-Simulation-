using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserViewModel
    {
        public String UserName { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
