using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projekt_295_Azin.Models;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bestellungen> Bestellungens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=BackendSkiService;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
