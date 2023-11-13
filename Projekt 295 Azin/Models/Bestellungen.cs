using System;
using System.Collections.Generic;

namespace Projekt_295_Azin.Models;

public partial class Bestellungen
{
    public int BestellungsId { get; set; }

    public string Name { get; set; } = null!;

    public string Emailadresse { get; set; } = null!;

    public string? Telefonnummer { get; set; }

    public DateTime? Lieferdatum { get; set; }

    public string? Service { get; set; }
}
