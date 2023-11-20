using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Projekt_295_Azin.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Projekt_295_Azin.Controllers
{
    /// <summary>
    /// Kontroller für das Benutzer-Logging
    /// </summary>
    public class BenutzerLoggingController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly BlogContext _context;

        /// <summary>
        /// Konstruktor für BenutzerLoggingController
        /// </summary>
        /// <param name="config">Konfiguration</param>
        /// <param name="context">Datenbankkontext</param>
        public BenutzerLoggingController(IConfiguration config, BlogContext context)
        {
            _config = config;
            _context = context;
        }

        /// <summary>
        /// Login-Methode für Benutzer
        /// </summary>
        /// <param name="login">Login-Daten</param>
        /// <returns>Antwort des Servers</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            // Überprüfung des Benutzernamens und Passworts
            var user = await _context.Benutzer.FirstOrDefaultAsync(u => u.Name == login.Username);
            if (user != null && ValidatePassword(login.Password, user.Password))
            {
                var token = GenerateJwtToken(user);

                // Token im Benutzermodell speichern und Datenbank aktualisieren
                user.JWT = token;
                _context.Benutzer.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new { token });
            }

            return Unauthorized();
        }

        /// <summary>
        /// Generiert ein JWT-Token für den Benutzer
        /// </summary>
        /// <param name="user">Benutzerobjekt</param>
        /// <returns>JWT-Token als String</returns>
        private string GenerateJwtToken(Benutzer user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Erstellen von Ansprüchen für das Token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Weitere Ansprüche nach Bedarf hinzufügen
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Validiert das Passwort
        /// </summary>
        /// <param name="inputPassword">Eingegebenes Passwort</param>
        /// <param name="storedPassword">Gespeichertes Passwort</param>
        /// <returns>Wahr, wenn das Passwort übereinstimmt</returns>
        private bool ValidatePassword(string inputPassword, string storedPassword)
        {
            // Implementieren Sie hier eine sicherere Passwortvergleichslogik
            return inputPassword == storedPassword;
        }
    }

    /// <summary>
    /// Modell für Login-Daten
    /// </summary>
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
