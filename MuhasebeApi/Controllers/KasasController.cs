using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhasebeApi.Models;

namespace MuhasebeApi.Controllers
{    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KasasController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public KasasController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Kasas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kasa>>> GetKasa()
        {
            return await _context.Kasa.ToListAsync();
        }

        [HttpGet("b")]
        public  ActionResult<double> GetKasabakiyr()
        {
            return  _context.Kasa.Sum(a=>a.Bakiye);
        }
        // GET: api/Kasas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kasa>> GetKasa(int id)
        {
            var kasa = await _context.Kasa.FindAsync(id);

            if (kasa == null)
            {
                return NotFound();
            }

            return kasa;
        }

        // PUT: api/Kasas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKasa(int id, Kasa kasa)
        {
            if (id != kasa.Kasaid)
            {
                return BadRequest();
            }

            _context.Entry(kasa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KasaExists(id))
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

        // POST: api/Kasas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Kasa>> PostKasa(Kasa kasa)
        {
            _context.Kasa.Add(kasa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKasa", new { id = kasa.Kasaid }, kasa);
        }

        // DELETE: api/Kasas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kasa>> DeleteKasa(int id)
        {
            var kasa = await _context.Kasa.FindAsync(id);
            if (kasa == null)
            {
                return NotFound();
            }

            _context.Kasa.Remove(kasa);
            await _context.SaveChangesAsync();

            return kasa;
        }

        private bool KasaExists(int id)
        {
            return _context.Kasa.Any(e => e.Kasaid == id);
        }
    }
}
