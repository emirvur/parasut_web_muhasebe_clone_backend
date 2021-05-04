using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MuhasebeApi.Models;

namespace MuhasebeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IrsaliyesController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public IrsaliyesController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Irsaliyes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Irsaliye>>> GetIrsaliye()
        {
            return await _context.Irsaliye.ToListAsync();
        }

        // GET: api/Irsaliyes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Irsaliye>> GetIrsaliye(int id)
        {
            var irsaliye = await _context .Irsaliye.FindAsync(id);

            if (irsaliye == null)
            {
                return NotFound();
            }

            return irsaliye;
        }

        [HttpGet("t")]
        public  ActionResult<int> gettest11()
        {
          _context.Database.ExecuteSqlRaw("exec testsp");
            return 1;

            
        }

        [HttpGet("t/{mail}")]
        public ActionResult<int> gettest11(string mail)
        {
            var param = new SqlParameter("@mail", mail);
            _context.Database.ExecuteSqlRaw("exec adreslimail @mail",param);
            return 1;


        }


        [HttpGet("i")]
        public async Task<ActionResult<IEnumerable<dtoirsaliye>>> gettumirs()
        {


            return await _context.Irsaliye.Where(a => a.Fatmi == 0)//.Include(c => c)
              .Select(v => new dtoirsaliye(v.Irsid, v.Tur, v.CariId, v.Cari.Cariunvani, v.Aratop,v.Araind,v.Kdv,v.Geneltop,
              v.Tarih, v.Fatmi, v.Aciklama
            
                     )).ToListAsync();


        }
        [HttpGet("{ilktar}/{sontar}")]
        public async Task<ActionResult<IEnumerable<dtoirsaliye>>> gettarihirs(string ilktar,string sontar)
        {
            DateTime g = Convert.ToDateTime(ilktar);
            DateTime k = Convert.ToDateTime(sontar);

            return await _context.Irsaliye.Where(a => a.Fatmi == 0).Where(b=>b.Tarih>=g&&b.Tarih<=k)//.Include(c => c)
              .Select(v => new dtoirsaliye(v.Irsid, v.Tur, v.CariId, v.Cari.Cariunvani, v.Aratop, v.Araind, v.Kdv, v.Geneltop,
              v.Tarih, v.Fatmi, v.Aciklama

                     )).ToListAsync();


        }


        // PUT: api/Irsaliyes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}/{ilktar}/{sontar}")]
        public async Task<IActionResult> PutIrsaliye(int id, string ilktar, string sontar)
        {
            DateTime g = Convert.ToDateTime(ilktar);
            DateTime t = Convert.ToDateTime(sontar);

            List<Irsaliye> irli = await _context.Irsaliye.Where(a => a.CariId == id&&a.Fatmi==0).Where(b => b.Tarih >= g && b.Tarih <= t)
           .ToListAsync();
            float arat = 0;
            float arai = 0;
            float kd = 0;
            float ge = 0;

            int m = irli.Count();
            int n = 0;
            for (int k = 0; k < m; k++)
            {
                irli[k].Fatmi = 1;
                arat = arat + irli[k].Aratop;
                arai = arai + irli[k].Araind;
                kd = kd + irli[k].Kdv;
                ge = ge + irli[k].Geneltop;
            }


            Tahsilat tah = new Tahsilat { };
            tah.Kasaid = 9;
            tah.Aciklama =  "";
            tah.Durum =0;
         
              tah.Vadetarih = DateTime.Now;

         

            tah.Alinmismik = 0;
            tah.Topmik = ge;
            tah.Fatad = "";
            tah.Duzt = DateTime.Now;

            Fatura fa = new Fatura { };

            fa.Tahs = tah;
            fa.Geneltoplam = ge;
            fa.Katid = 1;
            fa.CariId = id;
            fa.Duztarih = DateTime.Now;
            fa.FatTur = 1;
            fa.Fataciklama = "";
            fa.Katid = 1;
            fa.Aratop = arat;
            fa.Kdv = kd;

       
                fa.Durum = 0;
         

         //   fa.Urunhareket = pf.hareket;


            _context.Fatura.Add(fa);

            await _context.SaveChangesAsync();

            int z = irli.Count();
            List<int> idler = new List<int>();
           
            for(int o = 0; o < z; o++)
            {
                idler.Add(irli[o].Irsid);
            }

            List<Urunhareket> li = await _context.Urunhareket.Where(a => idler.Contains(a.Irsid ?? -1)).ToListAsync();
            int q = li.Count();

            for (int k = 0; k < q; k++)
            {
                li[k].Fatid = fa.Fatid;

            }
            await _context.SaveChangesAsync();
            return Ok();
         //   return Ok(fa.Fatid); //CreatedAtAction("GetKategori", new { id = fa.Fatid });
        }




        // POST: api/Irsaliyes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> Postirsaliye(postirsaliye pf)
        {
            if (pf.sipa.Tur == 1)
            {
               


                Irsaliye fa = new Irsaliye { };

            
                fa.Geneltop = pf.sipa.Geneltop;
             
                fa.CariId = pf.sipa.CariId;
                fa.Tarih = pf.sipa.Tarih;
                fa.Tur = pf.sipa.Tur;
                fa.Aciklama = pf.sipa.Aciklama;
              
                fa.Aratop = pf.sipa.Aratop??-1;
                fa.Kdv = pf.sipa.Kdv??-1;

                
                fa.Urunhareket = pf.hareket;


                _context.Irsaliye.Add(fa);

                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Irsaliyes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Irsaliye>> DeleteIrsaliye(int id)
        {
            var irsaliye = await _context.Irsaliye.FindAsync(id);
            if (irsaliye == null)
            {
                return NotFound();
            }

            _context.Irsaliye.Remove(irsaliye);
            await _context.SaveChangesAsync();

            return irsaliye;
        }

        private bool IrsaliyeExists(int id)
        {
            return _context.Irsaliye.Any(e => e.Irsid == id);
        }
    }
}
