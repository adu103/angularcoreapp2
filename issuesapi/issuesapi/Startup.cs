using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using issuesapi.Models;
using Microsoft.Extensions.Logging;

namespace issuesapi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IssueContext>(opt =>
                opt.UseInMemoryDatabase("IssueList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
        );
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}