using LibraryApp.Data;
using LibraryApp.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ---------------------------------------------------------------
// PHASE 1 — In-Memory Storage (no database needed)
// ---------------------------------------------------------------
//builder.Services.AddSingleton<IBookRepository, MemoryBookRepository>();

// ---------------------------------------------------------------
// PHASE 2 — SQL Server with Entity Framework Core
// ---------------------------------------------------------------
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb")));
builder.Services.AddScoped<IBookRepository, SqlBookRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=List}/{id?}");

app.Run();
