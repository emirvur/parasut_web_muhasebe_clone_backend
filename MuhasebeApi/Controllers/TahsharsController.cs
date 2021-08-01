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
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TahsharsController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public TahsharsController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Tahshars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tahshar>>> GetTahshar()
        {
            return await _context.Tahshar.ToListAsync();
        }

        // GET: api/Tahshars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tahshar>> GetTahshar(int id)
        {
            var tahshar = await _context.Tahshar.FindAsync(id);

            if (tahshar == null)
            {
                return NotFound();
            }

            return tahshar;
        }

        [HttpGet("f/{id}")]
        public async Task<ActionResult<IEnumerable<dtothasharsatfat>>> GetsatTahshar(int id)
        {
            var tahshar = await _context.Tahshar.Where(a=>a.Tahsid==id).OrderByDescending(h => h.Tediltar).Select(v => new dtothasharsatfat(v.Thid,v.Tahsid,v.Tediltar,v.Kasaid,v.Kasa.KasaAd,v.Aciklama
                ,v.Alinmismik,v.Kasa.KasaAd
                   )).ToListAsync();



            return tahshar;
        }


        // PUT: api/Tahshars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTahshar(int id, Tahshar tahshar)
        {
            if (id != tahshar.Thid)
            {
                return BadRequest();
            }

            _context.Entry(tahshar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TahsharExists(id))
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

        // POST: api/Tahshars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tahshar>> PostTahshar(Tahshar tahshar)
        {
            _context.Tahshar.Add(tahshar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTahshar", new { id = tahshar.Thid }, tahshar);
        }

        // DELETE: api/Tahshars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tahshar>> DeleteTahshar(int id)
        {
            var tahshar = await _context.Tahshar.FindAsync(id);
            if (tahshar == null)
            {
                return NotFound();
            }

            _context.Tahshar.Remove(tahshar);
            await _context.SaveChangesAsync();

            return tahshar;
        }

        private bool TahsharExists(int id)
        {
            return _context.Tahshar.Any(e => e.Thid == id);
        }
    }
}
