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
    public class CalisansController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public CalisansController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Calisans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calisan>>> GetCalisan()
        {
            return await _context.Calisan.ToListAsync();
        }

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
        public async Task<ActionResult<Calisan>> PostCalisan(Calisan calisan)
        {
            _context.Calisan.Add(calisan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalisan", new { id = calisan.Calid }, calisan);
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
