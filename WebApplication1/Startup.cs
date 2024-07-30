using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext configuration
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("\"Data Source=.;Initial Catalog=ITItrainee;Integrated Security=True;Encrypt=False;Trust Server Certificate=True\"")));

            // Other service configurations may go here
        }

        // Other methods...
    }
}
