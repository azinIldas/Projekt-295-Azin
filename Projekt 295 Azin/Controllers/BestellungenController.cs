using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_295_Azin.Models;
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
        /// Gibt alle Bestellungen zurück.
        /// </summary>
        /// <returns>Liste aller Bestellungen.</returns>
        // GET: api/<BestellungenController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestellungen>>> Get()
        {
            return await _context.Bestellungens.ToListAsync();
        }

        /// <summary>
        /// Gibt eine spezifische Bestellung anhand ihrer ID zurück.
        /// </summary>
        /// <param name="id">Die ID der Bestellung.</param>
        /// <returns>Die angeforderte Bestellung.</returns>
        // GET api/<BestellungenController>/5
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
        /// Fügt eine neue Bestellung hinzu.
        /// </summary>
        /// <param name="bestellung">Die hinzuzufügende Bestellung.</param>
        /// <returns>Die erstellte Bestellung.</returns>
        // POST api/<BestellungenController>
        [HttpPost]
        public async Task<ActionResult<Bestellungen>> PostBestellungen(Bestellungen bestellung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bestellungens.Add(bestellung);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = bestellung.BestellungsId }, bestellung);
        }

        /// <summary>
        /// Aktualisiert eine vorhandene Bestellung.
        /// </summary>
        /// <param name="id">Die ID der zu aktualisierenden Bestellung.</param>
        /// <param name="bestellung">Die aktualisierten Daten der Bestellung.</param>
        /// <returns>Ein Ergebnis ohne Inhalt, wenn die Aktualisierung erfolgreich war.</returns>
        // PUT api/<BestellungenController>/5
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

        // Überprüft, ob eine Bestellung mit der gegebenen ID existiert.
        private bool BestellungExists(int id)
        {
            return _context.Bestellungens.Any(e => e.BestellungsId == id);
        }

        /// <summary>
        /// Löscht eine spezifische Bestellung anhand ihrer ID.
        /// </summary>
        /// <param name="id">Die ID der zu löschenden Bestellung.</param>
        /// <returns>Ein Ergebnis ohne Inhalt, wenn das Löschen erfolgreich war.</returns>
        // DELETE api/<BestellungenController>/5
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
    }
}
