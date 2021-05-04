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
    public class UrunsController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public UrunsController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Uruns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtourun>>> GetUrun()
        {
            return await _context.Urun.Include(c=>c.Kategori).Select(v=>new dtourun(v.Barkodno,v.Adi,v.KategoriId
                ,v.Kategori.Katadi,v.Birim,v.Krseviye,v.Verharal,v.Verharsat,v.Kdv,v.Adet)).ToListAsync();
        }
        [HttpGet("ac")]
        public async Task<ActionResult<IEnumerable<dtourun>>> GetazdancogaUrun()
        {
            return await _context.Urun.Include(c => c.Kategori).OrderBy(o => o.Adet).Select(v => new dtourun(v.Barkodno, v.Adi, v.KategoriId
                  , v.Kategori.Katadi, v.Birim, v.Krseviye, v.Verharal, v.Verharsat, v.Kdv, v.Adet)).ToListAsync();
        }
        [HttpGet("ca")]
        public async Task<ActionResult<IEnumerable<dtourun>>> GetcoktanazaUrun()
        {
            return await _context.Urun.Include(c => c.Kategori).OrderByDescending(o => o.Adet).Select(v => new dtourun(v.Barkodno, v.Adi, v.KategoriId
                  , v.Kategori.Katadi, v.Birim, v.Krseviye, v.Verharal, v.Verharsat, v.Kdv, v.Adet)).ToListAsync();
        }


        [HttpGet("r")]
        public async Task<ActionResult<stokrapor>> Getstokrapor()
        {
            //var tot1 = await _context.Urun.SumAsync(g => g.Verharal);
           // var tot2 = await _context.Urun.SumAsync(g => g.Verharsat);
         //   stokrapor st = new stokrapor(tot1,tot2);

            //    return st;

            return await _context.Urun.GroupBy(x => true)
          .Select(x => new stokrapor(x.Sum(y => y.Adet*y.Verharal),x.Sum(y => y.Adet*y.Verharsat)
          )).FirstOrDefaultAsync();
        }


        [HttpGet("a/{ad}")]
        public async Task<ActionResult<IEnumerable<dtourun>>> GetListUrun(string ad)
        {

            return await _context.Urun.Where(c=>c.Adi.Contains(ad))
                .Select(v => new dtourun(v.Barkodno, v.Adi, v.KategoriId
                , v.Kategori.Katadi, v.Birim, v.Krseviye, v.Verharal, v.Verharsat, v.Kdv, v.Adet)).ToListAsync();
         
        }


        // GET: api/Uruns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urun>> GetUrun(int id)
        {
            var urun = await _context.Urun.FindAsync(id);

            if (urun == null)
            {
                return NotFound();
            }

            return urun;
        }

        // PUT: api/Uruns/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrun(int id, Urun urun)
        {
            if (id != urun.Barkodno)
            {
                return BadRequest();
            }

            _context.Entry(urun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExists(id))
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

        // POST: api/Uruns
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Urun>> PostUrun(Urun urun)
        {
            _context.Urun.Add(urun);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UrunExists(urun.Barkodno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUrun", new { id = urun.Barkodno }, urun);
        }

        // DELETE: api/Uruns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Urun>> DeleteUrun(int id)
        {
            var urun = await _context.Urun.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            _context.Urun.Remove(urun);
            await _context.SaveChangesAsync();

            return urun;
        }

        private bool UrunExists(int id)
        {
            return _context.Urun.Any(e => e.Barkodno == id);
        }
    }
}
