
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMasterController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public OrderMasterController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetOrderMaster()
        {
            return await _context.OrderMasters.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMaster>> GetOrderMaster(int id)
        {
            var OrderMaster = await _context.OrderMasters.FindAsync(id);

            if (OrderMaster == null)
            {
                return NotFound();
            }

            return OrderMaster;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMaster(int id, OrderMaster OrderMaster)
        {
            OrderMaster.OrderMasterId = id;

            _context.Entry(OrderMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExistsOrderMaster(id))
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

        // POST: api/DCandidate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrderMaster>> PostOrderMaster(OrderMaster OrderMaster)
        {
            _context.OrderMasters.Add(OrderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMaster", new { id = OrderMaster.OrderMasterId }, OrderMaster);
        }

        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderMaster>> DeleteOrderMaster(int id)
        {
            var OrderMaster = await _context.OrderMasters.FindAsync(id);
            if (OrderMaster == null)
            {
                return NotFound();
            }

            _context.OrderMasters.Remove(OrderMaster);
            await _context.SaveChangesAsync();

            return OrderMaster;
        }

        private bool ExistsOrderMaster(int id)
        {
            return _context.OrderMasters.Any(e => e.OrderMasterId == id);
        }
    }
}