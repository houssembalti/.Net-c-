using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. //responsable de l'injection des interfaces et leurs services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServiceFlight, ServiceFlight>();
// Iserviceflight service=new serviceflight(uow);
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
//Iunitofrowkr uow =new Unitofwork(dbcontext,type);
builder.Services.AddDbContext<DbContext, AMContext>();
//DBContext dbcontext= new AMContext();
builder.Services.AddSingleton<Type>(p => typeof(GenericRepository<>));
//Type type= typeof(GenericRepository<>)

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
    pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.Run();
