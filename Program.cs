using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DTP.Data;
using DTP.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DTPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DTPContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SitesService>();
builder.Services.AddScoped<DTPsService>();
builder.Services.AddScoped<ParentRDMService>();
builder.Services.AddScoped<ChildrenRDMService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DTPContext>();
    context.Database.EnsureCreated();

    SeedingService seedingService = new SeedingService(context);
    seedingService.SeedSites();
    seedingService.SeedDTPs();
    seedingService.SeedParentRDMs();
    seedingService.SeedChildrenRDMs();
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
    pattern: "{controller=Sites}/{action=Index}/{id?}");

app.Run();
