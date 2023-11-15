using Microsoft.EntityFrameworkCore;
using Projekt_295_Azin.Models;

namespace Projekt_295_Azin
{
    /// <summary>
    /// Hauptklasse der Anwendung welches den webdinst konfiguriert und startet
    /// </summary>
    public class Program
    {
        public static string _connectionString;

        /// <summary>
        /// Einstieggspunkt der Anwendung.
        /// </summary>
        /// <param name="args">Kommandozeilenargumente</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Konfiguration von CORS 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy",
                    builder => builder.WithOrigins("http://127.0.0.1:5500") 
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // Hinzufügen des ControllerServices zur Verarbeitung von HTTP Anfragen
            builder.Services.AddControllers();

            // Einrichtung von Swagger zur Dokumentation und Testung der API
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Extrahieren der Datenbankverbindungsinformationen aus der Konfiguration
            var configuration = builder.Configuration;
            _connectionString = configuration.GetConnectionString("BackendSkiService");

            // Konfiguration des Entity Frameworks für die Verbindung mit SQL Server
            builder.Services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(_connectionString));

            var app = builder.Build();

            // Konfiguration zusätzlicher Komponenten für die HTTP-Anforderungsverarbeitung
            if (app.Environment.IsDevelopment())
            {
                // Aktivieren von Swagger im Entwicklungsmodus
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aktivieren der HTTPS Umleitung zur Erhöhung der Sicherheit.
            app.UseHttpsRedirection();

            // Verwendung der konfigurierten CORS-Richtlinie.
            app.UseCors("MyCorsPolicy");

            // Einrichtung der Autorisierungsmiddleware.
            app.UseAuthorization();

            // Zuweisung der Controller-Endpunkte.
            app.MapControllers();

            // Starten der Webanwendung.
            app.Run();
        }
    }
}
