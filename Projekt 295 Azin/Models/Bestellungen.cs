using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt_295_Azin.Models
{
    public class Bestellungen
    {
        public int BestellungsId { get; set; }

        [Required(ErrorMessage = "Name ist erforderlich")]
        [RegularExpression(@"^[a-zA-ZäöüßÄÖÜ\s]+$", ErrorMessage = "Name darf nur Buchstaben enthalten")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email-Adresse ist erforderlich")]
        [EmailAddress(ErrorMessage = "Ungültige Email-Adresse")]
        [RegularExpression(@".+@.+\..+ch$", ErrorMessage = "Email-Adresse muss mit '.ch' enden")]
        public string Emailadresse { get; set; }

        [Required(ErrorMessage = "Telefonnummer ist erforderlich")]
        [RegularExpression(@"^\+?[0-9\s]+$", ErrorMessage = "Ungültige Telefonnummer")]
        public string Telefonnummer { get; set; }

        [Required(ErrorMessage = "Lieferdatum ist erforderlich")]
        public DateTime Lieferdatum { get; set; }

        [Required(ErrorMessage = "Service ist erforderlich")]
        public string Service { get; set; }

    }
}
