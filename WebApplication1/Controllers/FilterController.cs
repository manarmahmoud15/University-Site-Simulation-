using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filter;

namespace WebApplication1.Controllers
{
    [HandelError]
    public class FilterController : Controller
    {
        [HandelError]
        public IActionResult Index()
        {
            throw new Exception("Exeption Happen");
        }
    }
}
