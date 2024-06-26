using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Models.Entities;
using personaapi_dotnet.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IPersonaRepository, PersonaRepository>();
builder.Services.AddTransient<IProfesion, ProfesionRepository>();
builder.Services.AddTransient<IEstudioRepository, EstudioRepository>();
builder.Services.AddTransient<ITelefonoRepository, TelefonoRepository>();
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
