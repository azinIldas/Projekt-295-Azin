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
        public string Name { get; set; }

        // Validiert die E-Mail-Adresse mit einem regulären Ausdruck.
        // Die E-Mail muss dem Format 'name@domain.tld' entsprechen.
        [Required(ErrorMessage = "Email ist erforderlich")]
        [RegularExpression(@".+@.+\..+", ErrorMessage = "Ungültige Email-Adresse")]
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
