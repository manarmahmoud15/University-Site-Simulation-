namespace WebApplication1.Repository
{
    public class InstructorsRepository : IInstructorsRepository
    {
        Context context;
        public InstructorsRepository(Context _context)
        {
            context = _context;
        }
        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }
        public Instructor GetByID(int id)
        {
            return context.Instructors.FirstOrDefault(c => c.Id == id);
        }
        public void insert(Instructor Obj)
        {
            context.Add(Obj);
        }
        public void update(Instructor Obj)
        {
            context.Update(Obj);
        }
        public void Delete(int id)
        {
            Instructor instructor = GetByID(id);
            context.Remove(instructor);
        }
        public void Save(Instructor Obj)
        {
            context.SaveChanges();
        }
    }
}
