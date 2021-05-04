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
    public class TahsilatsController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public TahsilatsController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Tahsilats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tahsilat>>> GetTahsilat()
        {
            return await _context.Tahsilat.ToListAsync();
        }

        // GET: api/Tahsilats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tahsilat>> GetTahsilat(int id)
        {
            var tahsilat = await _context.Tahsilat.FindAsync(id);

            if (tahsilat == null)
            {
                return NotFound();
            }

            return tahsilat;
        }

        // PUT: api/Tahsilats/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutTahsilat(tahsput tp)
        {
          Tahsilat tah =await _context.Tahsilat.SingleOrDefaultAsync(p => p.Tahsid == tp.id);

            if ((tah.Topmik-tah.Alinmismik) - tp.alinmismik == 0)
            {
              List<Fatura> w= await _context.Fatura.Where(u => u.Tahsid == tp.id).ToListAsync();
                w[0].Durum = 1;
               
                tah.Durum = 1;
                tah.Alinmismik = tp.toplam;
            }
            else {
                tah.Alinmismik = tah.Alinmismik + tp.alinmismik;
            }
            Tahshar har = new Tahshar();
   har.Tahsid = tp.id;
            har.Tediltar = tp.tedt;
            har.Kasaid = tp.kasid;
            har.Aciklama = tp.acik;
            har.Alinmismik = tp.alinmismik;

       //     Kasa kasa = await _context.Kasa.FindAsync(tp.kasid);
         //           kasa.Bakiye = kasa.Bakiye + tp.alinmismik;
    
            
       /*     Kasahar kashar = new Kasahar { };
            kashar.Kasaid = tp.kasid;
            kashar.Durum = 1;
            kashar.Miktar = tp.alinmismik;
            kashar.Miktaraciklamasi = tp.acik;
          //  kashar.Thid = tp.id;
            List<Kasahar> khcol = new List<Kasahar>();
            khcol.Add(kashar);
            kasa.Kasahar = khcol;*/

        //    har.Kasa = kasa;

          //  tah.Kasa = kasa;

            _context.Tahshar.Add(har);
            await _context.SaveChangesAsync();
            Kasahar kashar = new Kasahar { };
            kashar.Kasaid = tp.kasid;
            kashar.Durum = 1;
            kashar.Miktar = tp.alinmismik;
            kashar.Miktaraciklamasi = tp.acik;
            kashar.Thid = har.Thid;
            kashar.Netbakiye = -1;
            _context.Kasahar.Add(kashar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TahsilatExists(tp.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Tahsilats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tahsilat>> PostTahsilat(Tahsilat tahsilat)
        {
            _context.Tahsilat.Add(tahsilat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTahsilat", new { id = tahsilat.Tahsid }, tahsilat);
        }

        // DELETE: api/Tahsilats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tahsilat>> DeleteTahsilat(int id)
        {
            var tahsilat = await _context.Tahsilat.FindAsync(id);
            if (tahsilat == null)
            {
                return NotFound();
            }

            _context.Tahsilat.Remove(tahsilat);
            await _context.SaveChangesAsync();

            return tahsilat;
        }

        private bool TahsilatExists(int id)
        {
            return _context.Tahsilat.Any(e => e.Tahsid == id);
        }
    }
}
