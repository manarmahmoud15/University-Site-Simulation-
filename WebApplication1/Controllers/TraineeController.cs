using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Primitives;

namespace WebApplication1.Controllers
{
    public class TraineeController : Controller
    {
     //    private readonly Context _context;
      
       // private readonly IMapper _mapper;

        //public TraineeController(Context context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}
        Context context = new Context();

        public IActionResult ShowResultVM(int Trainee_id, int Crs_ID)
        {
           
    //        List<CrsResult> crsResults = context.crsResults.ToList(); 

            TraineeCourseResultViewModel traineeVM = new TraineeCourseResultViewModel();

                 CrsResult? crsResult =context.crsResults.Include(t=>t.Trainee)
                .Include(c=> c.course)
                .FirstOrDefault(cr => cr.Trainee_id == Trainee_id && cr.crs_id == Crs_ID);

            if (crsResult != null)
            {
                traineeVM.TraineeID = crsResult.Trainee_id;
                traineeVM.CourseID = crsResult.crs_id;
                traineeVM.TraineeName = crsResult.Trainee.Name;
                traineeVM.CourseName = crsResult.course.Name;
                

                if (crsResult.course != null)
                {
                    if (crsResult.Degree > crsResult.course.MinDegree)
                    {
                        traineeVM.Color = "Green";
                    }
                    else
                    {
                        traineeVM.Color = "Red";
                    }
                }
            }


            return View("ShowResultVM", traineeVM);
        }

        public IActionResult ShowTraineeResult (int id)
        {
           List <TraineeCourseResultViewModel> traineeList = new List<TraineeCourseResultViewModel>();
            
            List<CrsResult> crsResult = context.crsResults.Include(t => t.Trainee)
           .Include(c => c.course)
           .Where(cr =>  cr.Trainee_id == id).ToList();
            // Trainee trainee = context.trainees.FirstOrDefault(t => t.Id == id);

            foreach (CrsResult cr in crsResult)
            {

                TraineeCourseResultViewModel traineeVM = new TraineeCourseResultViewModel();
                traineeVM.Degree = cr.Degree;
                    traineeVM.TraineeName = cr.Trainee.Name;
                traineeVM.CourseName = cr.course.Name;  

                if ( traineeVM.Degree <cr.course.MinDegree  )
                {
                    traineeVM.Color = "red";
                }
                else
                {                        
                    traineeVM.Color = "green";
                }
                traineeList.Add(traineeVM);
            }

            return View("ShowTraineeResult" , traineeList);
        }
        public IActionResult ShowCourseTrainees (int id)
        {
            List<TraineeCourseResultViewModel> TraineeList = new List<TraineeCourseResultViewModel>();
            List<CrsResult> crsResults = context.crsResults
                .Include(t => t.Trainee)
                .Include(c=> c.course)
                .Where(c => c.crs_id == id)
                .ToList();
            foreach (CrsResult cr in crsResults)
            {
                   TraineeCourseResultViewModel courseVM = new TraineeCourseResultViewModel();
                //    TraineeCourseResultViewModel courseVM = _mapper.Map<TraineeCourseResultViewModel>(cr);

                courseVM.TraineeName = cr.Trainee.Name;
                courseVM.CourseName = cr.course.Name;
                courseVM.Degree = cr.Degree;
                if (courseVM.Degree <cr.course.MinDegree )
                {
                    courseVM.Color = "red"; 
                }
                else 
                {
                    courseVM.Color = "Green"; 
                }

                TraineeList.Add(courseVM);
            }
            return  View("ShowCourseTrainees", TraineeList);
        }

        public IActionResult test(Department Dept )
        {
            return Content($"Name ");
        }
    }
}
