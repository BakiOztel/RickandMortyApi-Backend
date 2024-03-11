using App.Application;
using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using RickandMortyApi.Auth;

namespace RickandMortyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCoreApplication();
            builder.Services.AddDbContext<AppDataContext>(options =>
            {
                options.UseLazyLoadingProxies(false);
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
            });
            builder.Services.AddScoped<ApiKeyAuthFilter>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}