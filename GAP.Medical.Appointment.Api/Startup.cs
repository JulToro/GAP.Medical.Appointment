using System;
using System.Text;
using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Application.Services;
using GAP.Medical.Appointment.Domain;
using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
using GAP.Medical.Appointment.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
            AddJWT(services);

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        ;
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseCors("MyPolicy");

           // app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UseSwagger(app);
        }

        private void AddSQLPersistence(IServiceCollection services)
        {
            services.AddDbContext<AppointmentContext>(options => options.UseSqlServer(Configuration["connectionString"], b => b.MigrationsAssembly("GAP.Medical.Appointment.Infrastructure")));
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
            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.GetPatientDetails.Presenter, GAP.Medical.Appointment.Api.UseCases.GetPatientDetails.Presenter>();
            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails.Presenter, GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails.Presenter>();
            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.CancelAppointments.Presenter, GAP.Medical.Appointment.Api.UseCases.CancelAppointments.Presenter>();
            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialities.Presenter, GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialities.Presenter>();
            services.AddScoped<GAP.Medical.Appointment.Api.UseCases.Loggin.Presenter, GAP.Medical.Appointment.Api.UseCases.Loggin.Presenter>();

            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.RegisterPatient.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.GetPatientDetails.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetAppoinments.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.CancelAppointment.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.CancelAppointments.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialities.Presenter>());
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.Login.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.Loggin.Presenter>());

            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.RegisterPatient.IUseCase, GAP.Medical.Appointment.Application.UseCases.RegisterPatient>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.IUseCase, GAP.Medical.Appointment.Application.UseCases.AsignAppointment>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails.IUseCase, GAP.Medical.Appointment.Application.UseCases.GetPatientDetails>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetAppoinments.IUseCase, GAP.Medical.Appointment.Application.UseCases.GetAppointmentsDetails>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.CancelAppointment.IUseCase, GAP.Medical.Appointment.Application.UseCases.CancelAppointment>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality.IUseCase, GAP.Medical.Appointment.Application.UseCases.GetMedicalSpecialiy>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.Login.IUseCase, GAP.Medical.Appointment.Application.UseCases.Login>();
        }

        private void AddJWT(IServiceCollection services)
        {
            string clave1 = Configuration["Jwt:Key"];
            string clave2 = Configuration["Jwt:Issuer"];

            var key = Encoding.ASCII.GetBytes(clave1);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration[clave2],
            //        ValidAudience = Configuration[clave2],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave1)),
            //        ClockSkew =TimeSpan.Zero
            //    };
            //});
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API (Production)", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Tocken usar Bearer {Token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

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
