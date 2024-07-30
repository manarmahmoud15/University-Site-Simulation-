using Microsoft.EntityFrameworkCore;
using WebApplication1.Filter;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICourseRepository , CourseRepository>();
            //    builder.Services.AddScoped<IInstructorsRepository , InstructorsRepository>();
            //-------------------------
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute()); // to be global 
            //});
            builder.Services.AddControllersWithViews();


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(5);
            });

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")); 
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
            app.Run();
        }
    }
}
