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
    public class FaturasController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public FaturasController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Faturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fatura>>> GetFatura()
        {
            return await _context.Fatura.ToListAsync();
        }

        // GET: api/Faturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fatura>> GetFatura(int id)
        {
            var fatura = await _context.Fatura.FindAsync(id);


            if (fatura == null)
            {
                return NotFound();
            }

            return fatura;
        }
        [HttpGet("t/{id}")]
        public async Task<ActionResult<dtofattahs>> GetdetayFatura(int id)
        {
       
           
           return await _context.Fatura.Where(a => a.Fatid == id).Include(c => c.Tahs)
             .Select(v => new dtofattahs(v.Fatid,v.FatTur, v.Tahs.Durum, v.CariId,v.Cari.Cariunvani,v.Duztarih,
             v.Fataciklama,v.Kat.Katadi,v.Aratop,
             v.Araind??-1,v.Kdv??-1,v.Geneltoplam,v.Tahs.Vadetarih,v.Tahs.Tediltar,v.Tahs.Alinmismik ,v.Tahsid??-1
                    )).FirstOrDefaultAsync();

          
        }

        [HttpGet("o/{id}")]
        public async Task<ActionResult<dtofatode>> getalisfat(int id)
        {


            return await _context.Fatura.Where(a => a.Fatid == id).Include(c => c.Tahs)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).FirstOrDefaultAsync();


        }



        [HttpGet("lt")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetlistFatura()
        {


            return await _context.Fatura.Where(a=>a.FatTur==1).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur,v.Tahs.Durum ,v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("s/{ad}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetsatfarListUrun(string ad)
        {

            return await _context.Fatura.Where(a => a.FatTur == 1).Where(c => c.Fataciklama.Contains(ad))
                .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1)).ToListAsync();

        }

        [HttpGet("a/{ad}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetalfatListUrun(string ad)
        {

            return await _context.Fatura.Where(a => a.FatTur == 0).Where(c => c.Fataciklama.Contains(ad))
                .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1)).ToListAsync();

        }


        // PUT: api/Faturas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFatura(int id, Fatura fatura)
        {
            if (id != fatura.Fatid)
            {
                return BadRequest();
            }

            _context.Entry(fatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaturaExists(id))
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

        // POST: api/Faturas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Fatura>> PostFatura(postfatura pf)
        {
            if (pf.sipa.FatTur == 1)
            {
                Tahsilat tah = new Tahsilat { };
                tah.Kasaid = pf.sipa.kasaid;
                tah.Aciklama = pf.sipa.tahac ?? "";
                tah.Durum = pf.sipa.durum;
                if (pf.sipa.durum == 1)
                {
                    tah.Tediltar = pf.sipa.tedt;
                }
                else
                {
                    tah.Vadetarih = pf.sipa.vadt;

                }
           
                tah.Alinmismik = pf.sipa.alinm;
                tah.Topmik = pf.sipa.topm;
                tah.Fatad = pf.sipa.Fataciklama;
                tah.Duzt = pf.sipa.Duztarih;

                Fatura fa = new Fatura { };
                
                fa.Tahs = tah;
                fa.Geneltoplam = pf.sipa.topm;
                fa.Katid = 1;
                fa.CariId = pf.sipa.CariId;
                fa.Duztarih = pf.sipa.Duztarih;
                fa.FatTur = pf.sipa.FatTur;
                fa.Fataciklama = pf.sipa.Fataciklama;
                fa.Katid = pf.sipa.Katid;
                fa.Aratop = pf.sipa.Aratop;
                fa.Kdv = pf.sipa.Kdv;

                fa.Urunhareket = pf.hareket;

             
                _context.Fatura.Add(fa);
     
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFatura", new { id = fa.Fatid }, fa);
            }
            Odemeler ode = new Odemeler { };
            ode.Kasaid = pf.sipa.kasaid;
            ode.Aciklama = pf.sipa.tahac ?? "";
            ode.Durum = pf.sipa.durum;
            if (pf.sipa.durum == 1) {
                ode.Odenmistar = pf.sipa.vadt;
            }
            else
            {
                ode.Odenecektar = pf.sipa.tedt;
            }
          
            ode.Odendimik = pf.sipa.alinm;
            ode.Topmik = pf.sipa.topm;
            ode.Fatad = pf.sipa.Fataciklama;
            ode.Duzt = pf.sipa.Duztarih;

            Fatura fat = new Fatura { };
            fat.Ode = ode;
            fat.Geneltoplam = pf.sipa.topm;
            fat.Katid = 1;
            fat.CariId = pf.sipa.CariId;
            fat.Duztarih = pf.sipa.Duztarih;
            fat.FatTur = pf.sipa.FatTur;
            fat.Fataciklama = pf.sipa.Fataciklama;
            fat.Katid = pf.sipa.Katid;
            fat.Aratop = pf.sipa.Aratop;
            fat.Kdv = pf.sipa.Kdv;

            _context.Fatura.Add(fat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFatura", new { id = fat.Fatid }, fat);

            /*
      
                if (pf.FatTur == 1)
            {
                Tahsilat tah = new Tahsilat { };
                tah.Kasaid = pf.kasaid;
                tah.Aciklama = pf.tahac ?? "";
                tah.Durum = pf.durum;
                if (pf.durum == 1)
                {
                    tah.Tediltar = pf.tedt;
                }
                else
                {
                    tah.Vadetarih = pf.vadt;

                }
           
                tah.Alinmismik = pf.alinm;
                tah.Topmik = pf.topm;
                tah.Fatad = pf.Fataciklama;
                tah.Duzt = pf.Duztarih;

                Fatura fa = new Fatura { };
                
                fa.Tahs = tah;
                fa.Geneltoplam = pf.topm;
                fa.Katid = 1;
                fa.CariId = pf.CariId;
                fa.Duztarih = pf.Duztarih;
                fa.FatTur = pf.FatTur;
                fa.Fataciklama = pf.Fataciklama;
                fa.Katid = pf.Katid;
                fa.Aratop = pf.Aratop;
                fa.Kdv = pf.Kdv;

                fa.Urunhareket = pf.hareket;

             
                _context.Fatura.Add(fa);
     
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFatura", new { id = fa.Fatid }, fa);
            }
            Odemeler ode = new Odemeler { };
            ode.Kasaid = pf.kasaid;
            ode.Aciklama = pf.tahac ?? "";
            ode.Durum = pf.durum;
            if (pf.durum == 1) {
                ode.Odenmistar = pf.vadt;
            }
            else
            {
                ode.Odenecektar = pf.tedt;
            }
          
            ode.Odendimik = pf.alinm;
            ode.Topmik = pf.topm;
            ode.Fatad = pf.Fataciklama;
            ode.Duzt = pf.Duztarih;

            Fatura fat = new Fatura { };
            fat.Ode = ode;
            fat.Geneltoplam = pf.topm;
            fat.Katid = 1;
            fat.CariId = pf.CariId;
            fat.Duztarih = pf.Duztarih;
            fat.FatTur = pf.FatTur;
            fat.Fataciklama = pf.Fataciklama;
            fat.Katid = pf.Katid;
            fat.Aratop = pf.Aratop;
            fat.Kdv = pf.Kdv;

            _context.Fatura.Add(fat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFatura", new { id = fat.Fatid }, fat);
    
    */



        }

        // DELETE: api/Faturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fatura>> DeleteFatura(int id)
        {
            var fatura = await _context.Fatura.FindAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }

            _context.Fatura.Remove(fatura);
            await _context.SaveChangesAsync();

            return fatura;
        }

        private bool FaturaExists(int id)
        {
            return _context.Fatura.Any(e => e.Fatid == id);
        }
    }
}
