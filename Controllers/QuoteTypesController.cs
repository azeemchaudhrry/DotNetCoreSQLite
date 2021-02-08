using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotNetCoreSQLite.Config;
using dotNetCoreSQLite.Model;

namespace dotNetCoreSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteTypesController : ControllerBase
    {
        private readonly QuoteDbContext _context;

        public QuoteTypesController(QuoteDbContext context)
        {
            _context = context;
        }

        // GET: api/QuoteTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteType>>> Getquote_types()
        {
            return await _context.quote_types.ToListAsync();
        }

        // GET: api/QuoteTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteType>> GetQuoteType(int id)
        {
            var quoteType = await _context.quote_types.FindAsync(id);

            if (quoteType == null)
            {
                return NotFound();
            }

            return quoteType;
        }

        // PUT: api/QuoteTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuoteType(int id, QuoteType quoteType)
        {
            if (id != quoteType.id)
            {
                return BadRequest();
            }

            _context.Entry(quoteType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteTypeExists(id))
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

        // POST: api/QuoteTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuoteType>> PostQuoteType(QuoteType quoteType)
        {
            _context.quote_types.Add(quoteType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuoteType", new { id = quoteType.id }, quoteType);
        }

        // DELETE: api/QuoteTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuoteType>> DeleteQuoteType(int id)
        {
            var quoteType = await _context.quote_types.FindAsync(id);
            if (quoteType == null)
            {
                return NotFound();
            }

            _context.quote_types.Remove(quoteType);
            await _context.SaveChangesAsync();

            return quoteType;
        }

        private bool QuoteTypeExists(int id)
        {
            return _context.quote_types.Any(e => e.id == id);
        }
    }
}
