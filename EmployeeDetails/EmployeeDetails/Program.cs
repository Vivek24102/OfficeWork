using Employee_Model.Models;
using Employee_Repositry.Repositry;
using Employee_Repositry.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Demodb")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EmployeeContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
   
    options.LoginPath = "/Home/Login";

});

builder.Services.AddScoped<ILogin , LoginServices>();
builder.Services.AddScoped<ISignUp, SIgnupService>();
builder.Services.AddScoped<IEmployee ,EmployeeServices>();
builder.Services.AddScoped<IDepartment, DepartmentServices>();
builder.Services.AddScoped<IJwtAuth, JwtAuthSevice>();
builder.Services.AddScoped<ITask, TaskServices>();
builder.Services.AddScoped<ITaskLog, TaskLogServices>();
builder.Services.AddScoped<IDepartment ,DepartmentServices>();

builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(21);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
