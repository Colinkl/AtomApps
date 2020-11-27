using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catto.DataLib.Data;
using Catto.DataLib.Models;

namespace Catto.Api.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairOrdersController : ControllerBase
    {
        private readonly AtomContextDB _context;

        public RepairOrdersController(AtomContextDB context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetRepairOrders()
        {
            return await _context.Project.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetRepairOrder(int id)
        {
            var repairOrder = await _context.Project.FindAsync(id);

            if (repairOrder == null)
            {
                return NotFound();
            }

            return repairOrder;
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairOrder(int id, Project repairOrder)
        {
            if (id != repairOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(repairOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(id))
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostRepairOrder(Project repairOrder)
        {
            _context.Project.Add(repairOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairOrder", new { id = repairOrder.Id }, repairOrder);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairOrder(int id)
        {
            var repairOrder = await _context.Project.FindAsync(id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            _context.Project.Remove(repairOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairOrderExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
