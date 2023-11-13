using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_295_Azin.Models;
using Projekt_295_Azin.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt_295_Azin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellungenController : ControllerBase
    {
        private readonly BlogContext _context;

        public BestellungenController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/<BestellungenController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestellungen>>> Get()
        {
            return await _context.Bestellungens.ToListAsync();
        }

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

        // POST api/<BestellungenController>
        [HttpPost]
        public async Task<ActionResult<Bestellungen>> PostBestellungen(Bestellungen bestellung)
        {
            _context.Bestellungens.Add(bestellung);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = bestellung.BestellungsId }, bestellung);
        }




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

        private bool BestellungExists(int id)
        {
            return _context.Bestellungens.Any(e => e.BestellungsId == id);
        }



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

