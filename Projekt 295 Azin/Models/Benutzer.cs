using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt_295_Azin.Models
{
    /// <summary>
    /// Die Klasse 'Benutzer' repräsentiert einen Benutzer innerhalb des Projekts
    /// </summary>
    public class Benutzer
    {
        /// <summary>
        /// Eindeutige ID für jeden Benutzer
        /// </summary>
        [Key] // Markiert als Primärschlüssel
        public int BenutzerID { get; set; }

        /// <summary>
        /// Name des Benutzers. Erforderlich.
        /// </summary>
        [Required(ErrorMessage = "Name ist erforderlich")]
        [StringLength(255)] 
        public string Name { get; set; }

        /// <summary>
        /// Passwort des Benutzers. Erforderlich
        /// </summary>
        [Required(ErrorMessage = "Passwort ist erforderlich")]
        [StringLength(255)] 
        public string Password { get; set; }

        /// <summary>
        /// Adminstatus des Benutzers
        /// </summary>
        public bool AdminStatus { get; set; }

        /// <summary>
        /// JWT token
        /// </summary>
        public string? JWT { get; set; }
    }
}
