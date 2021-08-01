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
    public class OdeharsController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public OdeharsController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Odehars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odehar>>> GetOdehar()
        {
            return await _context.Odehar.ToListAsync();
        }

        // GET: api/Odehars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odehar>> GetOdehar(int id)
        {
            var odehar = await _context.Odehar.FindAsync(id);

            if (odehar == null)
            {
                return NotFound();
            }

            return odehar;
        }


        [HttpGet("f/{id}")]
        public async Task<ActionResult<IEnumerable<dtoodeharsatfat>>> GetsatTahshar(int id)
        {
            var tahshar = await _context.Odehar.Where(a => a.Odeid == id).OrderByDescending(h => h.Odenmistar).Select(v => new dtoodeharsatfat(v.Ohid, v.Odeid,
                v.Odenmistar, v.Kasaid, v.Kasa.KasaAd, v.Aciklama
                    , v.Odendimik, v.Kasa.KasaAd
                       )).ToListAsync();



            return tahshar;
        }


        // PUT: api/Odehars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdehar(int id, Odehar odehar)
        {
            if (id != odehar.Ohid)
            {
                return BadRequest();
            }

            _context.Entry(odehar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdeharExists(id))
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

        // POST: api/Odehars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Odehar>> PostOdehar(Odehar odehar)
        {
            _context.Odehar.Add(odehar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdehar", new { id = odehar.Ohid }, odehar);
        }

        // DELETE: api/Odehars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Odehar>> DeleteOdehar(int id)
        {
            var odehar = await _context.Odehar.FindAsync(id);
            if (odehar == null)
            {
                return NotFound();
            }

            _context.Odehar.Remove(odehar);
            await _context.SaveChangesAsync();

            return odehar;
        }

        private bool OdeharExists(int id)
        {
            return _context.Odehar.Any(e => e.Ohid == id);
        }
    }
}
