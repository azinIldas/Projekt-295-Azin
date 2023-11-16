using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt_295_Azin.Models
{
    /// <summary>
    /// Die Klasse 'Bestellungen' repräsentiert eine Bestellung innerhalb des Projekts.
    /// Sie verwendet Datenannotations für die Validierung der Eigenschaften.
    /// </summary>
    public class Bestellungen
    {
        // Eindeutige ID für jede Bestellung
        public int BestellungsId { get; set; }

        [Required(ErrorMessage = "Name ist erforderlich")]
        [RegularExpression(@"^[a-zA-ZäöüßÄÖÜ\s]+$", ErrorMessage = "Name darf nur Buchstaben enthalten")]
        // Der Name des Bestellers ist erforderlich und darf nur Buchstaben enthalten (einschließlich Umlaute und ß).
        public string Name { get; set; }

        [Required(ErrorMessage = "Email-Adresse ist erforderlich")]
        [EmailAddress(ErrorMessage = "Ungültige Email-Adresse")]
        [RegularExpression(@".+@.+\..+ch$", ErrorMessage = "Email-Adresse muss mit '.ch' enden")]
        // Die Emailadresse des Bestellers ist erforderlich, muss ein gültiges Email-Format haben und mit '.ch' enden.
        public string Emailadresse { get; set; }

        [Required(ErrorMessage = "Telefonnummer ist erforderlich")]
        [RegularExpression(@"^\+?[0-9\s]+$", ErrorMessage = "Ungültige Telefonnummer")]
        // Die Telefonnummer ist erforderlich und muss ein gültiges Format haben (Zahlen und optional ein führendes Pluszeichen).
        public string Telefonnummer { get; set; }

        [Required(ErrorMessage = "Lieferdatum ist erforderlich")]
        // Das Lieferdatum ist ein erforderliches Feld, muss aber nicht weiter validiert werden, da DateTime immer ein gültiges Datum ist.
        public DateTime Lieferdatum { get; set; }

        [Required(ErrorMessage = "Service ist erforderlich")]
        // Der gewählte Service ist ein erforderliches Feld, aber es gibt keine weiteren Validierungsregeln in diesem Beispiel.
        public string Service { get; set; }

    }
}
