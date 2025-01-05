using Microsoft.EntityFrameworkCore;
using Yess.Data;
using Yess.Services;

namespace Yess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.MapStaticAssets();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{ProductId?}");
            ///

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{ProductId?}");
            //.WithStaticAssets();

            app.MapControllerRoute(
                name: "category",
                pattern: "Category/{action=Index}/{CategoryId?}",
                defaults: new { controller = "Category" });

 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Ensure controller routing is mapped
            });

            app.Run();
        }
    }
}
