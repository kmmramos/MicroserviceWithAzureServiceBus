//using Mango.Web;
//using Mango.Web.Services;
//using Mango.Web.Services.Iservices;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

////NOTE: To configure our product service under Mango.Web to have dependency injection:
////We have to configure the use of HTTP Client by passing the interface and then the implementation of the interface.
//builder.Services.AddHttpClient<IProductService, ProductService>();

////NOTE: we have to configure the base to have static details for our product API base.
////It is by accessing our appsetting.json file.
////SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
//SD.ProductAPIBase = builder.Configuration.GetValue<string>("ServiceUrls:ProductAPI");

//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


//====//
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}