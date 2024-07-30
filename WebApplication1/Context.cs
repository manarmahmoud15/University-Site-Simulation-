using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Context : DbContext
    {
        public Context() : base()
        { 
        }
        public Context (DbContextOptions<Context> options) : base(options) 
        { 

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITItrainee;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "PWD", Manager = "Eng.AhmedMamdouh" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "OS", Manager = "Eng.Christen" });

            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 1, Name = "mohamed",ImgURL = "m.jpeg", Salary = 5000 , dept_id =1 ,Address= "Alex" , Crs_id= 1});
            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 2, Name = "Ahmed", ImgURL = "m.jpeg", Salary = 6000, dept_id = 2 ,Address= "Assiut", Crs_id = 2 });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 3, Name = "mai", ImgURL = "f.jpeg", Salary = 7000 , dept_id = 1 , Address = "Asswan" , Crs_id = 3});
            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 4, Name = "aya", ImgURL = "f.jpeg", Salary = 9000, dept_id = 2 ,Address ="Sohag" , Crs_id = 4 });

            modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "HTML", Degree = 100, MinDegree = 60 , Hours = 30, dept_id = 1 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 2, Name = "CSS", Degree = 100, MinDegree = 60, Hours = 40, dept_id = 2 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 3, Name = "JS", Degree = 100, MinDegree = 60, Hours = 35, dept_id = 1 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 4, Name = "ES6", Degree = 100, MinDegree = 60, Hours = 20, dept_id = 2 });

            modelBuilder.Entity<Trainee>().HasData(new Trainee { Id = 1, Name = "Manar", ImgURL = "F.jpeg" ,Address = "Assiut" , grade = 1 , dept_id=1 });
            modelBuilder.Entity<Trainee>().HasData(new Trainee { Id = 2, Name = "Asmaa", ImgURL = "F.jpeg", Address = "Assiut", grade = 1, dept_id = 1 });
            modelBuilder.Entity<Trainee>().HasData(new Trainee { Id = 3, Name = "Zahraa", ImgURL = "F.jpeg", Address = "Assiut", grade = 1, dept_id = 2 });
            modelBuilder.Entity<Trainee>().HasData(new Trainee { Id = 4, Name = "Fatma", ImgURL = "F.jpeg", Address = "Assiut", grade = 1, dept_id = 2});

            modelBuilder.Entity<CrsResult>().HasData(new CrsResult { Id = 1, Degree = 95, crs_id = 1, Trainee_id = 1 });
            modelBuilder.Entity<CrsResult>().HasData(new CrsResult { Id = 2, Degree = 90, crs_id = 2, Trainee_id = 2 });
            modelBuilder.Entity<CrsResult>().HasData(new CrsResult { Id = 3, Degree = 80, crs_id = 3, Trainee_id = 3 });
            modelBuilder.Entity<CrsResult>().HasData(new CrsResult { Id = 4, Degree = 70, crs_id = 4, Trainee_id = 4 });
            modelBuilder.Entity<CrsResult>().HasData(new CrsResult { Id = 5, Degree = 50, crs_id = 2, Trainee_id = 1 });
            modelBuilder.Entity<CrsResult>().HasData(new CrsResult { Id = 6, Degree = 85, crs_id = 2, Trainee_id = 3 });



            base.OnModelCreating(modelBuilder);
        }
    }
}
