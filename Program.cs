using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanA.Context;
using PlanA.Data;
using PlanA.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PlanADbContext>(options => options.UseNpgsql(connection,
    npgsqlOptions => npgsqlOptions.UseNodaTime()));
//string connection = builder.Configuration.GetConnectionString("ReserveConnection");
//builder.Services.AddDbContext<PlanADbContext>(options => options.UseSqlite(connection));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment()
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else {
    app.UseMigrationsEndPoint();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();


app.Run();