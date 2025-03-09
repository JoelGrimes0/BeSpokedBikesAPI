using BeSpokedBikesAPI.Data;
using BeSpokedBikesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikesAPI.Controllers
{
    [Authorize]
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
            {
                return NotFound();
            }
            return sale;
        }

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Sale>> CreateSale(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }
            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Sales/filter?startDate=2025-01-01&endDate=2025-03-31
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            var sales = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                .ToListAsync();

            return Ok(sales);
        }

        // GET: api/Sales/commissionReport
        [HttpGet("commissionReport")]
        public async Task<ActionResult<IEnumerable<object>>> GetCommissionReport()
        {
            // Group by Salesperson, Quarter, and Year
            var report = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .GroupBy(s => new
                {
                    s.SalespersonId,
                    Quarter = (s.SalesDate.Month - 1) / 3 + 1,
                    Year = s.SalesDate.Year
                })
                .Select(g => new
                {
                    SalespersonId = g.Key.SalespersonId,
                    Quarter = g.Key.Quarter,
                    Year = g.Key.Year,
                    TotalSales = g.Sum(s => s.Product.SalePrice),
                    CommissionEarned = g.Sum(s => s.Product.SalePrice * s.Product.CommissionPercentage)
                })
                .ToListAsync();

            return Ok(report);
        }
    }
}
