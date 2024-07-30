namespace WebApplication1.Repository
{
    public interface ICourseRepository
    {
        public string ID { get; set; }
        public List<Course> GetAll();

        public Course GetByID(int id);

        public void insert(Course Obj);
        public Course GetByDeptID (int deptID);

        public void update(Course Obj);


        public void Delete(int id);

        public void Save(Course Obj);

    }
}