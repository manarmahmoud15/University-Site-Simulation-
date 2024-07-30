namespace WebApplication1.Repository
{
    public class CourseRepository : ICourseRepository
    {
        Context context;
        public string ID { get; set; }
        public CourseRepository(Context _context)
        {
            context = _context;
            ID = Guid.NewGuid().ToString(); // unique ID with any new obj will created 
        }

        public List<Course> GetAll()
        { 
            return context.courses.ToList();
        }
        public Course GetByID (int id)
        {
            return context.courses.FirstOrDefault(c => c.Id == id);
        } 
        public Course GetByDeptID(int id)
        {

            return context.courses.FirstOrDefault(c => c.dept_id == id);
        }
        public void insert (Course Obj)
        {
            context.Add(Obj);
        }
        public void update (Course Obj) 
        {
            context.Update(Obj);
        }
        public void Delete (int id)
        {
            Course course = GetByID(id);
            context.Remove(course);
        }
        public void Save (Course Obj)
        {
            context.SaveChanges();
        }

    }


}
