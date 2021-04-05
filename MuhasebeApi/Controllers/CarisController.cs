using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhasebeApi.Models;

namespace MuhasebeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarisController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public CarisController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Caris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cari>>> GetCari()
        {
            return await _context.Cari.ToListAsync();
        }

        [HttpGet("m")]
        public async Task<ActionResult<IEnumerable<dtocarilist>>> GetmusCari()
        {
            return await _context.Cari.Where(a=>a.Hangicari==1).Select(v => new dtocarilist(v.CariId, v.Cariunvani,
                v.Kat.Katadi, v.Bakiye
          
                   )).ToListAsync();
        }

        [HttpGet("t")]
        public async Task<ActionResult<IEnumerable<dtocarilist>>> getted()
        {
            return await _context.Cari.Where(a => a.Hangicari == 2).Select(v => new dtocarilist(v.CariId, v.Cariunvani,
                    v.Kat.Katadi, v.Bakiye

                       )).ToListAsync();
        }



        // GET: api/Caris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cari>> GetCari(int id)
        {
            var cari = await _context.Cari.FindAsync(id);

            if (cari == null)
            {
                return NotFound();
            }

            return cari;
        }



        [HttpGet("m/{ad}")]
        public async Task<ActionResult<IEnumerable<Cari>>> GetListcari(string ad)
        {

            return await _context.Cari.Where(a => a.Hangicari == 1).Where(c => c.Cariunvani.Contains(ad)).ToListAsync();

        }

        [HttpGet("t/{ad}")]
        public async Task<ActionResult<IEnumerable<Cari>>> GettedListcari(string ad)
        {

            return await _context.Cari.Where(a=>a.Hangicari==2).Where(c => c.Cariunvani.Contains(ad)).ToListAsync();

        }

        // PUT: api/Caris/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCari(int id, Cari cari)
        {
            if (id != cari.CariId)
            {
                return BadRequest();
            }

            _context.Entry(cari).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CariExists(id))
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

        // POST: api/Caris
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cari>> PostCari(Cari cari)
        {
            _context.Cari.Add(cari);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCari", new { id = cari.CariId }, cari);
        }

        // DELETE: api/Caris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cari>> DeleteCari(int id)
        {
            var cari = await _context.Cari.FindAsync(id);
            if (cari == null)
            {
                return NotFound();
            }

            _context.Cari.Remove(cari);
            await _context.SaveChangesAsync();

            return cari;
        }

        private bool CariExists(int id)
        {
            return _context.Cari.Any(e => e.CariId == id);
        }
    }
}
