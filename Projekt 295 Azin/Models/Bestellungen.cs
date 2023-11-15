using System;
using System.Collections.Generic;

namespace Projekt_295_Azin.Models;

/// <summary>
/// Repräsentiert eine Bestellung im System.
/// </summary>
public partial class Bestellungen
{
    // Eindeutige ID der Bestellung
    public int BestellungsId { get; set; }

    // Name des Bestellers
    public string Name { get; set; } = null!;

    // E-Mail-Adresse des Bestellers
    public string Emailadresse { get; set; } = null!;

    // Telefonnummer des Bestellers
    public string? Telefonnummer { get; set; }

    // Lieferdatum des Bestellers
    public DateTime? Lieferdatum { get; set; }

    // Serviceinformationen des Bestellers
    public string? Service { get; set; }
}
