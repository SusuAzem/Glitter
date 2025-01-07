using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

using Glitter.Services;

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
   .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
   .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
   .AddJsonFile("content.json", optional: true, reloadOnChange: true)
   .AddEnvironmentVariables();
// Add services to the container.
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddControllersWithViews(options => 
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddLogging(builder => builder.AddDebug());
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 8;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
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

app.UseAuthorization();

app.UseNotyf();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();