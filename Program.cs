using Microsoft.EntityFrameworkCore;
using Auction_House.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add connection string and configure AppDbContext
var connectionString = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add identity service
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
