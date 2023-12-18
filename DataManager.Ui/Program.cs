using DataManager.BLL.Interface;
using DataManager.BLL.Services;
using DataManager.DAL.Interface;
using DataManager.DAL.DataSevices;
using DataManager.DAL.Orm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDapperORM, DapperORM>();

builder.Services.AddSingleton<IEmployeeDAL, EmployeeDAL>();
builder.Services.AddSingleton<ICompanyDAL, CompanyDAL>();
builder.Services.AddSingleton<IPositionDAL, PositionDAL>();
builder.Services.AddSingleton<IDepartamentDAL, DepartamentDAL>();
builder.Services.AddSingleton<IPayrollDAL, PayrollDAL>();

builder.Services.AddSingleton<IEmployeeServices, EmployeeServices>();
builder.Services.AddSingleton<ICompanyServices, CompanyServices>();
builder.Services.AddSingleton<IPositionServices, PositionServices>();
builder.Services.AddSingleton<IDepartamentServices, DepartamentServices>();
builder.Services.AddSingleton<IPayrollServices, PayrollServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
