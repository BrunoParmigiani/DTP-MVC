using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DTP.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DTPContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DTPContext"),
        new MySqlServerVersion(new Version(8, 0, 0))));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DTPContext>();
    context.Database.EnsureCreated();

    SeedingService seedingService = new SeedingService(context);
    seedingService.Seed();
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
