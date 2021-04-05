﻿using System;
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
    public class OdemelersController : ControllerBase
    {
        private readonly MuhasebeContext _context;

        public OdemelersController(MuhasebeContext context)
        {
            _context = context;
        }

        // GET: api/Odemelers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odemeler>>> GetOdemeler()
        {
            return await _context.Odemeler.ToListAsync();
        }

        // GET: api/Odemelers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odemeler>> GetOdemeler(int id)
        {
            var odemeler = await _context.Odemeler.FindAsync(id);

            if (odemeler == null)
            {
                return NotFound();
            }

            return odemeler;
        }

        // PUT: api/Odemelers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutOdemeler(odeput op)
        {
            Odemeler od = await _context.Odemeler.SingleOrDefaultAsync(p => p.Odeid == op.id);

            if (od.Topmik - od.Odendimik == 0)
            {
                od.Durum = 1;
                od.Odendimik = od.Topmik;
            }
            else
            {
                od.Odendimik = od.Odendimik + op.odendim;
            }
            Odehar har = new Odehar();
            har.Odeid = op.id;
            har.Odenmistar = op.odent;
            har.Kasaid = op.kasid;
            har.Aciklama = op.acik;
            har.Odendimik = op.odendim;

            Kasa kasa = await _context.Kasa.FindAsync(op.kasid);
            kasa.Bakiye = kasa.Bakiye -op.odendim;


            Kasahar kashar = new Kasahar { };
            kashar.Kasaid = op.kasid;
            kashar.Durum = 2;
            kashar.Miktar = op.odendim;
            kashar.Miktaraciklamasi = op.acik;
            kashar.Ohid = op.id;
            List<Kasahar> khcol = new List<Kasahar>();
            khcol.Add(kashar);
            kasa.Kasahar = khcol;

            har.Kasa = kasa;


            _context.Odehar.Add(har);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdemelerExists(op.id))
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

        // POST: api/Odemelers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Odemeler>> PostOdemeler(Odemeler odemeler)
        {
            _context.Odemeler.Add(odemeler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdemeler", new { id = odemeler.Odeid }, odemeler);
        }

        // DELETE: api/Odemelers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Odemeler>> DeleteOdemeler(int id)
        {
            var odemeler = await _context.Odemeler.FindAsync(id);
            if (odemeler == null)
            {
                return NotFound();
            }

            _context.Odemeler.Remove(odemeler);
            await _context.SaveChangesAsync();

            return odemeler;
        }

        private bool OdemelerExists(int id)
        {
            return _context.Odemeler.Any(e => e.Odeid == id);
        }
    }
}