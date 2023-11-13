using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Projekt_295_Azin.Models;
using Projekt_295_Azin.Models; // Namespace für Ihre Modelle
using System;

namespace Projekt_295_Azin.Tests
{
    [TestFixture]
    public class BestellungenTests
    {
        [Test]
        public void BestellungKannErstelltWerdenMitInitialWerten()
        {
            // Arrangieren & Handeln
            var bestellung = new Bestellungen
            {
                BestellungsId = 1,
                Name = "Max Mustermann",
                Emailadresse = "max@example.com",
                Telefonnummer = "0123456789",
                Lieferdatum = DateTime.Now,
                Service = "Standard"
            };

            // Bestätigen
            Assert.AreEqual(1, bestellung.BestellungsId);
            Assert.AreEqual("Max Mustermann", bestellung.Name);
            Assert.AreEqual("max@example.com", bestellung.Emailadresse);
            Assert.AreEqual("0123456789", bestellung.Telefonnummer);
            Assert.That(bestellung.Lieferdatum, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(5)));
            Assert.AreEqual("Standard", bestellung.Service);
        }


    }
}
