using EmployeesDepartments.DataAccess;
using EmployeesDepartments.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace EmployeesDepartmentsTestProject
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeesDepartmentsTestProject", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: Configuration.GetValue<string>("CORS:Name"),
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration.GetSection("CORS").GetSection("AllowedOrigins").Get<string[]>())
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Dapper

            //services.AddScoped<DapperDbContext>(provider => new DapperDbContext("parameterString", ActivatorUtilities.CreateInstance<IConfiguration>(provider, "")));
            //services.AddScoped<DapperDbContext>();

            //services.AddTransient<IEmployeeRepository, DREmployeeRepository>();
            //services.AddTransient<IDepartmentRepository, DRDepartmentRepository>();
            //services.AddTransient<IDepartmentEmployeeRepository, DRDepartmentEmployeeRepository>();

            #endregion

            #region EF

            services.AddDbContext<EFDbContext>();
            services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
            services.AddTransient<IDepartmentRepository, EFDepartmentRepository>();
            services.AddTransient<IDepartmentEmployeeRepository, EFDepartmentEmployeeRepository>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeesDepartmentsTestProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(Configuration.GetValue<string>("CORS:Name"));
        }
    }
}
