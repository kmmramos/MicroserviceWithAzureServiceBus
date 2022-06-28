//using AutoMapper;
//using Mango.Services.ProductAPI;
//using Mango.Services.ProductAPI.DbContexts;
//using Mango.Services.ProductAPI.Repository;
//using Mango.Web;
//using Mango.Web.Services;
//using Mango.Web.Services.Iservices;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
////builder.Services.AddDbContext<ApplicationDbContext>(options =>
////    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

////NOTE: DefaultConnection to be consistent 
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

////NOTE: Pass ApplicationDbContext class
////NOTE: Pass settings from appjson.settings file: connectionString
//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseSqlServer(connectionString));

////NOTE: To configure our BaseService from Mango.Services,
////we need to add it here using using Dependency Injection. 
////builder.Services.AddHttpClient<IProductService, ProductService>();

////NOTE: We have to configure the base path that we have inside static details
////that we have inputted inside the appsettings.json
////SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
////SD.ProductAPIBase = builder.Configuration.GetValue<string>("ServiceUrls:ProductAPI");

////NOTE: We have to add our product service using dependency injection.
////builder.Services.AddScoped<IProductService, ProductService>();
////builder.Services.AddControllersWithViews();

////NOTE: This will create a mapping
//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

////NOTE: To add our implementation on IProductRepository
//builder.Services.AddScoped<IProductRepository, ProductRepository>();

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//===
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI
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