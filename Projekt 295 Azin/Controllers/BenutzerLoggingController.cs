using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Projekt_295_Azin;
using Projekt_295_Azin.Models; 
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Projekt_295_Azin.Controllers
{
    /// <summary>
    /// Controller zur Handhabung der Benutzer-Authentifizierung
    /// </summary>
    public class BenutzerLoggingController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly BlogContext _context;

        /// <summary>
        /// Konstruktor für BenutzerLoggingController
        /// </summary>
        /// <param name="config">Konfigurationseinstellungen</param>
        /// <param name="context">Datenbankkontext</param>
        public BenutzerLoggingController(IConfiguration config, BlogContext context)
        {
            _config = config;
            _context = context;
        }

        /// <summary>
        /// API-Endpunkt für Benutzer-Login
        /// </summary>
        /// <param name="login">Login-Modell mit Benutzername und Passwort</param>
        /// <returns>JWT-Token bei erfolgreicher Authentifizierung, ansonsten Unauthorized</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var token = GenerateJWTToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        /// <summary>
        /// Authentifiziert einen Benutzer basierend auf den Login-Daten
        /// </summary>
        /// <param name="login">Login-Daten des Benutzers</param>
        /// <returns>Benutzerobjekt bei erfolgreicher Authentifizierung, ansonsten null</returns>
        private Benutzer AuthenticateUser(LoginModel login)
        {
            var hashedPassword = HashPassword(login.Password);
            return _context.Benutzer.FirstOrDefault(u => u.Name == login.Username && u.Password == hashedPassword);
        }

        /// <summary>
        /// Erzeugt ein JWT für einen authentifizierten Benutzer
        /// </summary>
        /// <param name="user">Authentifizierter Benutzer</param>
        /// <returns>JWT-Token als String</returns>
        private string GenerateJWTToken(Benutzer user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim("AdminStatus", user.AdminStatus.ToString()),
                // Weitere Ansprüche können hier hinzugefügt werden
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Erzeugt einen Hashwert für ein Passwort
        /// </summary>
        /// <param name="password">Das zu hashende Passwort</param>
        /// <returns>Der Hashwert des Passworts</returns>
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }

    /// <summary>
    /// Modell für Benutzer-Login-Daten
    /// </summary>
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
