using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// DB Connection
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// *IMP* Here the service is registered.
// When working with DBs, add "Scoped" lifecycle
// Lifetime has to be specific: 3 lifetimes in dotnet are viz.
// 1. Singleton (1 obj throughout the lifecyle, unless app is restarted),
// 2. ** Scoped: Scoped until the next click event happens.[When working with DBContext use Scoped]
// 3. Transient: Everytime a new object is created.

//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// Removed above code as UNITOFWORK will take care of this.
// ? We are adding DI to Program.cs for new services using builder.Services.AddScoped<IT, T>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Razor page runtime compilation
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //area is included
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

