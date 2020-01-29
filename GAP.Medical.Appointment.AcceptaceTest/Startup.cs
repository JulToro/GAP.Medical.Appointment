using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Application.Services;
using GAP.Medical.Appointment.Domain;
using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
using GAP.Medical.Appointment.Infrastructure.MockRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GAP.Medical.Appointment.AcceptaceTest
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


            AddAppoinmentCore(services);
            AddSQLPersistence(services);

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("MyPolicy", builder =>
            //    {
            //        builder
            //            .AllowAnyHeader()
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            ;
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();


            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());
            //app.UseCors("MyPolicy");

            //// app.UseHttpsRedirection();
            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

        }

        private void AddSQLPersistence(IServiceCollection services)
        {
            //services.AddDbContext<AppointmentContext>(options => options.UseSqlServer(Configuration["connectionString"], b => b.MigrationsAssembly("GAP.Medical.Appointment.Infrastructure")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppointmentReporsitory, AppointmentReporsitoryMock>();
            services.AddScoped<IPatientRepository, PatientRepositoryMock>();
            services.AddScoped<IMedicalSpecialtiesRepository, MedicalSpecialtiesRepositoryMock>();
        }
        private void AddAppoinmentCore(IServiceCollection services)
        {
            services.AddScoped<IEntitiesFactory, DefaultEntitiesFactory>();

            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter, GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter>();
            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter, GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter>();
            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.GetPatientDetails.Presenter, GAP.Medical.Appointment.Api.UseCases.GetPatientDetails.Presenter>();
            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails.Presenter, GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails.Presenter>();
            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.CancelAppointments.Presenter, GAP.Medical.Appointment.Api.UseCases.CancelAppointments.Presenter>();
            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialties.Presenter, GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialties.Presenter>();
            //services.AddScoped<GAP.Medical.Appointment.Api.UseCases.Loggin.Presenter, GAP.Medical.Appointment.Api.UseCases.Loggin.Presenter>();

            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.RegisterPatient.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.RegisterPatient.Presenter>());
            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.AssignAppointments.Presenter>());
            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.GetPatientDetails.Presenter>());
            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetAppoinments.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails.Presenter>());
            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.CancelAppointment.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.CancelAppointments.Presenter>());
            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialties.Presenter>());
            //services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.Login.IOutputHandler>(x => x.GetRequiredService<GAP.Medical.Appointment.Api.UseCases.Loggin.Presenter>());

            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.RegisterPatient.IUseCase, GAP.Medical.Appointment.Application.UseCases.RegisterPatient>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.IUseCase, GAP.Medical.Appointment.Application.UseCases.AsignAppointment>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails.IUseCase, GAP.Medical.Appointment.Application.UseCases.GetPatientDetails>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetAppoinments.IUseCase, GAP.Medical.Appointment.Application.UseCases.GetAppointmentsDetails>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.CancelAppointment.IUseCase, GAP.Medical.Appointment.Application.UseCases.CancelAppointment>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty.IUseCase, GAP.Medical.Appointment.Application.UseCases.GetMedicalSpecialty>();
            services.AddScoped<GAP.Medical.Appointment.Application.Boundaries.Login.IUseCase, GAP.Medical.Appointment.Application.UseCases.Login>();
        }


    }
}
