
using cookie_stand_api.data;
using cookie_stand_api.model.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json.Serialization;
namespace cookie_stand_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

         
            var builder = WebApplication.CreateBuilder(args);
               builder.Services.AddControllers().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
     );
            // Add services to the container.
            builder.Services.AddDbContext<CookieStandDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<OneHourSaleService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowLocalhost3000",
            //        builder => builder.WithOrigins("http://localhost:3000") // Replace with your Next.js app's URL
            //                         .AllowAnyHeader()
            //                         .AllowAnyMethod());
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseCors("AllowLocalhost3000");
            app.UseHttpsRedirection();
            
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}