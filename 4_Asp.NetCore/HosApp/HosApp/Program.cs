using HosApp.Data;
using HosApp.Repository.Appointment;
using HosApp.Repository.Base;
using HosApp.Repository.Billing;
using HosApp.Repository.Department;
using HosApp.Repository.Doctor;
using HosApp.Repository.ElectronicHealthRecord;
using HosApp.Repository.Nurse;
using HosApp.Repository.Patient;
using HosApp.Repository.Permission;
using HosApp.Repository.Prescription;
using HosApp.Repository.Role;
using HosApp.Repository.User;
using HosApp.Security;
using HosApp.Service;
using HosApp.Service.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository));
builder.Services.AddScoped(typeof(IBillingRepsoitory), typeof(BillingRepository));
builder.Services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
builder.Services.AddScoped(typeof(IDoctorRepository), typeof(DoctorRepository));
builder.Services.AddScoped(typeof(IElectronicHealthRecordRepository), typeof(ElectronicHealthRecordRepository));
builder.Services.AddScoped(typeof(INurseRepository), typeof(NurseRepository));
builder.Services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));
builder.Services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
builder.Services.AddScoped(typeof(IPrescriptionRepository), typeof(PrescriptionRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    options.Cookie.Name = "HospitalManagement.Auth";
    options.Cookie.HttpOnly = true;
});

builder.Services.AddAuthorization(options =>
{
    foreach (string permission in PermissionsNames.AllPermissions)
    {
        options.AddPolicy(permission,
            policy => policy.RequireClaim(PermissionsNames.ClaimType, permission));
    }
}
);


builder.Services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));
builder.Services.AddScoped(typeof(IBillingService), typeof(BillingService));
builder.Services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
builder.Services.AddScoped(typeof(IDoctorService), typeof(DoctorService));
builder.Services.AddScoped(typeof(IElectronicHealthRecordService), typeof(ElectronicHealthRecordService));
builder.Services.AddScoped(typeof(INurseService), typeof(NurseService));
builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));
builder.Services.AddScoped(typeof(IPermissionService), typeof(PermissionService));
builder.Services.AddScoped(typeof(IPrescriptionService), typeof(PrescriptionService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IRoleService), typeof(RoleService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
