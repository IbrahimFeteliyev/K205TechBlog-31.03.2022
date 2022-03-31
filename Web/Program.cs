using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogDbContext>
    (options => options.UseSqlServer(connectingString));



builder.Services.AddDefaultIdentity<K205User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BlogDbContext>();


builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IBlogManager, BlogManager>();
builder.Services.AddScoped<ICommentManager, CommentManager>();



builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/admin/auth/login";
    option.AccessDeniedPath = "/admin/auth/login";
});



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

app.UseAuthentication();
app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
