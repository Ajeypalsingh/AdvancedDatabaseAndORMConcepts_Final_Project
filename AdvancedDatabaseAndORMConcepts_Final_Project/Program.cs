using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdvancedDatabaseAndORMConcepts_Final_Project.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdvancedDatabaseAndORMConcepts_Final_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdvancedDatabaseAndORMConcepts_Final_ProjectContext") ?? throw new InvalidOperationException("Connection string 'AdvancedDatabaseAndORMConcepts_Final_ProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();
