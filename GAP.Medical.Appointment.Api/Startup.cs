using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Application.Services;
using GAP.Medical.Appointment.Domain;
using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
using GAP.Medical.Appointment.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GAP.Medical.Appointment.Api
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
            AddSwagger(services);
            AddAppoinmentCore(services);
            AddSQLPersistence(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UseSwagger(app);
        }

        private void AddSQLPersistence(IServiceCollection services)
        {
            services.AddDbContext<AppointmentContext>(options => options.UseSqlServer("Server = DESKTOPJTORO\\TOROSQLSERVER; Database=BDPruebaNet;User Id=sa;Password=asdf.1234", b => b.MigrationsAssembly("GAP.Medical.Appointment.Infrastructure")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppointmentReporsitory, AppointmentReporsitory>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicalSpecialitiesRepository, MedicalSpecialitiesRepository>();
        }
        private void AddAppoinmentCore(IServiceCollection services)
        {
            services.AddScoped<IEntitiesFactory, DefaultEntitiesFactory>();

            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter, GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter>();
            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter, GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter>();

            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.RegisterPatient.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter>());

            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.RegisterPatient.IUseCase, GAP.Medical.Appointment.Application.UseCases.RegisterPatient>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.IUseCase, GAP.Medical.Appointment.Application.UseCases.AsignAppointment>();

        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API (Production)", Version = "v1" });
            });
        }
        private void UseSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
