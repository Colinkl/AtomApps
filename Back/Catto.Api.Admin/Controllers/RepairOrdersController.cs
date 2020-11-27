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

        // GET: api/RepairOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairOrder>>> GetRepairOrders()
        {
            return await _context.RepairOrders.ToListAsync();
        }

        // GET: api/RepairOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairOrder>> GetRepairOrder(int id)
        {
            var repairOrder = await _context.RepairOrders.FindAsync(id);

            if (repairOrder == null)
            {
                return NotFound();
            }

            return repairOrder;
        }

        // PUT: api/RepairOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairOrder(int id, RepairOrder repairOrder)
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

        // POST: api/RepairOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepairOrder>> PostRepairOrder(RepairOrder repairOrder)
        {
            _context.RepairOrders.Add(repairOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairOrder", new { id = repairOrder.Id }, repairOrder);
        }

        // DELETE: api/RepairOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairOrder(int id)
        {
            var repairOrder = await _context.RepairOrders.FindAsync(id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            _context.RepairOrders.Remove(repairOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairOrderExists(int id)
        {
            return _context.RepairOrders.Any(e => e.Id == id);
        }
    }
}
