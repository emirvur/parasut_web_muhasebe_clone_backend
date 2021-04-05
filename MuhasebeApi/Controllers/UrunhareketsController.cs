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
    public class UrunhareketsController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public UrunhareketsController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Urunharekets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urunhareket>>> GetUrunhareket()
        {
            return await _context.Urunhareket.ToListAsync();
        }

        // GET: api/Urunharekets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urunhareket>> GetUrunhareket(int id)
        {
            var urunhareket = await _context.Urunhareket.FindAsync(id);

            if (urunhareket == null)
            {
                return NotFound();
            }

            return urunhareket;
        }


        [HttpGet("b/{bn}")]
        public async Task<ActionResult<IEnumerable<dtourungecmisi>>> GetUrungecmisi(int bn)
        {
            return await _context.Urunhareket.Where(a=>a.Barkodno==bn).Include(c => c.Fat).Select(v => new dtourungecmisi(v.Fatid??-1,v.Fat.FatTur,v.Fat.Duztarih, v.Miktar, v.Fat.Cari.Cariunvani
                 )).ToListAsync();
        }
        [HttpGet("f/{fid}")]
        public async Task<ActionResult<IEnumerable<dtourunhareket>>> geturunhareketfat(int fid)
        {
            return await _context.Urunhareket.Include(c => c.Fat).Where(m=>m.Fatid==fid).Select(v => new dtourunhareket(v.Fatid ?? -1, v.Barkodno,
              v.Miktar, v.Brfiyat,v.Vergi??0, v.BarkodnoNavigation.Adi
                     )).ToListAsync();
        }


        [HttpGet("st/{id}")]
        public async Task<ActionResult<IEnumerable<dtostokdetaysat>>> getstoksatis(int id)
        {
            return await _context.Urunhareket.Where(m => m.Barkodno == id).Where(n=>n.Fat.FatTur==1).Include(c => c.Fat).Select(v => new dtostokdetaysat(v.Fatid ?? -1, v.Barkodno,
                  v.Miktar, v.Brfiyat, v.Vergi ?? 0, v.Fat.Cari.Cariunvani,v.Fat.Duztarih,v.Fat.Fataciklama
                         )).ToListAsync();
        }

        [HttpGet("al/{id}")]
        public async Task<ActionResult<IEnumerable<dtostokdetaysat>>> getsstokalis(int id)
        {
            return await _context.Urunhareket.Where(m => m.Barkodno == id).Where(n => n.Fat.FatTur == 0).Include(c => c.Fat).Select(v => new dtostokdetaysat(v.Fatid ?? -1, v.Barkodno,
                      v.Miktar, v.Brfiyat, v.Vergi ?? 0, v.Fat.Cari.Cariunvani, v.Fat.Duztarih, v.Fat.Fataciklama
                             )).ToListAsync();
        }




        [HttpGet("g")]
        public async Task<ActionResult<IEnumerable<dtostokgecmisi>>> GetgeneelUrungecmisi()
        {
            return await _context.Urunhareket.Include(c => c.Fat).Select(v => new dtostokgecmisi(v.Fatid ?? -1, v.Fat.FatTur, 
                v.Fat.Duztarih, v.Miktar, v.Fat.Cari.Cariunvani,v.BarkodnoNavigation.Adi
                     )).ToListAsync();
        }


        // PUT: api/Urunharekets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrunhareket(int id, Urunhareket urunhareket)
        {
            if (id != urunhareket.Urharid)
            {
                return BadRequest();
            }

            _context.Entry(urunhareket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunhareketExists(id))
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

        // POST: api/Urunharekets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Urunhareket>> PostUrunhareket(List<Urunhareket> urunhareket)
        {
            _context.Urunhareket.AddRange(urunhareket);
            await _context.SaveChangesAsync();

            return Ok();//CreatedAtAction("GetUrunhareket", new { id = urunhareket.Urharid }, urunhareket);
        }

        // DELETE: api/Urunharekets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Urunhareket>> DeleteUrunhareket(int id)
        {
            var urunhareket = await _context.Urunhareket.FindAsync(id);
            if (urunhareket == null)
            {
                return NotFound();
            }

            _context.Urunhareket.Remove(urunhareket);
            await _context.SaveChangesAsync();

            return urunhareket;
        }

        private bool UrunhareketExists(int id)
        {
            return _context.Urunhareket.Any(e => e.Urharid == id);
        }
    }
}
