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
    public class KasaharsController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public KasaharsController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Kasahars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kasahar>>> GetKasahar()
        {
            return await _context.Kasahar.ToListAsync();
        }

        [HttpGet("t/{id}")]
        public async Task<ActionResult<IEnumerable<dtokasahar>>> GetozelKasahar(int id)
        {
            return await _context.Kasahar.Where(c=>c.Kasaid==id).Include(a=>a.Th).Include(b=>b.Oh)
                 .Select(v => new dtokasahar(v.Netbakiye, v.Durum, v.Miktar, v.Miktaraciklamasi,
                 v.Th.Tahsid, v.Th.Tediltar,
             v.Th.Kasaid, v.Th.Aciklama, v.Th.Alinmismik,
             v.Oh.Odeid, v.Oh.Odenmistar, v.Oh.Kasaid, v.Oh.Aciklama, v.Oh.Odendimik,v.Th.Tahs.Fatad,v.Oh.Ode.Fatad
                    ))
                .ToListAsync();
        }


        // GET: api/Kasahars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kasahar>> GetKasahar(int id)
        {
            var kasahar = await _context.Kasahar.FindAsync(id);

            if (kasahar == null)
            {
                return NotFound();
            }

            return kasahar;
        }

        // PUT: api/Kasahars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKasahar(int id, Kasahar kasahar)
        {
            if (id != kasahar.Khid)
            {
                return BadRequest();
            }

            _context.Entry(kasahar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KasaharExists(id))
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

        // POST: api/Kasahars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Kasahar>> PostKasahar(Kasahar kasahar)
        {
            _context.Kasahar.Add(kasahar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKasahar", new { id = kasahar.Khid }, kasahar);
        }

        // DELETE: api/Kasahars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kasahar>> DeleteKasahar(int id)
        {
            var kasahar = await _context.Kasahar.FindAsync(id);
            if (kasahar == null)
            {
                return NotFound();
            }

            _context.Kasahar.Remove(kasahar);
            await _context.SaveChangesAsync();

            return kasahar;
        }

        private bool KasaharExists(int id)
        {
            return _context.Kasahar.Any(e => e.Khid == id);
        }
    }
}
