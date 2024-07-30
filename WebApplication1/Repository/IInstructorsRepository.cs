namespace WebApplication1.Repository
{
    public interface IInstructorsRepository
    {
        public List<Instructor> GetAll();

        public Instructor GetByID(int id);

        public void insert(Instructor Obj);


        public void update(Instructor Obj);


        public void Delete(int id);

        public void Save(Instructor Obj);
    }
}