using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using X.PagedList;
using WebApplication1.Repository;


namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
        //private readonly IWebHostEnvironment _webHostEnvironment; 
        //public InstructorController(IWebHostEnvironment webHostEnvironment) 
        //{
        //    _webHostEnvironment = webHostEnvironment;
        //}
        Context context = new Context();

        instructorBL bl = new instructorBL();

        //public IActionResult ShowAll(string Search ,int? PageNumber )
        //{
        //    List<Instructor> insListModel = bl.GetALLInstructor();
        //    if (!string.IsNullOrEmpty( Search ) )
        //    {
        //        insListModel = (List<Instructor>)insListModel
        //            .Where(i => i.Name.Contains(Search)).ToList()
        //            .ToPagedList( PageNumber ?? 1, 3);
        //    }
        //    return View("ShowAll" , insListModel) ;
        //}

        //IInstructorsRepository instructorsRepository;
        //public InstructorController (IInstructorsRepository instructorRepo)
        //{
        //    instructorsRepository = instructorRepo;
        //}

        public IActionResult ShowAll(string Search, int? PageNumber)
        {
            List<Instructor> insListModel = bl.GetALLInstructor();
            IPagedList<Instructor> pagedInstructors;

            if (!string.IsNullOrEmpty(Search))
            {
                // Apply search filter
                insListModel = insListModel
                    .Where(i => i.Name.Contains(Search))
                    .ToList();
            }

            // Paginate the filtered list
            pagedInstructors = insListModel.ToPagedList(PageNumber ?? 1, 5);

            // Pass the search term to the view via ViewBag
            ViewBag.Search = Search;

            return View("ShowAll", pagedInstructors);
        }
        public IActionResult Details (int id )
        {
            Instructor insModel = bl.GetInstructorByID(id);
            return View("Details" , insModel);
        }
        public IActionResult New ()
        {
            InstructorWithDeptAndCourseViewModel InstructorVM =
            new InstructorWithDeptAndCourseViewModel();           
            InstructorVM.Departments = context.Departments.Select(d => new DeptVm { Id = d.Id, Name = d.Name }).ToList();
            InstructorVM.Courses = context.courses.Select(d => new CrsVm { Id = d.Id, Name = d.Name }).ToList();

            return View("New", InstructorVM);

        }
        [HttpPost]
        public IActionResult SaveNew(Instructor instructors )//, IFormFile UploadPhoto)
        {
            InstructorWithDeptAndCourseViewModel InstructorVM =
            new InstructorWithDeptAndCourseViewModel();
            if (instructors.Name != null)
            {
                InstructorVM.Name = instructors.Name;
                InstructorVM.Salary = instructors.Salary;
                InstructorVM.Address = instructors.Address;
                //if (UploadPhoto != null)
                //{
                //    string Folder = "UploadPhoto";
                //    Folder += InstructorVM.UploadPhoto.FileName + Guid.NewGuid().ToString(); // to be unique      
                //    //    String ServerFolder = _webHostEnvironment.WebRootPath + Folder;
                //    String ServerFolder = Path.Combine(_webHostEnvironment.WebRootPath, Folder);

                //    InstructorVM.UploadPhoto.CopyToAsync(new FileStream(ServerFolder, FileMode.Create));
                //}
                InstructorVM.ImgURL = instructors.ImgURL;
                InstructorVM.Crs_id = instructors.Crs_id;
                InstructorVM.dept_id = instructors.dept_id;
                context.Add(instructors);
                context.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            //
            InstructorVM.Departments = context.Departments.Select(d => new DeptVm { Id = d.Id, Name = d.Name }).ToList();
            InstructorVM.Courses = context.courses.Select(d => new CrsVm { Id = d.Id, Name = d.Name }).ToList();

            return View("New", InstructorVM);
        }
        public IActionResult Edit(int id)
        {
            Instructor instructorModel = context.Instructors.FirstOrDefault(i => i.Id==id);

            InstructorWithDeptAndCourseViewModel InstructorVM = 
                new InstructorWithDeptAndCourseViewModel();
        //    InstructorVM.Id = instructorModel.Id;
            InstructorVM.Name = instructorModel.Name;
            InstructorVM.Salary = instructorModel.Salary;
            InstructorVM.Address = instructorModel.Address;
            InstructorVM.ImgURL = instructorModel.ImgURL;
            InstructorVM.Crs_id = instructorModel.Crs_id;
            InstructorVM.dept_id = instructorModel.dept_id;
            InstructorVM.Departments = context.Departments.Select(d => new DeptVm { Id = d.Id, Name = d.Name }).ToList();
            InstructorVM.Courses = context.courses.Select(d => new CrsVm { Id = d.Id, Name = d.Name }).ToList();

            return View("Edit", InstructorVM);
        
        }
        [HttpPost]
        public IActionResult SaveEdit(Instructor instructors)
        {

            InstructorWithDeptAndCourseViewModel InstructorVM =
                new InstructorWithDeptAndCourseViewModel();
            if (instructors.Name != null)
            {
                Instructor instructorModel = context.Instructors.FirstOrDefault(i => i.Id ==instructors.Id);

              //  InstructorVM.Id = instructorModel.Id;
                InstructorVM.Name = instructorModel.Name;
                InstructorVM.Salary = instructorModel.Salary;
                InstructorVM.Address = instructorModel.Address;
                InstructorVM.ImgURL = instructorModel.ImgURL;
                InstructorVM.Crs_id = instructorModel.Crs_id;
                InstructorVM.dept_id = instructorModel.dept_id;
                context.Update(instructors);
                context.SaveChanges();
                return RedirectToAction("showAll");
            }
            InstructorVM.Departments = context.Departments.Select(d => new DeptVm { Id = d.Id  , Name = d.Name}).ToList();
            InstructorVM.Courses = context.courses.Select(d => new CrsVm { Id = d.Id, Name = d.Name }).ToList();
            return View("Edit" , InstructorVM);

        }
        public IActionResult Delete (int id)
        {
            Instructor instructor = context.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            context.Remove(instructor);
            context.SaveChanges();
            return RedirectToAction("ShowAll");
        }

        public IActionResult GetDepartmentsCourses()
        {
            List<Department> departments = context.Departments.ToList();
            return View("ShowDepartment", departments);
        }
        public IActionResult ShowCoursesPerDepartment (int deptID)
        {
            var courses = context.courses
                .Where(D => D.dept_id== deptID)
                .Select(c => new {id = c.Id, name = c.Name }).ToList();
            return Json(courses);
        }
    }
}
