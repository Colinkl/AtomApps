using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catto.DataLib.Data;
using Catto.DataLib.Models;
using Microsoft.AspNetCore.Authorization;

namespace Catto.Api.Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MalfuntionsController : ControllerBase
    {
        private readonly AtomContextDB _context;

        public MalfuntionsController(AtomContextDB context)
        {
            _context = context;
        }

        // GET: api/Malfuntions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Malfuntions>>> GetMalfuntionsList()
        {
            return await _context.MalfuntionsList.ToListAsync();
        }

        // GET: api/Malfuntions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Malfuntions>> GetMalfuntions(int id)
        {
            var malfuntions = await _context.MalfuntionsList.FindAsync(id);

            if (malfuntions == null)
            {
                return NotFound();
            }

            return malfuntions;
        }

        // PUT: api/Malfuntions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMalfuntions(int id, Malfuntions malfuntions)
        {
            if (id != malfuntions.Id)
            {
                return BadRequest();
            }

            _context.Entry(malfuntions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MalfuntionsExists(id))
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

        // POST: api/Malfuntions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Malfuntions>> PostMalfuntions(Malfuntions malfuntions)
        {
            _context.MalfuntionsList.Add(malfuntions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMalfuntions", new { id = malfuntions.Id }, malfuntions);
        }

        // DELETE: api/Malfuntions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMalfuntions(int id)
        {
            var malfuntions = await _context.MalfuntionsList.FindAsync(id);
            if (malfuntions == null)
            {
                return NotFound();
            }

            _context.MalfuntionsList.Remove(malfuntions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MalfuntionsExists(int id)
        {
            return _context.MalfuntionsList.Any(e => e.Id == id);
        }
    }
}
