using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession ()
        {
            //HttpContext.Session.SetString("Name", "Manar");
            //HttpContext.Session.SetInt32("Age", 22);
            var str = JsonConvert.SerializeObject(new {Name = "manar" , Age = 22}) ;
            HttpContext.Session.SetString("Person", str);
            return Content("Data Saved");
        }
        public IActionResult GetSession ()
        {
            //String GetName = HttpContext.Session.GetString("Name");
            ////  int GetAge = HttpContext.Session.GetInt32("Age").Value;
            //int? GetAge = HttpContext.Session.GetInt32("Age");
            //return Content($"Get Data Name : {GetName}        Age :{GetAge}");

            var str = HttpContext.Session.GetString("Person");
            if (str != null)
            {
                var obj = JsonConvert.DeserializeObject<dynamic>(str);
                string GetName = obj.Name;
                int GetAge = obj.Age;
                return Content($"Get Data Name : {GetName}        Age :{GetAge}");
            }
            else
            {
                return Content("Session Data Not Found");
            }

        }
    }
}
