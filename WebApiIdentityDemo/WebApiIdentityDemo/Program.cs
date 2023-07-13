using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiIdentityDemo.Areas.Identity.Pages.Account;
using WebApiIdentityDemo.Data;
using WebApiIdentityDemo.Services.AccountRepository;
using WebApiIdentityDemo.Services.EmailRepository;
using WebApiIdentityDemo.Services.OtpGenrator;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApiIdentityDemoContextConnection") ?? throw new InvalidOperationException("Connection string 'WebApiIdentityDemoContextConnection' not found.");

builder.Services.AddDbContext<WebApiIdentityDemoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebApiIdentityDemoContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ISignUpRepository  , SignUpRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IOtpRepository, OtpRepository>();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(_ => _.FullName?.Replace("+", "."));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
