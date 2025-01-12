using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuzasController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public HuzasController(WebAPIContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Huzas>>> GetHuzas()
        {
            return await _context.Huzas.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Huzas>> GetHuzas(int id)
        {
            var huzas = await _context.Huzas.FindAsync(id);

            if (huzas == null)
            {
                return NotFound();
            }

            return huzas;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuzas(int id, Huzas huzas)
        {
            if (id != huzas.Id)
            {
                return BadRequest();
            }

            _context.Entry(huzas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HuzasExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<Huzas>> PostHuzas(Huzas huzas)
        {
            _context.Huzas.Add(huzas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHuzas", new { id = huzas.Id }, huzas);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuzas(int id)
        {
            var huzas = await _context.Huzas.FindAsync(id);
            if (huzas == null)
            {
                return NotFound();
            }

            _context.Huzas.Remove(huzas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HuzasExists(int id)
        {
            return _context.Huzas.Any(e => e.Id == id);
        }
    }
}
