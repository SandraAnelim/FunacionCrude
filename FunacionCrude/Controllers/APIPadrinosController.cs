using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FunacionCrude.Models.DAL;
using FunacionCrude.Models.Entities;

namespace FunacionCrude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIPadrinosController : ControllerBase
    {
        private readonly DbContextFundacion _context;

        public APIPadrinosController(DbContextFundacion context)
        {
            _context = context;
        }

        // GET: api/APIPadrinos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Padrino>>> GetPadrinos()
        {
            return await _context.Padrinos.ToListAsync();
        }

        // GET: api/APIPadrinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Padrino>> GetPadrino(int id)
        {
            var padrino = await _context.Padrinos.FindAsync(id);

            if (padrino == null)
            {
                return NotFound();
            }

            return padrino;
        }

        // PUT: api/APIPadrinos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPadrino(int id, Padrino padrino)
        {
            if (id != padrino.PadrinoId)
            {
                return BadRequest();
            }

            _context.Entry(padrino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadrinoExists(id))
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

        // POST: api/APIPadrinos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Padrino>> PostPadrino(Padrino padrino)
        {
            _context.Padrinos.Add(padrino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPadrino", new { id = padrino.PadrinoId }, padrino);
        }

        // DELETE: api/APIPadrinos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Padrino>> DeletePadrino(int id)
        {
            var padrino = await _context.Padrinos.FindAsync(id);
            if (padrino == null)
            {
                return NotFound();
            }

            _context.Padrinos.Remove(padrino);
            await _context.SaveChangesAsync();

            return padrino;
        }

        private bool PadrinoExists(int id)
        {
            return _context.Padrinos.Any(e => e.PadrinoId == id);
        }
    }
}
