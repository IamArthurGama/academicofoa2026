using Microsoft.EntityFrameworkCore;
using academico.Data;
using academico.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AcademicoDbConnection");
builder.Services.AddDbContext<AcademicoContext>(options => options.UseSqlServer(connectionString));

// EF Core + SQL Server LocalDB
builder.Services.AddDbContext<AcademicoContext>(options =>
 options.UseSqlServer(
 builder.Configuration.GetConnectionString("Academico")));
// Repository agora usa o EF (substitui o Memoria)
builder.Services.AddScoped<IAlunoRepository, AlunoRepositorioEF>();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AcademicoContext>();
        AcademicoDbInitializer.Initialize(context);
    }catch (Exception ex) { 
    var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro ao popular o banco de dados.");
    }
}   

app.Run();
