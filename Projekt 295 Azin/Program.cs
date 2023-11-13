using Microsoft.EntityFrameworkCore;
using Projekt_295_Azin.Models;
using Projekt_295_Azin.Models;

namespace Projekt_295_Azin
{
    public class Program
    {
        public static string _connectionString;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Konfigurieren Sie hier CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy",
                    builder => builder.WithOrigins("http://example.com") // Hier Ihre erlaubten Urspr�nge eintragen
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Configuration;
            _connectionString = configuration.GetConnectionString("BackendSkiService");
            builder.Services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(_connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Verwenden Sie hier Ihre CORS-Richtlinie
            app.UseCors("MyCorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
