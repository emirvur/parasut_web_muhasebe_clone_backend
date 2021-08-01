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

        [HttpGet("ah")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetalishaftaFatura()
        {
            DateTime x = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - 1));
            DateTime y = DateTime.Today.AddDays((8 - (int)DateTime.Today.DayOfWeek));

            return await _context.Fatura.Where(z => z.FatTur == 0 && z.Duztarih >= x && z.Duztarih <= y).OrderByDescending(n => n.Duztarih).Include(c => c.Ode)
          .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
          v.Fataciklama, v.Kat.Katadi, v.Aratop,
          v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                 )).ToListAsync();
            /*  DateTime x = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

              return await _context.Fatura.Where(z => z.FatTur == 0 && z.Duztarih >= DateTime.Today && z.Duztarih <= x).Include(c => c.Ode)
            .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
            v.Fataciklama, v.Kat.Katadi, v.Aratop,
            v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                   )).ToListAsync();*/
        }
        [HttpGet("aa")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetalisayFatura()
        {
           // DateTime x = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            return await _context.Fatura.Where(z => z.FatTur == 0 && z.Duztarih.Month == DateTime.Today.Month && z.Duztarih.Year == DateTime.Today.Year).OrderByDescending(n => n.Duztarih).Include(c => c.Ode)
          .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
          v.Fataciklama, v.Kat.Katadi, v.Aratop,
          v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                 )).ToListAsync();
        }
        [HttpGet("ag")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetalisgunFatura()
        {
            // DateTime x = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            return await _context.Fatura.Where(z => z.FatTur == 0 && z.Duztarih.Month == DateTime.Today.Month && z.Duztarih.Year == DateTime.Today.Year && z.Duztarih.Day == DateTime.Today.Day).OrderByDescending(n => n.Duztarih).Include(c => c.Ode)
          .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
          v.Fataciklama, v.Kat.Katadi, v.Aratop,
          v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                 )).ToListAsync();
        }

        [HttpGet("sh")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetsatishaftaFatura()
        {

            DateTime x = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek-1));
            DateTime y = DateTime.Today.AddDays((8-(int)DateTime.Today.DayOfWeek));

            return await _context.Fatura.Where(z => z.FatTur == 1 && z.Duztarih >= x && z.Duztarih <= y).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs)
          .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
          v.Fataciklama, v.Kat.Katadi, v.Aratop,
          v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                 )).ToListAsync();
            /*   DateTime x = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

               return await _context.Fatura.Where(z => z.FatTur == 1 && z.Duztarih >= DateTime.Today && z.Duztarih <= x).Include(c => c.Tahs)
             .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
             v.Fataciklama, v.Kat.Katadi, v.Aratop,
             v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                    )).ToListAsync();*/
        }
        [HttpGet("sa")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetsatisayFatura()
        {
            // DateTime x = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            return await _context.Fatura.Where(z => z.FatTur == 1 && z.Duztarih.Month == DateTime.Today.Month && z.Duztarih.Year == DateTime.Today.Year).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs)
          .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
          v.Fataciklama, v.Kat.Katadi, v.Aratop,
          v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                 )).ToListAsync();
        }
        [HttpGet("sg")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetsatisgunFatura()
        {
            // DateTime x = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            return await _context.Fatura.Where(z =>z.FatTur==1 &&z.Duztarih.Month == DateTime.Today.Month && z.Duztarih.Year == DateTime.Today.Year && z.Duztarih.Day == DateTime.Today.Day).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs)
          .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
          v.Fataciklama, v.Kat.Katadi, v.Aratop,
          v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                 )).ToListAsync();
        }

        [HttpGet("t/{id}")]
        public async Task<ActionResult<dtofattahs>> GetdetayFatura(int id)
        {
       
           
           return await _context.Fatura.Where(a => a.Fatid == id).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs)
             .Select(v => new dtofattahs(v.Fatid,v.FatTur, v.Tahs.Durum, v.CariId,v.Cari.Cariunvani,v.Duztarih,
             v.Fataciklama,v.Kat.Katadi,v.Aratop,
             v.Araind??-1,v.Kdv??-1,v.Geneltoplam,v.Tahs.Vadetarih,v.Tahs.Tediltar,v.Tahs.Alinmismik ,v.Tahsid??-1
                    )).FirstOrDefaultAsync();

          
        }

        [HttpGet("o/{id}")]
        public async Task<ActionResult<dtofatode>> getalisfat(int id)
        {
          


            return await _context.Fatura.Where(a => a.Fatid == id).OrderByDescending(n => n.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).FirstOrDefaultAsync();


        }
        [HttpGet("c/{id}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> getmusterininfat(int id)
        {


            return await _context.Fatura.Where(a => a.CariId == id&&a.Durum==0).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("oc/{id}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> getcarialisfat(int id)
        {



            return await _context.Fatura.Where(a => a.CariId == id&& a.Durum == 0).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }


        
        [HttpGet("lt")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetlistFatura()
        {


            return await _context.Fatura.Where(a=>a.FatTur==1).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur,v.Tahs.Durum ,v.CariId, v.Cari.Cariunvani, v.Duztarih.Date,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     ))//.OrderByDescending(n=>n.duzenlemetarih)
                     .ToListAsync();


        }
        [HttpGet("lt/dt/ac")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetduztarlistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 1).OrderByDescending(n => n.Duztarih).Include(c => c.Tahs).OrderBy(h => h.Duztarih)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("lt/dt/ca")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetduztardesclistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 1).Include(c => c.Tahs).OrderByDescending(h => h.Duztarih)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("lt/vt/ac")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetvadtarlistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 1 && a.Durum == 0).Include(c => c.Tahs).OrderBy(h => h.Tahs.Vadetarih)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("lt/vt/ca")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetvatardesclistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 1&&a.Durum==0).Include(c => c.Tahs).OrderByDescending(h => h.Tahs.Vadetarih)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("lt/at")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetaciklistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 1&&a.Durum==0).OrderByDescending(h => h.Duztarih).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("lt/kt")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetkapclistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 1&&a.Durum==1).OrderByDescending(h => h.Duztarih).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("gt")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> getgecikmistahs()
        {
            DateTime x = DateTime.Now.Date;
         
            

            

            return await _context.Fatura.Where(a => a.FatTur == 1 && a.Durum == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Tahs).Where(d => d.Tahs.Vadetarih < x)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("go")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> getgecodeme()
        {
            DateTime x = DateTime.Now.Date;





            return await _context.Fatura.Where(a => a.FatTur == 0 && a.Durum == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode).Where(d => d.Ode.Odenecektar < x)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("lt/{id}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetcarisatlistFatura(int id)
        {


            return await _context.Fatura.Where(a => a.FatTur == 1&&a.CariId==id).OrderByDescending(h => h.Duztarih).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("lt/a/{id}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetacikcarisatlistFatura(int id)
        {


            return await _context.Fatura.Where(a => a.FatTur == 1 && a.CariId == id&&a.Durum==0).OrderByDescending(h => h.Duztarih).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("lt/g/{id}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> getmustgecmis(int id)
        {
            DateTime x = DateTime.Now.Date;

            return await _context.Fatura.Where(a => a.FatTur == 1 && a.CariId == id && a.Durum == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Tahs).Where(d => d.Tahs.Vadetarih < x)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od/g/{id}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> gettedargecmis(int id)
        {
            DateTime x = DateTime.Now.Date;

            return await _context.Fatura.Where(a => a.FatTur == 0 && a.CariId == id && a.Durum == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode).Where(d => d.Ode.Odenecektar < x)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }


        [HttpGet("rap/{bir}/{iki}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> getsatrapor(DateTime bir,DateTime iki)
        {


            return await _context.Fatura.Where(z=>z.Duztarih>=bir&&z.Duztarih<=iki).OrderByDescending(h => h.Duztarih).Where(a => a.FatTur == 1).Include(c => c.Tahs)
              .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("alrap/{bir}/{iki}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> getalrapor(DateTime bir, DateTime iki)
        {


            return await _context.Fatura.Where(z => z.Duztarih >= bir && z.Duztarih <= iki).Where(a => a.FatTur == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("od/od")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> getodene()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0&&a.Durum==0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("od/a")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetacikodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0&&a.Durum==0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od/k")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetkapaliodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0 && a.Durum == 1).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }


        [HttpGet("od/gt")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> get()
        {

            DateTime x = DateTime.Now.Date;
            return await _context.Fatura.Where(a => a.FatTur == 0 && a.Durum == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode).Where(d => d.Ode.Odenecektar < x)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od/dt/ac")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetduzacodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).OrderByDescending(g=>g.duzenlemetarih).ToListAsync();


        }
        [HttpGet("od/dt/ca")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetduzcaodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0 ).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).OrderBy(g => g.duzenlemetarih).ToListAsync();


        }
        [HttpGet("od/tt/ac")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GettedişacodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0 ).OrderByDescending(h => h.Duztarih).Include(c => c.Ode).OrderByDescending(l=>l.Ode.Odenecektar)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od/tt/ca")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GettedişcaodelistFatura()
        {


            return await _context.Fatura.Where(a => a.FatTur == 0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode).OrderBy(l => l.Ode.Odenecektar)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }



        [HttpGet("od/{id}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetcariodelistFatura(int id)
        {


            return await _context.Fatura.Where(a => a.FatTur == 0&&a.CariId==id).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }

        [HttpGet("od/a/{id}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetcariacikodelistFatura(int id)
        {


            return await _context.Fatura.Where(a => a.FatTur == 0 && a.CariId == id&&a.Durum==0).OrderByDescending(h => h.Duztarih).Include(c => c.Ode)
              .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1
                     )).ToListAsync();


        }
        [HttpGet("s/{ad}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetsatfarListUrun(string ad)
        {

            return await _context.Fatura.Where(a => a.FatTur == 1).Where(c => c.Fataciklama.Contains(ad)).OrderByDescending(h => h.Duztarih)
                .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1)).ToListAsync();

        }
        [HttpGet("a/{ad}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> getalfatara(string ad)
        {

            return await _context.Fatura.Where(a => a.FatTur == 0).Where(c => c.Fataciklama.Contains(ad)).OrderByDescending(h => h.Duztarih)
                .Select(v => new dtofatode(v.Fatid, v.FatTur, v.Ode.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Ode.Odenecektar, v.Ode.Odenmistar, v.Ode.Odendimik, v.Odeid ?? -1)).ToListAsync();

        }
        [HttpGet("gd")]
        public async Task<ActionResult<IEnumerable<dtogunceldurum>>> getguncel()
        {
            DateTime bugun = DateTime.Now;
            DateTime ayinbiri = new DateTime(bugun.Year,bugun.Month,01);
            DateTime ayinsonu = new DateTime(bugun.Year, bugun.Month, 30);

            return await _context.Fatura.Where(h=>h.Durum==0).Where(k=>(k.Tahs.Vadetarih>=ayinbiri&&k.Tahs.Vadetarih<=ayinsonu)||(k.Ode.Odenecektar>=ayinbiri&&k.Ode.Odenecektar<=ayinsonu))   //.Where(a => a.Durum ==0&&a.Duztarih>=ayinbiri&&a.Duztarih<=bugun)
                 .OrderByDescending(h => h.Duztarih).Select(v => new dtogunceldurum(v.Fataciklama, v.FatTur ,
            v.Tahs.Vadetarih,v.Ode.Odenecektar,v.Tahs.Alinmismik,v.Tahs.Topmik,v.Ode.Odendimik,v.Ode.Topmik)).ToListAsync();
           
        

        }

        [HttpGet("c/{id}/{ad}")]
        public async Task<ActionResult<IEnumerable<dtofattahs>>> GetsatfarListara(int id,string ad)
        {

            return await _context.Fatura.Where(a => a.FatTur == 1).Where(c => c.Fataciklama.Contains(ad)&&c.CariId==id&& c.Durum == 0).OrderByDescending(h => h.Duztarih)
                .Select(v => new dtofattahs(v.Fatid, v.FatTur, v.Tahs.Durum, v.CariId, v.Cari.Cariunvani, v.Duztarih,
              v.Fataciklama, v.Kat.Katadi, v.Aratop,
              v.Araind ?? -1, v.Kdv ?? -1, v.Geneltoplam, v.Tahs.Vadetarih, v.Tahs.Tediltar, v.Tahs.Alinmismik, v.Tahsid ?? -1)).ToListAsync();

        }

        [HttpGet("a/{id}/{ad}")]
        public async Task<ActionResult<IEnumerable<dtofatode>>> GetalfatListUrun(int id,string ad)
        {

            return await _context.Fatura.Where(a => a.FatTur == 0).Where(c => c.Fataciklama.Contains(ad)&&c.CariId==id&& c.Durum == 0).OrderByDescending(h => h.Duztarih)
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
            var transaction = _context.Database.BeginTransaction();

            try {

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

                    if (pf.sipa.durum == 1)
                    {
                        fa.Durum = 1;
                    }
                    else
                    {
                        fa.Durum = 0;
                    }

                    fa.Urunhareket = pf.hareket;


                    _context.Fatura.Add(fa);

                    await _context.SaveChangesAsync();




                    if (pf.sipa.durum == 1)
                    {

                        Tahshar har = new Tahshar();
                        har.Tahsid = fa.Tahsid ?? -1;
                        har.Tediltar = pf.sipa.tedt ?? DateTime.Now;
                        har.Kasaid = pf.sipa.kasaid;
                        har.Aciklama = pf.sipa.Fataciklama ?? "";
                        har.Alinmismik = pf.sipa.alinm;

                        _context.Tahshar.Add(har);

                        await _context.SaveChangesAsync();
                        Kasahar kashar = new Kasahar { };
                        kashar.Kasaid = pf.sipa.kasaid;
                        kashar.Durum = 1;
                        kashar.Miktar = pf.sipa.alinm;
                        kashar.Miktaraciklamasi = pf.sipa.Fataciklama;
                        kashar.Thid = har.Thid;
                        kashar.Netbakiye = -1;
                        _context.Kasahar.Add(kashar);

                        await _context.SaveChangesAsync();



                    }
           
                    transaction.Commit();
                    return CreatedAtAction("GetFatura", new { id = fa.Fatid }, fa);
                }
                Odemeler ode = new Odemeler { };
                ode.Kasaid = pf.sipa.kasaid;
                ode.Aciklama = pf.sipa.tahac ?? "";
                ode.Durum = pf.sipa.durum;
                if (pf.sipa.durum == 1)
                {
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
                if (pf.sipa.durum == 1)
                {
                    fat.Durum = 1;
                }
                else
                {
                    fat.Durum = 0;
                }

                fat.Urunhareket = pf.hareket;

                _context.Fatura.Add(fat);
                await _context.SaveChangesAsync();

                if (pf.sipa.durum == 1)
                {

                    Odehar har = new Odehar();
                    har.Odeid = fat.Odeid ?? -1;
                    har.Odenmistar = pf.sipa.tedt ?? DateTime.Now;
                    har.Kasaid = pf.sipa.kasaid;
                    har.Aciklama = pf.sipa.Fataciklama ?? "";
                    har.Odendimik = pf.sipa.alinm;


                    _context.Odehar.Add(har);

                    await _context.SaveChangesAsync();
                    Kasahar kashar = new Kasahar { };
                    kashar.Kasaid = pf.sipa.kasaid;
                    kashar.Durum = 1;
                    kashar.Miktar = pf.sipa.alinm;
                    kashar.Miktaraciklamasi = pf.sipa.Fataciklama;
                    kashar.Ohid = har.Ohid;
                    kashar.Netbakiye = -1;
                    _context.Kasahar.Add(kashar);





                    await _context.SaveChangesAsync();



                }
                transaction.Commit();
                return CreatedAtAction("GetFatura", new { id = fat.Fatid }, fat);


            }
            catch (Exception e)
            {
                transaction.Rollback();
                return NotFound();
            }

          
  


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
