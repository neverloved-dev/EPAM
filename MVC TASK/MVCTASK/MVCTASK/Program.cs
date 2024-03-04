using Microsoft.EntityFrameworkCore;
using MVCTASK.Models;
using MVCTASK.Shared;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "Main")));
        builder.Services.AddAntiforgery(t =>
        {
            t.Cookie.Name = AntiForgeryTokenExtractor.AntiForgeryCookieName;
            t.FormFieldName = AntiForgeryTokenExtractor.AntiForgeryFieldName;
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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}