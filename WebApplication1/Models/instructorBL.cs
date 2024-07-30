namespace WebApplication1.Models
{
    
    public class instructorBL
    {
        Context Context = new Context();
        public List<Instructor> GetALLInstructor()
        {
            List<Instructor> instructors =  Context.Instructors.ToList();
            return instructors; 
        }
        public Instructor GetInstructorByID (int id)
        {
            Instructor instructor =  Context.Instructors.FirstOrDefault(ins => ins.Id == id);
            return instructor;
        }
    }

}
