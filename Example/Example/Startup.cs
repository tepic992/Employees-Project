using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Example.Managers;

namespace Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FirmDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<EmplManagers>();
            services.AddScoped<JobManagers>();
            services.AddScoped<JobTypeManagers>();
            services.AddScoped<JobAvailManagers>();
            services.AddScoped<ManagmentManagers>();
            services.AddScoped<SkillManagers>();
            services.AddScoped<JobTypeSkillManagers>();

            //services.AddDbContext<JobRepository>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Job")));
            //services.AddDbContext<JobTypeRepository>(opt => opt.UseSqlServer(Configuration.GetConnectionString("JobType")));
            //services.AddDbContext<JobAvailabilityRepository>(opt => opt.UseSqlServer(Configuration.GetConnectionString("JobAvailability")));            
            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc(name:"Coding", new OpenApiInfo { Title="Training", Version="Coding" }));
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            c.SwaggerEndpoint(url: "/swagger/Coding/swagger.json", name:"Training Coding "));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
