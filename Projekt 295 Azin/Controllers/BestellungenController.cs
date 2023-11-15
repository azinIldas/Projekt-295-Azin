using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_295_Azin.Models;

namespace Projekt_295_Azin.Controllers
{
    /// <summary>
    /// Controller für die Verwaltung von Bestellungen.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BestellungenController : ControllerBase
    {
        private readonly BlogContext _context;

        /// <summary>
        /// Konstruktor des BestellungenControllers.
        /// </summary>
        /// <param name="context">Der Datenbankkontext.</param>
        public BestellungenController(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ruft alle Bestellungen ab.
        /// </summary>
        /// <returns>Eine Aktionsergebnisinstanz mit der Liste aller Bestellungen.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestellungen>>> Get()
        {
            return await _context.Bestellungens.ToListAsync();
        }

        /// <summary>
        /// Ruft eine Bestellung anhand ihrer eindeutigen ID ab.
        /// </summary>
        /// <param name="id">Die ID der Bestellung, die abgerufen werden soll.</param>
        /// <returns>Die Bestellung, wenn sie gefunden wurde, andernfalls ein NotFound-Ergebnis.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Bestellungen>> Get(int id)
        {
            var bestellung = await _context.Bestellungens.FindAsync(id);

            if (bestellung == null)
            {
                return NotFound();
            }

            return bestellung;
        }

        /// <summary>
        /// Erstellt eine neue Bestellung.
        /// </summary>
        /// <param name="bestellung">Das Bestellungsobjekt, das erstellt werden soll.</param>
        /// <returns>Ein CreatedAtAction-Ergebnis mit der neu erstellten Bestellung.</returns>
        [HttpPost]
        public async Task<ActionResult<Bestellungen>> PostBestellungen(Bestellungen bestellung)
        {
            _context.Bestellungens.Add(bestellung);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = bestellung.BestellungsId }, bestellung);
        }

        /// <summary>
        /// Aktualisiert eine bestehende Bestellung anhand ihrer ID mit den angegebenen Daten.
        /// </summary>
        /// <param name="id">Die ID der zu aktualisierenden Bestellung.</param>
        /// <param name="bestellung">Die neuen Daten für die Bestellung.</param>
        /// <returns>Ein NoContent-Ergebnis, wenn die Aktualisierung erfolgreich war.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestellung(int id, Bestellungen bestellung)
        {
            if (id != bestellung.BestellungsId)
            {
                return BadRequest();
            }

            _context.Entry(bestellung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellungExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Löscht eine Bestellung anhand ihrer ID.
        /// </summary>
        /// <param name="id">Die ID der Bestellung, die gelöscht werden soll.</param>
        /// <returns>Ein NoContent-Ergebnis, wenn das Löschen erfolgreich war.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bestellung = await _context.Bestellungens.FindAsync(id);
            if (bestellung == null)
            {
                return NotFound();
            }

            _context.Bestellungens.Remove(bestellung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Überprüft, ob eine Bestellung mit der gegebenen ID existiert.
        /// </summary>
        /// <param name="id">Die zu überprüfende ID.</param>
        /// <returns>True, wenn die Bestellung existiert, andernfalls False.</returns>
        private bool BestellungExists(int id)
        {
            return _context.Bestellungens.Any(e => e.BestellungsId == id);
        }
    }
}
