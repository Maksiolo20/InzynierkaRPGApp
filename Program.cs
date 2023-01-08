using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RPGApp.Data;
using RPGApp.Interfaces;
using RPGApp.Services;
using RPGApp.Mapper;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped<INotebook, NotebookService>();
builder.Services.AddScoped<ICard, CardService>();
builder.Services.AddScoped<IManualTab, ManualTabService>();
builder.Services.AddScoped<IMap, MapService>();
builder.Services.AddScoped<IHome, HomeService>();
//builder.Services.AddScoped<IServerURL, ServerURLService>();
//builder.Services.AddScoped<IMapTiler,MapTilerService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
