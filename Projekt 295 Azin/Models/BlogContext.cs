using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Projekt_295_Azin.Models;

namespace Projekt_295_Azin.Models;

/// <summary>
/// Kontextklasse für den Blog welches den DbContext mit Entity Framework core erweitert
/// </summary>
public partial class BlogContext : DbContext
{
    /// <summary>
    /// Standardkonstruktor für BlogContext
    /// </summary>
    public BlogContext()
    {
    }

    /// <summary>
    /// Konstruktor für BlogContext mit DbContext Optionen.
    /// </summary>
    /// <param name="options">Die Konfigurationsoptionen für den DbContext.</param>
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Definiert die Bestellungen Entität als DbSet
    /// </summary>
    public virtual DbSet<Bestellungen> Bestellungens { get; set; }

    // Fügen Sie diese Zeile hinzu
    public virtual DbSet<Benutzer> Benutzer { get; set; }

    // Konfiguration des Datenbankkontextes
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BackendSkiService;Trusted_Connection=True;TrustServerCertificate=True;");

    /// <summary>
    /// Konfiguriert das Modell beim Erstellen des DbContext-Modells
    /// </summary>
    /// <param name="modelBuilder">Bietet APIs zum Konfigurieren des Modells für eine DbContext.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfiguration der Bestellungen Entität: Definiert den Schlüssel, den Tabellennamen und  die Feldkonfigurationen
        modelBuilder.Entity<Bestellungen>(entity =>
        {
            entity.HasKey(e => e.BestellungsId).HasName("PK__Bestellu__9DBF7CCC91C01A54");

            entity.ToTable("Bestellungen");

            entity.Property(e => e.BestellungsId).HasColumnName("BestellungsID");
            entity.Property(e => e.Emailadresse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Lieferdatum).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Service)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefonnummer)
                .HasMaxLength(20)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Benutzer>(entity =>
        {
            entity.HasKey(e => e.BenutzerID).HasName("PK_Benutzer");

            entity.ToTable("Benutzer");

            entity.Property(e => e.BenutzerID).HasColumnName("BenutzerID");
            entity.Property(e => e.Name).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.AdminStatus).HasColumnType("bit");
            entity.Property(e => e.JWT).IsUnicode(false);
            ;
        });
    OnModelCreatingPartial(modelBuilder);
    }

    // Zusätzliche partielle Methode für erweiterte Konfigurationen
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
