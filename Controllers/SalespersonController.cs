using BeSpokedBikesAPI.Data;
using BeSpokedBikesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeSpokedBikesAPI.Controllers
{
    //[Authorize]
    [Route("api/salesperson")]
    [ApiController]
    public class SalespersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalespersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Salespersons
        [HttpGet("allSalespersons")]
        public async Task<ActionResult<IEnumerable<Salesperson>>> GetSalespersons()
        {
            return await _context.Salespersons.ToListAsync();
        }

        // GET: api/Salespersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salesperson>> GetSalesperson(int id)
        {
            var salesperson = await _context.Salespersons.FindAsync(id);
            if (salesperson == null)
            {
                return NotFound();
            }
            return salesperson;
        }

        // POST: api/Salespersons
        [HttpPost]
        public async Task<ActionResult<Salesperson>> CreateSalesperson(Salesperson salesperson)
        {
            // Prevent duplicate salesperson (using FirstName, LastName, and Phone as unique key)
            if (await _context.Salespersons.AnyAsync(s => s.FirstName == salesperson.FirstName &&
                                                          s.LastName == salesperson.LastName &&
                                                          s.Phone == salesperson.Phone))
            {
                return Conflict("Salesperson already exists.");
            }

            _context.Salespersons.Add(salesperson);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesperson), new { id = salesperson.Id }, salesperson);
        }

        // PUT: api/Salespersons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesperson(int id, Salesperson salesperson)
        {
            if (id != salesperson.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesperson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Optionally, check for duplicate salesperson errors
                if (await _context.Salespersons.AnyAsync(s => s.Id == id))
                {
                    return Conflict("Duplicate salesperson detected.");
                }
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Salespersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesperson(int id)
        {
            var salesperson = await _context.Salespersons.FindAsync(id);
            if (salesperson == null)
            {
                return NotFound();
            }

            _context.Salespersons.Remove(salesperson);
            await _context.SaveChangesAsync();
            return NoContent();
        }        
    }
}
