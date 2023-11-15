using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Projekt_295_Azin.Models;
using System;

namespace Projekt_295_Azin.Tests
{
    /// <summary>
    /// Testklasse für Bestellungen.
    /// </summary>
    [TestFixture]
    public class BestellungenTests
    {
        /// <summary>
        /// Testet, ob eine Bestellung mit initialen Werten korrekt erstellt werden kann.
        /// </summary>
        [Test]
        public void BestellungKannErstelltWerdenMitInitialWerten()
        {
            // Vorbereitung (Arrangieren) der Testdaten und Ausführung (Handeln) der zu testenden Funktionalität.
            var bestellung = new Bestellungen
            {
                BestellungsId = 1,
                Name = "Max Mustermann",
                Emailadresse = "max@example.com",
                Telefonnummer = "0123456789",
                Lieferdatum = DateTime.Now,
                Service = "Standard"
            };

            // Überprüfung (Bestätigen) der korrekten Erstellung der Bestellung mit den angegebenen Werten.
            Assert.AreEqual(1, bestellung.BestellungsId);
            Assert.AreEqual("Max Mustermann", bestellung.Name);
            Assert.AreEqual("max@example.com", bestellung.Emailadresse);
            Assert.AreEqual("0123456789", bestellung.Telefonnummer);
            // Überprüfung, ob das Lieferdatum innerhalb eines akzeptablen Zeitfensters liegt.
            Assert.That(bestellung.Lieferdatum, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(5)));
            Assert.AreEqual("Standard", bestellung.Service);
        }
    }
}
