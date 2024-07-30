using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        //  Context context = new Context();
        ICourseRepository CourseRepository;
        public CourseController (ICourseRepository CourseRepo)
        {
            CourseRepository = CourseRepo;
        }
        public IActionResult Index()
        {
            List<Course> course = CourseRepository.GetAll();


            return View("ShowAllCourses" , course);
        }
        public IActionResult Details(int id)
        {
            Course courses = CourseRepository.GetByID(id);
            return View("DetailsOfCourse", courses);
        }
        public IActionResult AddCourse ()
        {
            ViewData["DeptList"] = CourseRepository.GetAll();

            return View("AddCourse");
        }
        [HttpPost]
        public IActionResult SaveNewCourse(Course course)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    CourseRepository.insert(course);
                    CourseRepository.Save(course);
                    return RedirectToAction("AddCourse");
                }
                catch (Exception ex)
                {
                  //  ModelState.AddModelError("Error", ex.InnerException.Message);
                }
               
            }
            ViewData["DeptList"] = CourseRepository.GetAll();
     

            return View("AddCourse" , course);
        }

        public IActionResult CheckHours(int Hours)
        {
            if (Hours % 3 == 0)
            {
                return Json (true);
            }
            else
                return Json(false);
        }
        public IActionResult CheckMinDegree (int Degree ,int MinDegree)
        {
            if (MinDegree < Degree)
            {
                return Json(true);
            }
            else
                return Json(false);
            
        }


    }
}
