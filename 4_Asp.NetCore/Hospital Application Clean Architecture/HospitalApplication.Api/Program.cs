using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Infrastructure.Data;
using HospitalApplication.Infrastructure.Persistences.Repositories;
using HospitalApplication.Infrastructure.Persistences.Services;
using HospitalApplication.Service.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository));
builder.Services.AddScoped(typeof(IBillingRepository), typeof(BillingRepository));
builder.Services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
builder.Services.AddScoped(typeof(IDoctorRepository), typeof(DoctorRepository));
builder.Services.AddScoped(typeof(IElectronicHealthRecordRepository), typeof(ElectronicHealthRecordRepository));
builder.Services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));
//builder.Services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
//builder.Services.AddScoped(typeof(IPrescriptionRepository), typeof(PrescriptionRepository));
builder.Services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));
builder.Services.AddScoped(typeof(IBillingService), typeof(BillingService));
builder.Services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
builder.Services.AddScoped(typeof(IDoctorService), typeof(DoctorService));
builder.Services.AddScoped(typeof(IElectronicHealthRecordService), typeof(ElectronicHealthRecordService));
builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));
builder.Services.AddScoped(typeof(IPermissionService), typeof(PermissionService));
builder.Services.AddScoped(typeof(IPrescriptionService), typeof(PrescriptionService));
builder.Services.AddScoped(typeof(IRoleService), typeof(RoleService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
