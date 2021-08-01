using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MuhasebeApi.Models;

namespace MuhasebeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalisansController : ControllerBase
    {
        private readonly MuhasebeContext _context;
        private readonly JWTSettings _jwtsettings;

        public CalisansController(MuhasebeContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }


        [HttpGet("yourUrl")]
        public
           ActionResult<string> gettoken()
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
               new Claim(ClaimTypes.Name,"emir")
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var x = tokenHandler.WriteToken(token);
            return x;




        }
        [Authorize]
        [HttpGet]
        public
            ActionResult<double> getsayi()
        {
            //   var authheader= HttpContext.Request.Headers["Authorization"];
            return 2.0;
        }

       [Authorize]
        [HttpGet("b/{ad}/{sifre}")]
        public async Task<ActionResult<IEnumerable<Calisan>>> Getsqlgiris(string ad,string sifre)
        {
           //var param1 = new Microsoft.Data.SqlClient.SqlParameter("@ad", ad);
          //  var param2 = new Microsoft.Data.SqlClient.SqlParameter("@sifre", sifre);

           //    return await _context.Calisan.FromSqlRaw("select * from calisan where eposta={0} and tck={1}", param1,param2).ToListAsync();

               var query = $"select * from calisan where eposta ='{ad}' and tck ='{sifre}'";
              return await _context.Calisan.FromSqlRaw(query).ToListAsync();

            //em' or '1'='1'--
            //q';truncate table calisan;--
            //f';create login [sizma] with password=N'Password1';alter server role [sysadmin] add member [sizma];--
        }


        // GET: api/Calisans
     [Authorize]
        [HttpGet("sp/{ilk}/{son}")]
        public async Task<List<gunceldurum>> Getsp(DateTime ilk,DateTime son)
        {
            var param1 = new SqlParameter("@ilk", ilk);
            var param2 = new SqlParameter("@son", son);
           
            var result = await _context.gunceldurum.FromSqlRaw("execute [dbo].[gunceldurum] {0},{1}", param1,param2 ).ToListAsync();
            List<gunceldurum> lis = result.Select(s => new gunceldurum
            {
                toplammiktar=s.toplammiktar,
                alinan=s.alinan,
                odenen=s.odenen,
                fatsayisi=s.fatsayisi,
                tur=s.tur
             
            }).ToList();
            return lis;
        }
     [Authorize]
        [HttpGet("v")]
        public async Task<List<gunceldurummod1>> Getverisp()
        {
           

            var result = await _context.gunceldurummod1.FromSqlRaw("execute [dbo].[verial] ").ToListAsync();
            List<gunceldurummod1> lis = result.Select(s => new gunceldurummod1
            {
                toplammiktar = s.toplammiktar,
                alinan = s.alinan,
                odenen = s.odenen,
                fatsayisi = s.fatsayisi,
                tur = s.tur,
                durum = s.durum
            }).ToList();
            return lis;
        }

        /*  [HttpGet]
          public ActionResult<IEnumerable<object>> GetCalisan()
          {
              var y = _context.Database.ExecuteSqlRaw("select sum(geneltoplam) as toplammiktar,sum(IsNull(Tahsilat.alinmismik, 0)) as alinan, sum(IsNull(Odemeler.odendimik, 0)) as odenen, COUNT(fatid) as fatsayisi, fat_tur as tur, Fatura.durum as durum from Fatura  full join Tahsilat on Fatura.tahsid = Tahsilat.tahsid full join Odemeler on Fatura.odeid = Odemeler.odeid group by Fatura.durum, Fatura.fat_tur ");
              return y;
          }*/

        // GET: api/Calisans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calisan>> GetCalisan(int id)
        {
            var calisan = await _context.Calisan.FindAsync(id);

            if (calisan == null)
            {
                return NotFound();
            }

            return calisan;
        }

        // PUT: api/Calisans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalisan(int id, Calisan calisan)
        {
            if (id != calisan.Calid)
            {
                return BadRequest();
            }

            _context.Entry(calisan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalisanExists(id))
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

        // POST: api/Calisans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Calisan>> PostCalisanq()
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                Calisan calisan = new Calisan();
                calisan.Adsoyad = "eaatq";
                calisan.Eposta = "ww";
                calisan.Katid = 1;
                calisan.Tck = "11";
                calisan.Iban = "1";
                calisan.Telno = "1";
                _context.Calisan.Add(calisan);
                await _context.SaveChangesAsync();

                throw new Exception();

                Kategori k = new Kategori();
                k.Katadi = "ee";
                k.Hangikat = 0;
                _context.Kategori.Add(k);
                await _context.SaveChangesAsync();


                transaction.Commit();
                return CreatedAtAction("GetCalisan", new { id = calisan.Calid }, calisan);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return NotFound();
            }
        }

        

        // DELETE: api/Calisans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calisan>> DeleteCalisan(int id)
        {
            var calisan = await _context.Calisan.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }

            _context.Calisan.Remove(calisan);
            await _context.SaveChangesAsync();

            return calisan;
        }

        private bool CalisanExists(int id)
        {
            return _context.Calisan.Any(e => e.Calid == id);
        }
    }
}
